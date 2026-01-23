using System.IO.Compression;
using WinSCP;

namespace AutoPatcherAdmin
{
    public partial class AMain : Form
    {
        public const string PatchFileName = @"PList.gz";
        public const string TempUploadDirectory = "Out";
        public const string TempDownloadDirectory = "In";

        public string[] ExcludeList = new string[] { "Thumbs.db" };

        public List<FileInformation> OldList = new List<FileInformation>();
        public List<FileInformation> NewList = new List<FileInformation>();
        public Queue<FileInformation> UploadList = new Queue<FileInformation>();

        public List<FileInformation> ServerFileList, LocalFileList;
        public List<string> DeleteFileList;

        private int _totalScanFiles = 0;    // 服务器待扫描文件总数
        private int _currentScanCount = 0; // 当前已扫描文件数
        private bool _isScanning = false;  // 扫描状态标记

        // 原有字段保留，新增以下UI优化字段
        private DateTime _lastUiUpdateTime = DateTime.Now; // 最后一次UI更新时间
        private readonly int _uiUpdateInterval = 100; // UI更新节流间隔（毫秒）

        public bool Completed;

        public AMain()
        {
            InitializeComponent();

            ClientTextBox.Text = Settings.Client;
            HostTextBox.Text = Settings.Host;
            LoginTextBox.Text = Settings.Login;
            PasswordTextBox.Text = Settings.Password;
            AllowCleanCheckBox.Checked = Settings.AllowCleanUp;
            ProtocolDropDown.SelectedIndex = ProtocolDropDown.FindString(Settings.Protocol);

            DeleteDirectory(TempDownloadDirectory);
            DeleteDirectory(TempUploadDirectory);
        }

        /// <summary>
        /// 异步获取服务器文件列表（带进度条）
        /// </summary>
        /// <returns></returns>
        private async Task GetServerFileListWithProgressAsync()
        {
            if (_isScanning) return;
            _isScanning = true;
            ServerFileList = new List<FileInformation>();
            DeleteFileList = new List<string>();

            // 标准化服务器根路径
            string rootPath = string.Empty;
            try
            {
                rootPath = new Uri(Settings.Host).AbsolutePath;
            }
            catch
            {
                rootPath = Settings.Host.Contains("/") ? Settings.Host.Substring(Settings.Host.LastIndexOf("/")) : "/";
            }
            if (!rootPath.EndsWith("/")) rootPath += "/";

            // 第一步：预扫描获取总文件数（用于计算进度）
            await Task.Run(() =>
            {
                using Session session = new Session();
                OpenSession(session);
                // 预扫描统计待扫描文件总数
                _totalScanFiles = PreScanRemoteFiles(session, rootPath);
                
                // 更新UI：初始化进度条
                Invoke(new Action(() =>
                {
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = _totalScanFiles;
                    progressBar1.Value = 0;
                    ActionLabel.Text = $"预扫描完成，共需扫描 {_totalScanFiles} 个文件...";
                    Refresh();
                }));

                // 第二步：正式扫描，实时更新进度
                _currentScanCount = 0;
                ScanRemoteFilesWithProgress(session, rootPath, rootPath);
            });

            // 扫描完成后重置状态
            Invoke(new Action(() =>
            {
                ActionLabel.Text = $"服务器文件扫描完成，共找到 {ServerFileList.Count} 个文件";
                progressBar1.Value = _totalScanFiles; // 进度条拉满
                Refresh();
            }));

            _isScanning = false;
        }

        /// <summary>
        /// 预扫描服务器：统计待扫描文件总数（无UI更新）
        /// </summary>
        private int PreScanRemoteFiles(Session session, string currentRemotePath)
        {
            int fileCount = 0;
            try
            {
                RemoteDirectoryInfo remoteDir = session.ListDirectory(currentRemotePath);
                foreach (RemoteFileInfo file in remoteDir.Files)
                {
                    if (file.Name == "." || file.Name == "..") continue;

                    if (file.IsDirectory)
                    {
                        // 递归预扫描子目录
                        string subDirFullPath = $"{currentRemotePath.TrimEnd('/')}/{file.Name}";
                        fileCount += PreScanRemoteFiles(session, subDirFullPath);
                    }
                    else
                    {
                        // 只统计需要处理的文件（排除排除项和PList.gz）
                        if (!InExcludeList(file.Name) && !file.Name.Equals(PatchFileName, StringComparison.OrdinalIgnoreCase))
                        {
                            fileCount++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    MessageBox.Show($"预扫描服务器路径 {currentRemotePath} 失败：{ex.Message}", "警告");
                }));
            }
            return fileCount;
        }

        /// <summary>
        /// 正式扫描服务器文件，实时更新进度条
        /// </summary>
        private void ScanRemoteFilesWithProgress(Session session, string currentRemotePath, string rootRemotePath)
        {
            try
            {
                RemoteDirectoryInfo remoteDir = session.ListDirectory(currentRemotePath);
                foreach (RemoteFileInfo file in remoteDir.Files)
                {
                    if (file.Name == "." || file.Name == "..") continue;

                    if (file.IsDirectory)
                    {
                        string subDirFullPath = $"{currentRemotePath.TrimEnd('/')}/{file.Name}";
                        ScanRemoteFilesWithProgress(session, subDirFullPath, rootRemotePath);
                    }
                    else
                    {
                        if (InExcludeList(file.Name) || file.Name.Equals(PatchFileName, StringComparison.OrdinalIgnoreCase))
                            continue;

                        string relativePath = file.FullName.Replace(rootRemotePath, "")
                                                        .Replace("/", "\\")
                                                        .TrimStart('\\')
                                                        .TrimEnd('\\');

                        ServerFileList.Add(new FileInformation
                        {
                            FileName = relativePath,
                            Length = (int)file.Length,
                            Compressed = 0,
                            Creation = file.LastWriteTime
                        });

                        _currentScanCount++;

                        // ========== 替换为优化后的UI更新方法 ==========
                        SafeUpdateUi(() =>
                        {
                            progressBar1.Value = Math.Min(_currentScanCount, progressBar1.Maximum); // 防止超出最大值
                            ActionLabel.Text = $"正在扫描：{relativePath}（{_currentScanCount}/{_totalScanFiles}）";
                            // 移除强制Refresh()，改用WinForm自带的Update()轻量更新
                            Update(); 
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                SafeUpdateUi(() =>
                {
                    MessageBox.Show($"扫描服务器路径 {currentRemotePath} 失败：{ex.Message}", "警告");
                });
            }
        }

        /// <summary>
        /// 递归扫描服务器文件（修复路径格式，确保与本地一致）
        /// </summary>
        /// <param name="session">WinSCP会话</param>
        /// <param name="currentRemotePath">当前扫描的远程路径（完整路径）</param>
        /// <param name="rootRemotePath">服务器根路径（用于计算相对路径）</param>
        private void ScanRemoteFiles(Session session, string currentRemotePath, string rootRemotePath)
        {
            try
            {
                RemoteDirectoryInfo remoteDir = session.ListDirectory(currentRemotePath);
                
                foreach (RemoteFileInfo file in remoteDir.Files)
                {
                    if (file.Name == "." || file.Name == "..")
                        continue;

                    if (file.IsDirectory)
                    {
                        string subDirFullPath = $"{currentRemotePath.TrimEnd('/')}/{file.Name}";
                        ScanRemoteFiles(session, subDirFullPath, rootRemotePath);
                    }
                    else
                    {
                        if (InExcludeList(file.Name)) 
                            continue;

                        // ========== 核心修复：统一服务器文件相对路径格式 ==========
                        // 1. 去掉根路径，得到相对路径
                        string relativePath = file.FullName.Replace(rootRemotePath, "");
                        // 2. 替换/为\，统一分隔符
                        relativePath = relativePath.Replace("/", "\\");
                        // 3. 去掉开头/结尾的多余符号
                        relativePath = relativePath.TrimStart('\\').TrimEnd('\\');
                        // 4. 处理压缩文件后缀（仅非PList.gz文件）
                        string originalFileName = relativePath.EndsWith(".gz") && !relativePath.Equals(PatchFileName, StringComparison.OrdinalIgnoreCase)
                            ? relativePath[0..^3] // 去掉.gz后缀
                            : relativePath;

                        // ========== 修复压缩文件Length值 ==========
                        int fileLength = (int)file.Length;
                        int compressedLength = relativePath.EndsWith(".gz") ? fileLength : 0;
                        // 未压缩文件：Length=实际大小；压缩文件：Length=原始文件大小（先暂存为fileLength，后续修正）
                        int actualLength = relativePath.EndsWith(".gz") ? fileLength : fileLength;

                        ServerFileList.Add(new FileInformation
                        {
                            FileName = originalFileName, // 确保路径格式与本地完全一致
                            Length = actualLength,       // 修复：不再设为0，避免对比失败
                            Compressed = compressedLength,
                            Creation = file.LastWriteTime
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"扫描服务器路径 {currentRemotePath} 失败：{ex.Message}", "警告");
            }
        }

        // 同步修复RebuildSyncLogic中的进度条赋值（确保全流程逻辑一致）
        private async void RebuildSyncLogic()
        {
            try
            {
                ProcessButton.Enabled = false;
                // 初始化：progressBar2=总进度（0→100），progressBar1=阶段进度
                SafeUpdateUi(() =>
                {
                    progressBar2.Minimum = 0;
                    progressBar2.Maximum = 100;
                    progressBar2.Value = 0;

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 100;
                    progressBar1.Value = 0;

                    ActionLabel.Text = "初始化...";
                    Update();
                });

                // 1. 保存配置...（原有代码）

                // 2. 扫描本地文件：总进度0→10%，阶段进度0→100
                SafeUpdateUi(() => { progressBar2.Value = 0; progressBar1.Value = 0; ActionLabel.Text = "扫描本地文件..."; Update(); });
                GetLocalFileList();
                SafeUpdateUi(() => { progressBar2.Value = 10; progressBar1.Value = 100; Update(); });
                MessageBox.Show($"本地扫描结果：共找到 {LocalFileList.Count} 个文件（含压缩后缀）", "调试信息");

                // 3. 异步扫描服务器文件：总进度10→30%，阶段进度0→100
                SafeUpdateUi(() => { progressBar2.Value = 10; progressBar1.Value = 0; ActionLabel.Text = "开始扫描服务器文件..."; Update(); });
                await GetServerFileListWithProgressAsync();
                SafeUpdateUi(() => { progressBar2.Value = 30; progressBar1.Value = 100; Update(); });
                MessageBox.Show($"服务器扫描结果：共找到 {ServerFileList.Count} 个文件", "调试信息");

                // 4. 对比文件差异：总进度30→40%，阶段进度0→100
                SafeUpdateUi(() => { progressBar2.Value = 30; progressBar1.Value = 0; ActionLabel.Text = "对比文件差异..."; Update(); });
                GenerateSyncLists();
                SafeUpdateUi(() => { progressBar2.Value = 40; progressBar1.Value = 100; Update(); });

                // 5. 上传差异文件：总进度40→70%，阶段进度0→100
                if (UploadList.Count > 0)
                {
                    SafeUpdateUi(() => { progressBar2.Value = 40; progressBar1.Value = 0; ActionLabel.Text = "上传差异文件..."; Update(); });
                    BeginUpload();
                    SafeUpdateUi(() => { progressBar2.Value = 70; progressBar1.Value = 100; Update(); });
                }

                // 6. 删除冗余文件：总进度70→80%，阶段进度0→100
                if (DeleteFileList.Count > 0 && Settings.AllowCleanUp)
                {
                    SafeUpdateUi(() => { progressBar2.Value = 70; progressBar1.Value = 0; ActionLabel.Text = "删除冗余文件..."; Update(); });
                    CleanUpServerFiles();
                    SafeUpdateUi(() => { progressBar2.Value = 80; progressBar1.Value = 100; Update(); });
                }

                // 7. 生成并上传新的PList.gz：总进度80→95%（内部已处理）
                SafeUpdateUi(() => { progressBar2.Value = 80; progressBar1.Value = 0; ActionLabel.Text = "更新PList.gz..."; Update(); });
                UploadNewPList();

                // 最终完成：总进度拉满，阶段进度拉满
                SafeUpdateUi(() =>
                {
                    progressBar2.Value = 100;
                    progressBar1.Value = 100;
                    ActionLabel.Text = "同步完成！所有操作已执行完毕";
                    Update();
                });
                CompleteUpload();
            }
            catch (Exception ex)
            {
                ProcessButton.Enabled = true;
                _isScanning = false;
                SafeUpdateUi(() =>
                {
                    progressBar2.Value = 0;
                    progressBar1.Value = 0;
                });
                MessageBox.Show($"同步失败：{ex.ToString()}");
                ActionLabel.Text = "同步错误...";
            }
        }

        // 修复CompleteUpload/CompleteDownload方法，确保进度条拉满
        private void CompleteUpload()
        {
            SafeUpdateUi(() =>
            {
                FileLabel.Text = "已完成...";
                SpeedLabel.Text = "已完成...";
                ActionLabel.Text = "已完成...";

                progressBar1.Value = 100;
                progressBar2.Value = 100;

                ProcessButton.Enabled = true;
                ListButton.Enabled = true;
                btnFixGZ.Enabled = true;

                Completed = true;
                Update();
            });
        }

        private void CompleteDownload()
        {
            SafeUpdateUi(() =>
            {
                FileLabel.Text = "已完成...";
                SpeedLabel.Text = "已完成...";
                ActionLabel.Text = "已完成...";

                progressBar1.Value = 100;
                progressBar2.Value = 100;

                DownloadExistingButton.Enabled = true;

                Completed = true;
                Update();
            });
        }

        /// <summary>
        /// 极简版差异对比（100%精准匹配）+ 跳过文件进度显示
        /// </summary>
        private void GenerateSyncLists()
        {
            UploadList = new Queue<FileInformation>();
            DeleteFileList = new List<string>();

            // ========== 1. 初始化对比进度 ==========
            int totalLocalFiles = LocalFileList.Count;
            int currentComparedCount = 0;

            // 设置进度条：对比阶段进度从 扫描阶段的100% 延续，这里重置为对比专用范围
            // 如果前面扫描进度是100%，对比阶段可以占 10% 的总进度占比（根据需要调整）
            SafeUpdateUi(() =>
            {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = totalLocalFiles;
                progressBar1.Value = 0;
                ActionLabel.Text = $"开始对比文件差异，共需对比 {totalLocalFiles} 个文件...";
                Update();
            });

            // ========== 2. 对比本地→服务器：仅上传差异 + 跳过进度 ==========
            foreach (var localFile in LocalFileList)
            {
                currentComparedCount++;
                if (InExcludeList(localFile.FileName)) 
                {
                    // 跳过排除项，也更新进度提示
                    SafeUpdateUi(() =>
                    {
                        int progress = currentComparedCount;
                        progressBar1.Value = progress;
                        ActionLabel.Text = $"跳过（排除项）：{localFile.FileName} （{progress}/{totalLocalFiles}）";
                        Update();
                    });
                    continue;
                }

                // 精准匹配：文件名完全一致（含.gz）+ 大小一致 + 时间误差≤1秒
                var serverFile = ServerFileList.FirstOrDefault(s =>
                    s.FileName.Equals(localFile.FileName, StringComparison.OrdinalIgnoreCase) &&
                    s.Length == localFile.Length &&
                    Math.Abs((s.Creation - localFile.Creation).TotalSeconds) <= 1);

                if (serverFile == null)
                {
                    UploadList.Enqueue(localFile);
                    SafeUpdateUi(() =>
                    {
                        int progress = currentComparedCount;
                        progressBar1.Value = progress;
                        ActionLabel.Text = $"待上传（新增/修改）：{localFile.FileName} （{progress}/{totalLocalFiles}）";
                        Update();
                    });
                }
                else
                {
                    // ========== 核心：跳过无变化文件时显示进度 ==========
                    SafeUpdateUi(() =>
                    {
                        int progress = currentComparedCount;
                        progressBar1.Value = progress;
                        ActionLabel.Text = $"跳过（无变化）：{localFile.FileName} （{progress}/{totalLocalFiles}）";
                        Update();
                    });
                }

                // 节流控制：避免对比速度过快导致UI刷屏（可选，根据需要开启）
                // System.Threading.Thread.Sleep(10);
            }

            // ========== 3. 对比服务器→本地：删除冗余（也可添加进度，可选） ==========
            int totalServerFiles = ServerFileList.Count;
            int currentServerComparedCount = 0;
            SafeUpdateUi(() =>
            {
                progressBar1.Maximum = totalServerFiles;
                progressBar1.Value = 0;
                ActionLabel.Text = $"开始检测冗余文件，共需检测 {totalServerFiles} 个服务器文件...";
                Update();
            });

            foreach (var serverFile in ServerFileList)
            {
                currentServerComparedCount++;
                if (InExcludeList(serverFile.FileName)) continue;

                var localFile = LocalFileList.FirstOrDefault(l =>
                    l.FileName.Equals(serverFile.FileName, StringComparison.OrdinalIgnoreCase));

                if (localFile == null)
                {
                    DeleteFileList.Add(serverFile.FileName);
                }

                // 可选：显示冗余文件检测进度
                SafeUpdateUi(() =>
                {
                    int progress = currentServerComparedCount;
                    progressBar1.Value = progress;
                    ActionLabel.Text = $"检测冗余文件：{serverFile.FileName} （{progress}/{totalServerFiles}）";
                    Update();
                });
            }

            // ========== 4. 对比完成：进度条拉满 + 统计提示 ==========
            SafeUpdateUi(() =>
            {
                progressBar1.Value = progressBar1.Maximum;
                ActionLabel.Text = $"差异分析完成！待上传：{UploadList.Count} | 待删除：{DeleteFileList.Count}";
                Update();
            });

            // 输出统计信息（便于调试）
            MessageBox.Show($"差异分析完成：\n待上传文件数：{UploadList.Count}\n待删除文件数：{DeleteFileList.Count}");
        }

        // 修复CleanUpServerFiles中的进度条逻辑（保持一致）
        private void CleanUpServerFiles()
        {
            var rootPath = new Uri(Settings.Host).AbsolutePath;
            if (!rootPath.EndsWith("/")) rootPath += "/";

            using Session session = new Session();
            OpenSession(session);

            // 初始化：progressBar1=删除阶段进度，progressBar2=总进度
            int totalDelete = DeleteFileList.Count;
            int currentDelete = 0;
            int startTotalProgress = progressBar2.Value; // 总进度起始值

            SafeUpdateUi(() =>
            {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = totalDelete;
                progressBar1.Value = 0;
                ActionLabel.Text = $"准备删除 {totalDelete} 个冗余文件...";
                Update();
            });

            foreach (var fileName in DeleteFileList)
            {
                try
                {
                    currentDelete++;
                    // 核心反转：progressBar1=删除阶段进度，progressBar2=总进度
                    SafeUpdateUi(() =>
                    {
                        progressBar1.Value = currentDelete;
                        // 总进度均分10%（70→80）
                        int totalProgress = startTotalProgress + (int)((double)currentDelete / totalDelete * 10);
                        progressBar2.Value = Math.Min(totalProgress, 100);
                        ActionLabel.Text = $"删除冗余文件：{fileName}（{currentDelete}/{totalDelete}）";
                        Update();
                    });

                    string serverFilePath = Path.Combine(rootPath, fileName).Replace("\\", "/");
                    if (session.FileExists(serverFilePath))
                    {
                        session.RemoveFile(serverFilePath);
                    }
                }
                catch (Exception ex)
                {
                    SafeUpdateUi(() =>
                    {
                        MessageBox.Show($"删除 {fileName} 失败：{ex.Message}", "警告");
                    });
                }
            }

            // 删除完成
            SafeUpdateUi(() =>
            {
                progressBar1.Value = totalDelete;
                progressBar2.Value = startTotalProgress + 10; // 总进度+10%
                ActionLabel.Text = $"冗余文件删除完成，共处理 {currentDelete} 个文件";
                Update();
            });
        }

        /// <summary>
        /// 生成新的PList.gz并上传到服务器 - 修复生成阶段progressBar1进度条更新不明显问题
        /// </summary>
        private void UploadNewPList()
        {
            // 1. 初始化进度条（progressBar1=阶段进度，progressBar2=总进度）
            SafeUpdateUi(() =>
            {
                int currentTotalProgress = progressBar2.Value;
                progressBar2.Minimum = 0;
                progressBar2.Maximum = 100;
                progressBar2.Value = currentTotalProgress;

                // 阶段进度条初始化：强制重置为0，确保从起点开始
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 100;
                progressBar1.Value = 0;
                // 开启进度条平滑滚动（可选，提升视觉效果）
                progressBar1.Step = 1;
                progressBar1.Style = ProgressBarStyle.Continuous;
                
                ActionLabel.Text = "正在生成PList.gz文件...";
                Update();
            });

            // 2. 重新生成PList.gz（核心修复progressBar1进度更新逻辑）
            List<FileInformation> plistList = new List<FileInformation>();
            
            if (string.IsNullOrEmpty(Settings.Client) || !Directory.Exists(Settings.Client))
            {
                SafeUpdateUi(() =>
                {
                    MessageBox.Show("客户端路径无效，无法生成PList.gz！", "错误");
                });
                return;
            }
            
            string clientRoot = Path.GetFullPath(Settings.Client).TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
            string[] files = Directory.GetFiles(Settings.Client, "*.*", SearchOption.AllDirectories);

            int totalFiles = files.Length;
            int startTotalProgress = progressBar2.Value;
            int generateTotalRange = 20; // 生成阶段占总进度20%

            // 无文件时的处理
            if (totalFiles == 0)
            {
                SafeUpdateUi(() =>
                {
                    progressBar1.Value = 100; // 阶段进度直接拉满
                    progressBar2.Value = startTotalProgress + generateTotalRange;
                    ActionLabel.Text = "无本地文件，跳过PList.gz生成...";
                    Update();
                });
            }
            else
            {
                // ========== 核心修复：让progressBar1进度更新更明显 ==========
                // 1. 计算每N个文件更新一次UI（避免刷屏，同时保证进度可见）
                int updateStep = Math.Max(1, totalFiles / 100); // 至少更新100次，保证进度条有明显变化
                int lastUpdatedProgress = -1; // 记录上一次更新的进度值

                for (int currentFile = 0; currentFile < totalFiles; currentFile++)
                {
                    string file = files[currentFile];
                    // 计算阶段进度（0→100），强制取整确保步长明显
                    int stageProgress = (int)Math.Round((double)(currentFile + 1) / totalFiles * 100);
                    // 计算总进度
                    int totalProgress = startTotalProgress + (int)Math.Round((double)(currentFile + 1) / totalFiles * generateTotalRange);

                    // ========== 关键修复：只有进度变化时才更新UI，且强制更新 ==========
                    if (stageProgress != lastUpdatedProgress || currentFile == totalFiles - 1)
                    {
                        lastUpdatedProgress = stageProgress;
                        // 强制更新UI（不使用节流，保证进度可见）
                        SafeUpdateUi(() =>
                        {
                            progressBar1.Value = stageProgress; // 阶段进度条跳变到对应值
                            progressBar2.Value = Math.Min(totalProgress, 100);
                            ActionLabel.Text = $"生成PList.gz：{Path.GetFileName(file)}（{currentFile + 1}/{totalFiles} | {stageProgress}%）";
                            // 强制刷新控件，避免UI卡顿
                            progressBar1.Refresh();
                            ActionLabel.Refresh();
                            Update();
                        });
                    }

                    // 处理当前文件（保留原有逻辑）
                    FileInfo info = new FileInfo(file);
                    string relativePath = file.Replace(clientRoot, "").Replace("/", "\\").TrimStart('\\');
                    if (InExcludeList(relativePath)) continue;

                    byte[] rawData = File.ReadAllBytes(file);
                    int compressedLength = Settings.CompressFiles ? Compress(rawData).Length : (int)info.Length;

                    plistList.Add(new FileInformation
                    {
                        FileName = relativePath,
                        Length = (int)info.Length,
                        Compressed = compressedLength,
                        Creation = info.LastWriteTime
                    });

                    // ========== 移除节流：保证进度更新速度，视觉上更明显 ==========
                    // 仅当文件数超5000时才轻微节流，避免极端场景UI卡死
                    if (totalFiles > 5000 && currentFile % 100 == 0)
                    {
                        System.Threading.Thread.Sleep(1);
                    }
                }

                // 循环结束后强制更新一次：确保进度条拉满，避免最后一步未更新
                SafeUpdateUi(() =>
                {
                    progressBar1.Value = 100;
                    progressBar2.Value = startTotalProgress + generateTotalRange;
                    ActionLabel.Text = $"生成PList.gz完成！共处理 {totalFiles} 个文件";
                    progressBar1.Refresh();
                    Update();
                });
            }

            // 3. 打包PList.gz二进制数据（更新进度）
            SafeUpdateUi(() =>
            {
                int newTotalProgress = Math.Min(progressBar2.Value + 5, 100);
                progressBar2.Value = newTotalProgress;
                progressBar1.Value = 100;
                ActionLabel.Text = "正在打包PList.gz文件...";
                Update();
            });

            using MemoryStream ms = new MemoryStream();
            using BinaryWriter bw = new BinaryWriter(ms);
            bw.Write(plistList.Count);
            foreach (var fi in plistList) fi.Save(bw);
            byte[] plistData = ms.ToArray();

            // 4. 上传PList.gz（保留原有修复逻辑）
            SafeUpdateUi(() =>
            {
                progressBar1.Value = 0;
                progressBar1.Maximum = 100;
                ActionLabel.Text = "开始上传PList.gz...";
                Update();
            });

            // ========== 保留原有临时文件/上传逻辑 ==========
            string tempUploadDir = Path.GetFullPath(TempUploadDirectory);
            if (!Directory.Exists(tempUploadDir))
            {
                Directory.CreateDirectory(tempUploadDir);
            }
            string plistLocalFilePath = Path.Combine(tempUploadDir, PatchFileName);
            File.WriteAllBytes(plistLocalFilePath, plistData);

            if (!File.Exists(plistLocalFilePath))
            {
                SafeUpdateUi(() =>
                {
                    MessageBox.Show($"临时文件生成失败！路径：{plistLocalFilePath}", "错误");
                });
                return;
            }

            Uri hostUri;
            try
            {
                hostUri = new Uri(Settings.Host);
            }
            catch (UriFormatException ex)
            {
                SafeUpdateUi(() =>
                {
                    MessageBox.Show($"服务器地址格式错误：{ex.Message}\n请检查Host配置（如 ftp://192.168.1.1）", "错误");
                });
                return;
            }

            string serverRemotePath = Path.Combine(hostUri.AbsolutePath, PatchFileName).Replace("\\", "/");
            if (!serverRemotePath.StartsWith("/")) serverRemotePath = "/" + serverRemotePath;

            using (Session session = new Session())
            {
                // 上传进度事件（保证progressBar1更新明显）
                session.FileTransferProgress += (o, e) =>
                {
                    SafeUpdateUi(() =>
                    {
                        int uploadStageProgress = (int)Math.Round(e.FileProgress * 100);
                        progressBar1.Value = uploadStageProgress; // 强制取整，进度跳变更明显
                        int uploadBaseProgress = progressBar2.Value;
                        int uploadTotalProgress = uploadBaseProgress + (int)Math.Round(e.OverallProgress * 15);
                        progressBar2.Value = Math.Min(uploadTotalProgress, 100);
                        
                        ActionLabel.Text = $"上传PList.gz：{e.FileName}（{uploadStageProgress}%）";
                        SpeedLabel.Text = ((double)e.CPS / 1024).ToString("0.##") + " KB/s";
                        progressBar1.Refresh(); // 强制刷新
                        Update();
                    });
                };

                // 保留原有Session配置逻辑
                Protocol protocol = GetProtocol(Settings.Protocol);
                int port = hostUri.Port > 0 ? hostUri.Port : (protocol == Protocol.Sftp ? 22 : 21);

                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = protocol,
                    HostName = hostUri.Host,
                    UserName = Settings.Login,
                    Password = Settings.Password,
                    PortNumber = port,
                    Timeout = TimeSpan.FromSeconds(30)
                };

                if (protocol == Protocol.Sftp)
                {
                    try
                    {
                        var prop = sessionOptions.GetType().GetProperty("SshHostKeyPolicy");
                        if (prop != null && prop.PropertyType.Name == "SshHostKeyPolicy")
                        {
                            var policyEnum = Enum.Parse(prop.PropertyType, "AcceptAny");
                            prop.SetValue(sessionOptions, policyEnum);
                        }
                        else
                        {
                            var oldProp = sessionOptions.GetType().GetProperty("GiveUpSecurityAndAcceptAnySshHostKey");
                            if (oldProp != null)
                            {
                                oldProp.SetValue(sessionOptions, true);
                            }
                        }
                    }
                    catch
                    {
                        // 忽略反射失败
                    }
                }

                try
                {
                    session.Open(sessionOptions);

                    TransferOptions transferOptions = new TransferOptions
                    {
                        TransferMode = TransferMode.Binary,
                        OverwriteMode = OverwriteMode.Overwrite,
                        FilePermissions = null,
                        PreserveTimestamp = true
                    };

                    if (string.IsNullOrEmpty(plistLocalFilePath) || string.IsNullOrEmpty(serverRemotePath))
                    {
                        throw new ArgumentNullException("文件路径不能为空！");
                    }

                    TransferOperationResult result = session.PutFiles(plistLocalFilePath, serverRemotePath, false, transferOptions);
                    result.Check();

                    SafeUpdateUi(() =>
                    {
                        MessageBox.Show($"PList.gz上传成功！\n本地路径：{plistLocalFilePath}\n服务器路径：{serverRemotePath}", "成功");
                    });
                }
                catch (Exception ex)
                {
                    SafeUpdateUi(() =>
                    {
                        MessageBox.Show($"PList.gz上传失败：{ex.Message}\n本地路径：{plistLocalFilePath}\n服务器路径：{serverRemotePath}", "错误");
                    });
                    throw;
                }
            }

            // 5. 清理临时文件
            try
            {
                if (File.Exists(plistLocalFilePath))
                {
                    File.Delete(plistLocalFilePath);
                }
                if (Directory.Exists(tempUploadDir) && Directory.GetFiles(tempUploadDir).Length == 0)
                {
                    Directory.Delete(tempUploadDir);
                }
            }
            catch { /* 忽略清理异常 */ }

            // 6. 生成+上传完成
            SafeUpdateUi(() =>
            {
                progressBar1.Value = 100;
                progressBar2.Value = Math.Min(progressBar2.Value + 5, 100);
                ActionLabel.Text = "PList.gz生成+上传完成！";
                Update();
            });
        }
        
        private Protocol GetProtocol(string protocolName)
        {
            if (string.IsNullOrEmpty(protocolName)) return Protocol.Ftp;
            
            string upperProtocol = protocolName.Trim().ToUpper();
            return upperProtocol switch
            {
                "FTP" => Protocol.Ftp,
                "SFTP" => Protocol.Sftp,
                "SCP" => Protocol.Scp,
                _ => Protocol.Ftp
            };
        }

        private void OpenSession(Session session)
        {
            if (session.Opened) return;

            // ========== 修复CS0165：先解析协议和端口，再初始化sessionOptions ==========
            Uri hostUri;
            try
            {
                hostUri = new Uri(Settings.Host);
            }
            catch (UriFormatException)
            {
                // 兼容纯IP/路径格式
                hostUri = new Uri($"ftp://{Settings.Host}");
            }

            // 先获取协议
            Protocol protocol = GetProtocol(Settings.Protocol);
            // 先计算端口
            int port = hostUri.Port > 0 ? hostUri.Port : (protocol == Protocol.Sftp ? 22 : 21);

            // 初始化sessionOptions（所有属性都已提前赋值）
            SessionOptions sessionOptions = new SessionOptions
            {
                Protocol = protocol,
                HostName = hostUri.Host,
                UserName = Settings.Login,
                Password = Settings.Password,
                PortNumber = port,
                Timeout = TimeSpan.FromSeconds(30)
            };

            // ========== 修复CS0117：兼容旧版WinSCP SSH验证 ==========
            if (protocol == Protocol.Sftp)
            {
                try
                {
                    // 新版WinSCP
                    var prop = sessionOptions.GetType().GetProperty("SshHostKeyPolicy");
                    if (prop != null)
                    {
                        var policyEnum = Enum.Parse(prop.PropertyType, "AcceptAny");
                        prop.SetValue(sessionOptions, policyEnum);
                    }
                    else
                    {
                        // 旧版WinSCP
                        var oldProp = sessionOptions.GetType().GetProperty("GiveUpSecurityAndAcceptAnySshHostKey");
                        if (oldProp != null)
                        {
                            oldProp.SetValue(sessionOptions, true);
                        }
                    }
                }
                catch
                {
                    // 忽略异常
                }
            }

            session.Open(sessionOptions);
        }

        /// <summary>
        /// 重构本地文件扫描（生成「上传后预期的服务器文件名」，用于精准匹配）
        /// </summary>
        private void GetLocalFileList()
        {
            LocalFileList = new List<FileInformation>();
            string clientRoot = Path.GetFullPath(Settings.Client).TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;

            string[] files = Directory.GetFiles(Settings.Client, "*.*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                if (!File.Exists(file)) continue;
                FileInfo info = new FileInfo(file);

                // 本地文件的相对路径
                string localRelativePath = file.Replace(clientRoot, "")
                                            .Replace("/", "\\")
                                            .TrimStart('\\')
                                            .TrimEnd('\\');

                // 生成「上传后服务器的文件名」（如果开启压缩，会加.gz后缀）
                string serverExpectedFileName = localRelativePath;
                if (Settings.CompressFiles && !localRelativePath.Equals(PatchFileName, StringComparison.OrdinalIgnoreCase))
                {
                    serverExpectedFileName += ".gz";
                }

                if (InExcludeList(localRelativePath)) continue;

                LocalFileList.Add(new FileInformation
                {
                    FileName = serverExpectedFileName, // 与服务器实际文件名（如file.txt.gz）匹配
                    Length = Settings.CompressFiles ? Compress(File.ReadAllBytes(file)).Length : (int)info.Length, // 上传后的大小
                    Creation = info.LastWriteTime
                });
            }

            // 调试：输出本地文件列表
            MessageBox.Show($"本地扫描结果：共找到 {LocalFileList.Count} 个文件（含压缩后缀）", "调试信息");
        }

        /// <summary>
        /// 获取本地文件信息（优化路径处理，统一格式）
        /// </summary>
        /// <param name="fileName">文件完整路径</param>
        /// <param name="clientRoot">标准化的客户端根路径</param>
        private FileInformation? GetFileInformation(string fileName, string clientRoot = "")
        {
            if (!File.Exists(fileName))
            {
                return null;
            }

            // 标准化客户端根路径（兼容未传入的场景）
            if (string.IsNullOrEmpty(clientRoot))
            {
                clientRoot = Path.GetFullPath(Settings.Client).TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
            }

            FileInfo info = new FileInfo(fileName);

            // 核心修复：统一相对路径格式（全部转为\分隔符，且无开头/结尾多余符号）
            string relativePath = fileName.Replace(clientRoot, "").Replace("/", "\\").TrimStart('\\').TrimEnd('\\');

            FileInformation file = new FileInformation
            {
                FileName = relativePath, // 确保路径格式完全统一
                Length = (int)info.Length,
                Compressed = 0, // 本地文件默认未压缩，上传时再处理
                Creation = info.LastWriteTime
            };

            return file;
        }
        
        /// <summary>
        /// 安全更新UI（带节流控制，避免频繁刷新）
        /// </summary>
        /// <param name="action">UI更新操作</param>
        private void SafeUpdateUi(Action action)
        {
            // 节流控制：100ms内只更新一次UI，减少卡顿
            var now = DateTime.Now;
            if ((now - _lastUiUpdateTime).TotalMilliseconds < _uiUpdateInterval) return;

            // 确保在UI线程执行，且异步执行避免阻塞
            BeginInvoke(new Action(() =>
            {
                try
                {
                    action.Invoke();
                    _lastUiUpdateTime = now;
                }
                catch { /* 忽略UI更新异常，避免影响核心逻辑 */ }
            }));
        }

        private void GetOldFileList()
        {
            OldList = new List<FileInformation>();

            byte[] data = DownloadFile(PatchFileName);

            if (data != null)
            {
                using MemoryStream stream = new MemoryStream(data);
                using BinaryReader reader = new BinaryReader(stream);

                int count = reader.ReadInt32();

                for (int i = 0; i < count; i++)
                {
                    OldList.Add(new FileInformation(reader));
                }
            }
        }

        private byte[] CreateNewList()
        {
            using MemoryStream stream = new MemoryStream();
            using BinaryWriter writer = new BinaryWriter(stream);

            writer.Write(NewList.Count);
            for (int i = 0; i < NewList.Count; i++)
            {
                NewList[i].Save(writer);
            }

            return stream.ToArray();
        }

        private void GetNewFileList()
        {
            NewList = new List<FileInformation>();

            string[] files = Directory.GetFiles(Settings.Client, "*.*" ,SearchOption.AllDirectories);

            for (int i = 0; i < files.Length; i++)
            {
                var fileInfo = GetFileInformation(files[i]);
                if (fileInfo != null)
                {
                    NewList.Add(fileInfo);
                }
            }
        }

        private bool InExcludeList(string fileName)
        {
            foreach (var item in ExcludeList)
            {
                if (fileName.EndsWith(item)) return true;
            }

            return false;
        }

        private void FixFilenameExtensions()
        {
            var rootPath = (new Uri(Settings.Host)).AbsolutePath;

            using Session session = new Session();
            OpenSession(session);

            for (int i = 0; i < OldList.Count; i++)
            {
                FileInformation old = OldList[i];

                try
                {
                    ActionLabel.Text = old.FileName;
                    Refresh();

                    if (old.Compressed == old.Length)
                    {
                        //exists, but not compressed, lets rename it

                        var compressedFilename = OldList[i].FileName + ".gz";
                        var compressedFilePath = Path.Combine(rootPath, compressedFilename).Replace(@"\", "/");

                        var uncompressedFilename = OldList[i].FileName;
                        var uncompressedFilePath = Path.Combine(rootPath, compressedFilename).Replace(@"\", "/");

                        if (session.FileExists(compressedFilePath))
                        {
                            session.MoveFile(compressedFilePath, uncompressedFilename);
                        }
                    }
                    else
                    {
                        //exists, but its compressed and ends with .gz, so its correct
                    }
                }
                catch
                {

                }
            }
        }

        private bool NeedUpdate(FileInformation info)
        {
            for (int i = 0; i < OldList.Count; i++)
            {
                FileInformation old = OldList[i];
                if (old.FileName != info.FileName) continue;

                if (old.Length != info.Length) return true;
                if (old.Creation != info.Creation) return true;

                return false;
            }
            return true;
        }

        private FileInformation? GetFileInformation(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }

            FileInfo info = new(fileName);

            FileInformation file =  new()
            {
                FileName = fileName.Remove(0, Settings.Client.Length).TrimStart('\\'),
                Length = (int)info.Length,
                Creation = info.LastWriteTime
            };

            return file;
        }

        private void BeginUpload()
        {
            if (UploadList == null || UploadList.Count == 0) return;

            progressBar1.Value = 0;
            progressBar2.Value = 0;

            int totalFiles = UploadList.Count;
            int uploadedFiles = 0;

            while (UploadList.Count > 0)
            {
                FileInformation info = UploadList.Dequeue();

                string filePath = Settings.Client + info.FileName;
                if (!File.Exists(filePath)) continue;

                byte[] fileData = File.ReadAllBytes(filePath);
                CreateTempUploadFiles(info, fileData);

                uploadedFiles++;
                int progress = (int)((double)uploadedFiles / totalFiles * 100);
                progressBar1.Value = progress;
                progressBar2.Value = progress;
            }

            CreateTempUploadFiles(new FileInformation { FileName = PatchFileName }, CreateNewList());
            UploadFiles(totalFiles);

            UploadList.Clear();
            ActionLabel.Text = "上传完成！";
        }

        private void CreateTempUploadFiles(FileInformation info, byte[] raw)
        {
            string fileName = info.FileName.Replace(@"\", "/");

            byte[] data = (!Settings.CompressFiles || fileName == "PList.gz") ? raw : Compress(raw);
            info.Compressed = data.Length;

            if (fileName != "PList.gz" && Settings.CompressFiles)
            {
                fileName += ".gz";
            }

            var sourceDir = Path.GetDirectoryName(fileName) ?? string.Empty;
            var tempSourceDir = Path.Combine(TempUploadDirectory, sourceDir);

            var tempFilePath = Path.Combine(TempUploadDirectory, fileName).Replace(@"\", "/");

            if (!Directory.Exists(tempSourceDir))
            {
                Directory.CreateDirectory(tempSourceDir);
            }

            File.WriteAllBytes(tempFilePath, data);
            File.SetLastWriteTime(tempFilePath, info.Creation);
        }

        private void UploadFiles(int uploadCount = 0)
        {
            var rootPath = (new Uri(Settings.Host)).AbsolutePath;

            using Session session = new Session();

            session.FileTransferProgress += (o, e) =>
            {
                // ========== 优化上传进度UI更新 ==========
                SafeUpdateUi(() =>
                {
                    int overallProgress = (int)(e.OverallProgress * 100);
                    progressBar1.Value = Math.Min(overallProgress, 100);

                    int fileProgress = (int)(e.FileProgress * 100);
                    progressBar2.Value = Math.Min(fileProgress, 100);

                    FileLabel.Text = e.FileName.TrimStart(TempUploadDirectory.ToCharArray()).TrimStart('\\');
                    SpeedLabel.Text = ((double)e.CPS / 1024).ToString("0.##") + " KB/s";
                    ActionLabel.Text = string.Format("上传中... 文件数量: {0}", uploadCount);

                    Update(); // 轻量更新，替代Refresh()
                });
            };

            session.FileTransferred += (o, e) =>
            {
                uploadCount--;

                if (uploadCount <= 0)
                {
                    uploadCount = 0;
                    CompleteUpload();
                }
            };

            OpenSession(session);

            TransferOptions transferOptions = new TransferOptions
            {
                TransferMode = TransferMode.Binary,
                OverwriteMode = OverwriteMode.Overwrite
            };

            if (!session.FileExists(rootPath))
            {
                session.CreateDirectory(rootPath);
            }

            var result = session.PutFilesToDirectory(TempUploadDirectory, rootPath, options: transferOptions);
            result.Check();

            DeleteDirectory(TempUploadDirectory);
        }
        
        private byte[]? DownloadFile(string fileName)
        {
            using Session session = new Session();
            OpenSession(session);

            try
            {
                if (!Directory.Exists(TempDownloadDirectory))
                {
                    Directory.CreateDirectory(TempDownloadDirectory);
                }

                TransferOptions transferOptions = new TransferOptions
                {
                    TransferMode = TransferMode.Binary,
                    OverwriteMode = OverwriteMode.Overwrite
                };

                var rootPath = (new Uri(Settings.Host)).AbsolutePath;

                var result = session.GetFiles(Path.Combine(rootPath, fileName), Path.Combine(TempDownloadDirectory, fileName), options: transferOptions);
                result.Check();

                MemoryStream ms = new MemoryStream();
                using (FileStream fs = new FileStream(Path.Combine(TempDownloadDirectory, fileName), FileMode.Open, FileAccess.Read))
                    fs.CopyTo(ms);

                DeleteDirectory(TempDownloadDirectory);

                return ms.ToArray();
            }
            catch
            {
                return null;
            }
        }

        private void DownloadFiles()
        {
            var rootPath = (new Uri(Settings.Host)).AbsolutePath;

            using Session session = new Session();

            session.FileTransferProgress += (o, e) =>
            {
                int value = (int)(e.OverallProgress * 100);
                progressBar1.Value = value > progressBar1.Maximum ? progressBar1.Maximum : value;

                int value2 = (int)(e.FileProgress * 100);
                progressBar2.Value = value2 > progressBar2.Maximum ? progressBar2.Maximum : value2;

                FileLabel.Text = e.FileName.Replace(rootPath, "");
                SpeedLabel.Text = ((double)e.CPS / 1024).ToString("0.##") + " KB/s";

                ActionLabel.Text = "下载... 文件";
            };

            session.FileTransferred += (o, e) =>
            {

            };

            OpenSession(session);

            TransferOptions transferOptions = new TransferOptions
            {
                TransferMode = TransferMode.Binary,
                OverwriteMode = OverwriteMode.Overwrite
            };

            if (!Directory.Exists(TempDownloadDirectory))
            {
                Directory.CreateDirectory(TempDownloadDirectory);
            }

            var result = session.GetFilesToDirectory(rootPath, TempDownloadDirectory, options: transferOptions);
            result.Check();

            CompleteDownload();
        }

        private void MoveTempDownloadedFiles()
        {
            for (int i = 0; i < OldList.Count; i++)
            {
                var info = OldList[i];
                var compressed = OldList[i].Length != OldList[i].Compressed;
                var filename = OldList[i].FileName + (compressed ? ".gz" : "");

                var currentPath = Path.Combine(TempDownloadDirectory, filename);

                var relativeDestDir = Path.GetDirectoryName(info.FileName) ?? string.Empty;
                var destDir = Path.Combine(Settings.Client, relativeDestDir);
                var destFilename = Path.Combine(Settings.Client, info.FileName);

                if (!Directory.Exists(destDir))
                {
                    Directory.CreateDirectory(destDir);
                }

                if (File.Exists(destFilename))
                {
                    File.Delete(destFilename);
                }

                if (compressed)
                {
                    byte[] raw = File.ReadAllBytes(currentPath);

                    File.WriteAllBytes(destFilename, Decompress(raw));
                }
                else
                {
                    File.Move(currentPath, destFilename);
                }

                File.SetLastWriteTime(destFilename, info.Creation);
            }

            DeleteDirectory(TempDownloadDirectory);
        }

        private void ListButton_Click(object sender, EventArgs e)
        {
            try
            {
                ListButton.Enabled = false;

                if (string.IsNullOrWhiteSpace(ClientTextBox.Text) || !Directory.Exists(ClientTextBox.Text))
                {
                    ListButton.Enabled = true;
                    MessageBox.Show("客户端路径无效，请检查输入！");
                    return;
                }

                Settings.Client = ClientTextBox.Text;
                Settings.Host = HostTextBox.Text;
                Settings.Login = LoginTextBox.Text;
                Settings.Password = PasswordTextBox.Text;
                Settings.Protocol = ProtocolDropDown.SelectedItem?.ToString() ?? string.Empty;

                GetOldFileList();
                GetNewFileList();

                for (int i = 0; i < NewList.Count; i++)
                {
                    FileInformation info = NewList[i];
                    for (int o = 0; o < OldList.Count; o++)
                    {
                        if (OldList[o].FileName != info.FileName) continue;

                        NewList[i].Compressed = OldList[o].Compressed;
                        break;
                    }

                    if (info.Compressed == 0)
                    {
                        //We've uploaded a new file which is unknown to the existing PList (or no PList available). Assume this file was uploaded uncompressed and set to file length.
                        info.Compressed = info.Length;
                    }
                }

                CreateTempUploadFiles(new FileInformation { FileName = PatchFileName }, CreateNewList());
                UploadFiles(1);
            }
            catch (Exception ex)
            {
                ListButton.Enabled = true;
                MessageBox.Show(ex.ToString());
                ActionLabel.Text = "错误...";
            }
        }

        private async void ProcessButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ClientTextBox.Text) || !Directory.Exists(ClientTextBox.Text))
                {
                    MessageBox.Show("客户端路径无效，请检查输入！");
                    return;
                }

                // 调用异步同步逻辑
                await Task.Run(() => RebuildSyncLogic());
            }
            catch (Exception ex)
            {
                ProcessButton.Enabled = true;
                MessageBox.Show(ex.ToString());
                ActionLabel.Text = "错误...";
            }
        }

        private void BtnFixGZ_Click(object sender, EventArgs e)
        {
            try
            {
                btnFixGZ.Enabled = false;

                if (string.IsNullOrWhiteSpace(ClientTextBox.Text) || !Directory.Exists(ClientTextBox.Text))
                {
                    btnFixGZ.Enabled = true;
                    MessageBox.Show("客户端路径无效，请检查输入！");
                    return;
                }

                Settings.Client = ClientTextBox.Text;
                Settings.Host = HostTextBox.Text;
                Settings.Login = LoginTextBox.Text;
                Settings.Password = PasswordTextBox.Text;
                Settings.Protocol = ProtocolDropDown.SelectedItem?.ToString() ?? string.Empty;

                GetOldFileList();
                GetNewFileList();

                for (int i = 0; i < NewList.Count; i++)
                {
                    FileInformation info = NewList[i];
                    for (int o = 0; o < OldList.Count; o++)
                    {
                        if (OldList[o].FileName != info.FileName) continue;
                        NewList[i].Compressed = OldList[o].Length;
                        break;
                    }
                }

                CreateTempUploadFiles(new FileInformation { FileName = PatchFileName }, CreateNewList());
                UploadFiles(1);

                FixFilenameExtensions();
            }
            catch (Exception ex)
            {
                btnFixGZ.Enabled = true;
                MessageBox.Show(ex.ToString(), "Error");
                ActionLabel.Text = "错误...";
            }
        }

        private void DownloadExistingButton_Click(object sender, EventArgs e)
        {
            try
            {
                DownloadExistingButton.Enabled = false;

                if (string.IsNullOrWhiteSpace(ClientTextBox.Text) || !Directory.Exists(ClientTextBox.Text))
                {
                    DownloadExistingButton.Enabled = true;
                    MessageBox.Show("客户端路径无效，请检查输入！");
                    return;
                }

                Settings.Client = ClientTextBox.Text;
                Settings.Host = HostTextBox.Text;
                Settings.Login = LoginTextBox.Text;
                Settings.Password = PasswordTextBox.Text;
                Settings.AllowCleanUp = AllowCleanCheckBox.Checked;
                Settings.Protocol = ProtocolDropDown.SelectedItem?.ToString() ?? string.Empty;

                GetOldFileList();
                DownloadFiles();
                MoveTempDownloadedFiles();
            }
            catch (Exception ex)
            {
                DownloadExistingButton.Enabled = true;
                MessageBox.Show(ex.ToString(), "Error");
                ActionLabel.Text = "错误...";
            }
        }

        private void AMain_Load(object sender, EventArgs e)
        {

        }

        private void DeleteDirectory(string target_dir)
        {
            if (!Directory.Exists(target_dir)) return;

            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }

        private byte[] Decompress(byte[] raw)
        {
            using (GZipStream gStream = new GZipStream(new MemoryStream(raw), CompressionMode.Decompress))
            {
                const int size = 4096; //4kb
                byte[] buffer = new byte[size];
                using (MemoryStream mStream = new MemoryStream())
                {
                    int count;
                    do
                    {
                        count = gStream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            mStream.Write(buffer, 0, count);
                        }
                    } while (count > 0);
                    return mStream.ToArray();
                }
            }
        }

        private byte[] Compress(byte[] raw)
        {
            using (MemoryStream mStream = new MemoryStream())
            {
                using (GZipStream gStream = new GZipStream(mStream, CompressionMode.Compress, true))
                    gStream.Write(raw, 0, raw.Length);
                return mStream.ToArray();
            }
        }
    }

    public class FileInformation
    {
        public string FileName; //Relative.
        public int Length, Compressed;
        public DateTime Creation;

        public FileInformation()
        {
            Creation = DateTime.Now;
        }
        public FileInformation(BinaryReader reader)
        {
            FileName = reader.ReadString();
            Length = reader.ReadInt32();
            Compressed = reader.ReadInt32();
            Creation = DateTime.FromBinary(reader.ReadInt64());
        }
        public void Save(BinaryWriter writer)
        {
            writer.Write(FileName);
            writer.Write(Length);
            writer.Write(Compressed);
            writer.Write(Creation.ToBinary());
        }
    }
}
