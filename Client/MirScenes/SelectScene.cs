using Client.MirControls;
using Client.MirGraphics;
using Client.MirNetwork;
using Client.MirScenes.Dialogs;
using Client.MirSounds;
using C = ClientPackets;
using S = ServerPackets;
namespace Client.MirScenes
{
    public class SelectScene : MirScene
    {
        public MirImageControl Background, Title;
        private NewCharacterDialog _character;

        public MirLabel ServerLabel;
        public MirAnimatedControl CharacterDisplay;
        public MirButton StartGameButton, NewCharacterButton, DeleteCharacterButton, CreditsButton, ExitGame;
        public CharacterButton[] CharacterButtons;
        public MirLabel LastAccessLabel, LastAccessLabelLabel;
        public List<SelectInfo> Characters = new List<SelectInfo>();
        private int _selected;

        public SelectScene(List<SelectInfo> characters)
        {
            SoundManager.PlayMusic(SoundList.SelectMusic, true);
            Disposing += (o, e) => SoundManager.StopMusic();

            Characters = characters;
            SortList();

            KeyPress += SelectScene_KeyPress;

            Background = new MirImageControl
            {
                Index = 65,
                Library = Libraries.Prguse,
                Parent = this,
            };

            Title = new MirImageControl
            {
                Index = 40,
                Library = Libraries.Title,
                Parent = this,
                Location = new Point(468, 20)
            };

            ServerLabel = new MirLabel
            {
                Location = new Point(432, 60),
                // Location = new Point(322, 44),
                Parent = Background,
                Size = new Size(155, 17),
                Text = GameLanguage.ClientTextMap.GetLocalization(ClientTextKeys.GameName),
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            };

            var xPoint = ((Settings.ScreenWidth - 200) / 5);

            StartGameButton = new MirButton
            {
                Enabled = false,
                HoverIndex = 341,
                Index = 340,
                Library = Libraries.Title,
                Location = new Point(100 + (xPoint * 1) - (xPoint / 2) - 50, Settings.ScreenHeight - 32),
                Parent = Background,
                PressedIndex = 342
            };
            StartGameButton.Click += (o, e) => StartGame();

            NewCharacterButton = new MirButton
            {
                HoverIndex = 344,
                Index = 343,
                Library = Libraries.Title,
                Location = new Point(100 + (xPoint * 2) - (xPoint / 2) - 50, Settings.ScreenHeight - 32),
                Parent = Background,
                PressedIndex = 345,
            };
            NewCharacterButton.Click += (o, e) => OpenNewCharacterDialog();

            DeleteCharacterButton = new MirButton
            {
                HoverIndex = 347,
                Index = 346,
                Library = Libraries.Title,
                Location = new Point(100 + (xPoint * 3) - (xPoint / 2) - 50, Settings.ScreenHeight - 32),
                Parent = Background,
                PressedIndex = 348
            };
            DeleteCharacterButton.Click += (o, e) => DeleteCharacter();


            CreditsButton = new MirButton
            {
                HoverIndex = 350,
                Index = 349,
                Library = Libraries.Title,
                Location = new Point(100 + (xPoint * 4) - (xPoint / 2) - 50, Settings.ScreenHeight - 32),
                Parent = Background,
                PressedIndex = 351
            };
            CreditsButton.Click += (o, e) =>
            {

            };

            ExitGame = new MirButton
            {
                HoverIndex = 353,
                Index = 352,
                Library = Libraries.Title,
                Location = new Point(100 + (xPoint * 5) - (xPoint / 2) - 50, Settings.ScreenHeight - 32),
                Parent = Background,
                PressedIndex = 354
            };
            ExitGame.Click += (o, e) => Program.Form.Close();


            CharacterDisplay = new MirAnimatedControl
            {
                Animated = true,
                AnimationCount = 16,
                AnimationDelay = 250,
                FadeIn = true,
                FadeInDelay = 75,
                FadeInRate = 0.1F,
                Index = 220,
                Library = Libraries.ChrSel,
                Location = new Point(260, 420),
                Parent = Background,
                UseOffSet = true,
                Visible = false
            };
            CharacterDisplay.AfterDraw += (o, e) =>
            {
                // if (_selected >= 0 && _selected < Characters.Count && characters[_selected].Class == MirClass.法师)
                Libraries.ChrSel.DrawBlend(CharacterDisplay.Index + 560, CharacterDisplay.DisplayLocationWithoutOffSet, Color.White, true);
            };

            CharacterButtons = new CharacterButton[4];

            CharacterButtons[0] = new CharacterButton
            {
                Location = new Point(637, 194),
                Parent = Background,
                Sound = SoundList.ButtonA,
            };
            CharacterButtons[0].Click += (o, e) =>
            {
                if (characters.Count <= 0) return;

                _selected = 0;
                UpdateInterface();
            };

            CharacterButtons[1] = new CharacterButton
            {
                Location = new Point(637, 298),
                Parent = Background,
                Sound = SoundList.ButtonA,
            };
            CharacterButtons[1].Click += (o, e) =>
            {
                if (characters.Count <= 1) return;
                _selected = 1;
                UpdateInterface();
            };

            CharacterButtons[2] = new CharacterButton
            {
                Location = new Point(637, 402),
                Parent = Background,
                Sound = SoundList.ButtonA,
            };
            CharacterButtons[2].Click += (o, e) =>
            {
                if (characters.Count <= 2) return;

                _selected = 2;
                UpdateInterface();
            };

            CharacterButtons[3] = new CharacterButton
            {
                Location = new Point(637, 506),
                Parent = Background,
                Sound = SoundList.ButtonA,
            };
            CharacterButtons[3].Click += (o, e) =>
            {
                if (characters.Count <= 3) return;

                _selected = 3;
                UpdateInterface();
            };

            LastAccessLabel = new MirLabel
            {
                Location = new Point(265, 611),
                Parent = Background,
                Size = new Size(180, 21),
                DrawFormat = TextFormatFlags.Left | TextFormatFlags.VerticalCenter,
                Border = true,
            };
            LastAccessLabelLabel = new MirLabel
            {
                Location = new Point(-65, 0),
                Parent = LastAccessLabel,
                Text = GameLanguage.ClientTextMap.GetLocalization(ClientTextKeys.LastOnlineTitle),
                Size = new Size(100, 21),
                DrawFormat = TextFormatFlags.Left | TextFormatFlags.VerticalCenter,
                Border = true,
            };
            UpdateInterface();
        }

        private void SelectScene_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;
            if (StartGameButton.Enabled)
                StartGame();
            e.Handled = true;
        }


        public void SortList()
        {
            if (Characters != null)
                Characters.Sort((c1, c2) => c2.LastAccess.CompareTo(c1.LastAccess));
        }

        private void OpenNewCharacterDialog()
        {
            if (_character == null || _character.IsDisposed)
            {
                _character = new NewCharacterDialog { Parent = this };

                _character.OnCreateCharacter += (o, e) =>
                {
                    Network.Enqueue(new C.NewCharacter
                    {
                        Name = _character.NameTextBox.Text,
                        Class = _character.Class,
                        Gender = _character.Gender
                    });
                };
            }

            _character.Show();
        }

        /// <summary>
        /// 开始游戏的逻辑
        /// </summary>
        public long delayDisplay = CMain.Time + 6000;
        public void StartGame()
        {
            if (!Libraries.Loaded || delayDisplay > CMain.Time)
            {
                Random random = new Random();//随机动画载入构建
                MirImageControl loadingOverlay = new MirImageControl
                {
                    Library = Libraries.Prguse, // 图片资源库
                    Index = 930 + random.Next(0, 10), //载入的随机图片总数量
                    Visible = true, // 显示控件
                    Parent = this // 设置父控件为当前场景

                };
                MirAnimatedControl loadProgress = new MirAnimatedControl // 创建加载进度动画控件
                {
                    Library = Libraries.Prguse, // 图片资源库
                    Index = 940,  //载入的动画图片-loading动画起始号
                    Visible = true, // 显示控件
                    Parent = loadingOverlay,
                    Location = new Point(599, 700), // 控件位置
                    Animated = true, // 启用动画
                    AnimationCount = 9,   // 动画延迟时间
                    AnimationDelay = 100,  // 动画延迟时间
                    Loop = true, // 循环播放动画
                };
                loadProgress.AfterDraw += (o, e) =>
                {
                    if (!Libraries.Loaded || delayDisplay > CMain.Time) return;
                    loadProgress.Dispose();
                    StartGame();
                };
                return;
            }
            StartGameButton.Enabled = false;

            Network.Enqueue(new C.StartGame
            {
                CharacterIndex = Characters[_selected].Index
            });
        }

        public override void Process()
        {


        }
        public override void ProcessPacket(Packet p)
        {
            switch (p.Index)
            {
                case (short)ServerPacketIds.NewCharacter:
                    NewCharacter((S.NewCharacter)p);
                    break;
                case (short)ServerPacketIds.NewCharacterSuccess:
                    NewCharacter((S.NewCharacterSuccess)p);
                    break;
                case (short)ServerPacketIds.DeleteCharacter:
                    DeleteCharacter((S.DeleteCharacter)p);
                    break;
                case (short)ServerPacketIds.DeleteCharacterSuccess:
                    DeleteCharacter((S.DeleteCharacterSuccess)p);
                    break;
                case (short)ServerPacketIds.StartGame:
                    StartGame((S.StartGame)p);
                    break;
                case (short)ServerPacketIds.StartGameBanned:
                    StartGame((S.StartGameBanned)p);
                    break;
                case (short)ServerPacketIds.StartGameDelay:
                    StartGame((S.StartGameDelay)p);
                    break;
                default:
                    base.ProcessPacket(p);
                    break;
            }
        }

        private void NewCharacter(S.NewCharacter p)
        {
            _character.OKButton.Enabled = true;

            switch (p.Result)
            {
                case 0:
                    MirMessageBox.Show(GameLanguage.ClientTextMap.GetLocalization(ClientTextKeys.CreatingNewCharactersDisabled));
                    _character.Dispose();
                    break;
                case 1:
                    MirMessageBox.Show(GameLanguage.ClientTextMap.GetLocalization(ClientTextKeys.YourCharacterNameNotAcceptable));
                    _character.NameTextBox.SetFocus();
                    break;
                case 2:
                    MirMessageBox.Show(GameLanguage.ClientTextMap.GetLocalization(ClientTextKeys.GenderNotExistContactGM));
                    break;
                case 3:
                    MirMessageBox.Show(GameLanguage.ClientTextMap.GetLocalization(ClientTextKeys.ClassNotExistContactGM));
                    break;
                case 4:
                    MirMessageBox.Show(GameLanguage.ClientTextMap.GetLocalization((ClientTextKeys.YouCannotMakeMoreCharacters), Globals.MaxCharacterCount));
                    _character.Dispose();
                    break;
                case 5:
                    MirMessageBox.Show(GameLanguage.ClientTextMap.GetLocalization(ClientTextKeys.CharacterNameExists));
                    _character.NameTextBox.SetFocus();
                    break;
            }
        }
        private void NewCharacter(S.NewCharacterSuccess p)
        {
            _character.Dispose();
            MirMessageBox.Show(GameLanguage.ClientTextMap.GetLocalization(ClientTextKeys.YourCharacterCreatedSuccessfully));

            Characters.Insert(0, p.CharInfo);
            _selected = 0;
            UpdateInterface();
        }

        private void DeleteCharacter()
        {
            if (_selected < 0 || _selected >= Characters.Count) return;

            MirMessageBox message = new MirMessageBox(GameLanguage.ClientTextMap.GetLocalization((ClientTextKeys.ConfirmDeleteCharacter), Characters[_selected].Name), MirMessageBoxButtons.YesNo);
            int index = Characters[_selected].Index;

            message.YesButton.Click += (o1, e1) =>
            {
                MirInputBox inputBox = new MirInputBox(GameLanguage.ClientTextMap.GetLocalization(ClientTextKeys.PleaseEnterCharacterName));
                inputBox.OKButton.Click += (o, e) =>
                {
                    string name = Characters[_selected].Name.ToString();

                    if (inputBox.InputTextBox.Text == name)
                    {
                        DeleteCharacterButton.Enabled = false;
                        Network.Enqueue(new C.DeleteCharacter { CharacterIndex = index });
                    }
                    else
                    {
                        MirMessageBox failedMessage = new MirMessageBox(GameLanguage.ClientTextMap.GetLocalization(ClientTextKeys.IncorrectEntry), MirMessageBoxButtons.OK);
                        failedMessage.Show();
                    }
                    inputBox.Dispose();
                };
                inputBox.Show();
            };
            message.Show();
        }

        private void DeleteCharacter(S.DeleteCharacter p)
        {
            DeleteCharacterButton.Enabled = true;
            switch (p.Result)
            {
                case 0:
                    MirMessageBox.Show(GameLanguage.ClientTextMap.GetLocalization(ClientTextKeys.DeletingCharactersDisabled));
                    break;
                case 1:
                    MirMessageBox.Show(GameLanguage.ClientTextMap.GetLocalization(ClientTextKeys.SelectedCharacterNotExist));
                    break;
            }
        }
        private void DeleteCharacter(S.DeleteCharacterSuccess p)
        {
            DeleteCharacterButton.Enabled = true;
            MirMessageBox.Show(GameLanguage.ClientTextMap.GetLocalization(ClientTextKeys.YourCharacterDeletedSuccessfully));

            for (int i = 0; i < Characters.Count; i++)
                if (Characters[i].Index == p.CharacterIndex)
                {
                    Characters.RemoveAt(i);
                    break;
                }

            UpdateInterface();
        }

        private void StartGame(S.StartGameDelay p)
        {
            StartGameButton.Enabled = true;

            long time = CMain.Time + p.Milliseconds;

            MirMessageBox message = new MirMessageBox(GameLanguage.ClientTextMap.GetLocalization((ClientTextKeys.CannotLoginCharacterSeconds), Math.Ceiling(p.Milliseconds / 1000M)));

            message.BeforeDraw += (o, e) => message.Label.Text = GameLanguage.ClientTextMap.GetLocalization((ClientTextKeys.CannotLoginCharacterSeconds), Math.Ceiling((time - CMain.Time) / 1000M));


            message.AfterDraw += (o, e) =>
            {
                if (CMain.Time <= time) return;
                message.Dispose();
                StartGame();
            };

            message.Show();
        }

        /// <summary>
        /// 处理开始游戏被封禁的响应
        /// </summary>
        /// <param name="p">开始游戏被封禁响应数据包</param>
        public void StartGame(S.StartGameBanned p)
        {
            // 启用开始游戏按钮
            StartGameButton.Enabled = true;

            // 计算封禁剩余时间
            TimeSpan d = p.ExpiryDate - CMain.Now;
            // 显示账户被封禁的提示框
            MirMessageBox.Show(GameLanguage.ClientTextMap.GetLocalization((ClientTextKeys.AccountBannedReasonExpiryDuration), p.Reason,
                                             p.ExpiryDate, Math.Floor(d.TotalHours), d.Minutes, d.Seconds));
        }

        /// <summary>
        /// 处理开始游戏请求的响应
        /// </summary>
        /// <param name="p">开始游戏响应数据包</param>
        public void StartGame(S.StartGame p)
        {
            // 启用开始游戏按钮
            StartGameButton.Enabled = true;

            switch (p.Result)
            {
                case 0:
                    // 服务器维护禁止登录
                    MirMessageBox.Show(GameLanguage.ClientTextMap.GetLocalization(ClientTextKeys.StartingGameDisabled));
                    break;
                case 1:
                    MirMessageBox.Show(GameLanguage.ClientTextMap.GetLocalization(ClientTextKeys.YouNotLoggedIn));
                    break;
                case 2:
                    // 没有激活角色
                    MirMessageBox.Show(GameLanguage.ClientTextMap.GetLocalization(ClientTextKeys.YourCharacterNotFound));
                    break;
                case 3:
                    // 无效地图或没有新手出生点
                    MirMessageBox.Show(GameLanguage.ClientTextMap.GetLocalization(ClientTextKeys.NoActiveMapOrStartPointFound));
                    break;
                case 4:

                    if (p.Resolution < Settings.Resolution || Settings.Resolution == 0) Settings.Resolution = p.Resolution;

                    switch (Settings.Resolution)
                    {
                        default:
                        case 1024:
                            Settings.Resolution = 1024;
                            CMain.SetResolution(1024, 768);
                            break;
                        case 1280:
                            CMain.SetResolution(1280, 800);
                            break;
                        case 1366:
                            CMain.SetResolution(1366, 768);
                            break;
                        case 1920:
                            CMain.SetResolution(1920, 1080);
                            break;
                    }

                    ActiveScene = new GameScene();
                    Dispose();
                    break;
            }
        }
        /// <summary>
        /// 更新界面显示，根据当前选中的角色更新角色选择按钮、角色显示动画和上次登录时间标签
        /// </summary>
        private void UpdateInterface()
        {
            // 遍历角色选择按钮数组，更新按钮的选中状态和显示信息
            for (int i = 0; i < CharacterButtons.Length; i++)
            {
                CharacterButtons[i].Selected = i == _selected;
                CharacterButtons[i].Update(i >= Characters.Count ? null : Characters[i]);
            }

            // 如果当前有选中角色
            if (_selected >= 0 && _selected < Characters.Count)
            {
                // 显示角色显示动画控件
                CharacterDisplay.Visible = true;
                //CharacterDisplay.Index = ((byte)Characters[_selected].Class + 1) * 20 + (byte)Characters[_selected].Gender * 280; 
                // 根据角色职业和性别设置角色显示动画的图片索引
                switch ((MirClass)Characters[_selected].Class)
                {
                    case MirClass.战士:
                        CharacterDisplay.Index = (byte)Characters[_selected].Gender == 0 ? 20 : 300; //220 : 500;
                        break;
                    case MirClass.法师:
                        CharacterDisplay.Index = (byte)Characters[_selected].Gender == 0 ? 40 : 320; //240 : 520;
                        break;
                    case MirClass.道士:
                        CharacterDisplay.Index = (byte)Characters[_selected].Gender == 0 ? 60 : 340; //260 : 540;
                        break;
                    case MirClass.刺客:
                        CharacterDisplay.Index = (byte)Characters[_selected].Gender == 0 ? 80 : 360; //280 : 560;
                        break;
                    case MirClass.弓箭:
                        CharacterDisplay.Index = (byte)Characters[_selected].Gender == 0 ? 100 : 140; //160 : 180;
                        break;
                }

                // 显示上次登录时间，如果角色未曾登录则显示 "未曾登录"
                LastAccessLabel.Text = Characters[_selected].LastAccess == DateTime.MinValue ? GameLanguage.ClientTextMap.GetLocalization(ClientTextKeys.Never) : Characters[_selected].LastAccess.ToString("yyyy/MM/dd HH:mm:ss");
                // 显示上次登录时间标签和其标题标签
                LastAccessLabel.Visible = true;
                LastAccessLabelLabel.Visible = true;
                // 启用开始游戏按钮
                StartGameButton.Enabled = true;
            }
            else
            {
                // 隐藏角色显示动画控件
                CharacterDisplay.Visible = false;
                // 隐藏上次登录时间标签和其标题标签
                LastAccessLabel.Visible = false;
                LastAccessLabelLabel.Visible = false;
                // 禁用开始游戏按钮
                StartGameButton.Enabled = false;
            }
        }


        #region Disposable
        /// <summary>
        /// 释放资源的方法
        /// </summary>
        /// <param name="disposing">是否释放托管资源</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // 释放背景图片控件
                Background = null;
                // 释放新建角色对话框
                _character = null;

                // 释放服务器标签控件
                ServerLabel = null;
                // 释放角色显示动画控件
                CharacterDisplay = null;
                // 释放开始游戏按钮
                StartGameButton = null;
                // 释放新建角色按钮
                NewCharacterButton = null;
                // 释放删除角色按钮
                DeleteCharacterButton = null;
                // 释放显示信息按钮
                CreditsButton = null;
                // 释放退出游戏按钮
                ExitGame = null;
                // 释放角色选择按钮数组
                CharacterButtons = null;
                // 释放上次登录时间标签和其标题标签
                LastAccessLabel = null; LastAccessLabelLabel = null;
                // 释放角色信息列表
                Characters = null;
                // 重置当前选中的角色索引
                _selected = 0;
            }

            base.Dispose(disposing);
        }
        #endregion        
        public sealed class CharacterButton : MirImageControl
        {
            public MirLabel NameLabel, LevelLabel, ClassLabel;
            public bool Selected;

            public CharacterButton()
            {
                Index = 44; //45 locked
                Library = Libraries.Prguse;
                Sound = SoundList.ButtonA;

                NameLabel = new MirLabel
                {
                    Location = new Point(107, 9),
                    Parent = this,
                    NotControl = true,
                    Size = new Size(170, 18)
                };

                LevelLabel = new MirLabel
                {
                    Location = new Point(107, 28),
                    Parent = this,
                    NotControl = true,
                    Size = new Size(30, 18)
                };

                ClassLabel = new MirLabel
                {
                    Location = new Point(178, 28),
                    Parent = this,
                    NotControl = true,
                    Size = new Size(100, 18)
                };
            }

            public void Update(SelectInfo info)
            {
                if (info == null)
                {
                    Index = 44;
                    Library = Libraries.Prguse;
                    NameLabel.Text = string.Empty;
                    LevelLabel.Text = string.Empty;
                    ClassLabel.Text = string.Empty;

                    NameLabel.Visible = false;
                    LevelLabel.Visible = false;
                    ClassLabel.Visible = false;

                    return;
                }

                Library = Libraries.Title;

                Index = 658 + (byte)info.Class; // 起始图片658

                if (Selected) Index += 6; //原来5 因为有武僧的图 要加一



                NameLabel.Text = info.Name;
                LevelLabel.Text = info.Level.ToString();

                ClassLabel.Text = info.Class.ToLocalizedString();

                NameLabel.Visible = true;
                LevelLabel.Visible = true;
                ClassLabel.Visible = true;
            }
        }
    }
}
