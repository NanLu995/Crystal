public sealed class Stats : IEquatable<Stats>
{
    public SortedDictionary<Stat, int> Values { get; set; } = new SortedDictionary<Stat, int>();
    public int Count => Values.Sum(pair => Math.Abs(pair.Value));

    public int this[Stat stat]
    {
        get
        {
            return !Values.TryGetValue(stat, out int result) ? 0 : result;
        }
        set
        {
            if (value == 0)
            {
                if (Values.ContainsKey(stat))
                {
                    Values.Remove(stat);
                }

                return;
            }

            Values[stat] = value;
        }
    }

    public Stats() { }

    public Stats(Stats stats)
    {
        foreach (KeyValuePair<Stat, int> pair in stats.Values)
            this[pair.Key] += pair.Value;
    }

    public Stats(BinaryReader reader, int version = int.MaxValue, int customVersion = int.MaxValue)
    {
        int count = reader.ReadInt32();

        for (int i = 0; i < count; i++)
            Values[(Stat)reader.ReadByte()] = reader.ReadInt32();
    }

    public void Add(Stats stats)
    {
        foreach (KeyValuePair<Stat, int> pair in stats.Values)
            this[pair.Key] += pair.Value;
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(Values.Count);

        foreach (KeyValuePair<Stat, int> pair in Values)
        {
            writer.Write((byte)pair.Key);
            writer.Write(pair.Value);
        }
    }

    public void Clear()
    {
        Values.Clear();
    }

    public bool Equals(Stats other)
    {
        if (Values.Count != other.Values.Count) return false;

        foreach (KeyValuePair<Stat, int> value in Values)
            if (other[value.Key] != value.Value) return false;

        return true;
    }
}

public enum StatFormula : byte
{
    Health,
    Mana,
    Weight,
    Stat
}

public enum Stat : byte
{
    MinAC = 0,
    MaxAC = 1,
    MinMAC = 2,
    MaxMAC = 3,
    MinDC = 4,
    MaxDC = 5,
    MinMC = 6,
    MaxMC = 7,
    MinSC = 8,
    MaxSC = 9,

    Accuracy = 10, // 准确
    Agility = 11, // 敏捷
    HP = 12,
    MP = 13,
    AttackSpeed = 14, // 攻击速度
    Luck = 15, // 幸运
    BagWeight = 16, // 背包负重
    HandWeight = 17, // 腕力负重
    WearWeight = 18, // 装备负重
    Reflect = 19, // 反弹伤害
    Strong = 20, // 强度
    Holy = 21, // 神圣
    Freezing = 22, // 冰冻伤害
    PoisonAttack = 23, // 毒素伤害

    MagicResist = 30, // 魔法躲避
    PoisonResist = 31, // 毒物躲避
    HealthRecovery = 32, // 生命恢复
    SpellRecovery = 33, // 法力恢复
    PoisonRecovery = 34, // 中毒恢复 TODO - Should this be in seconds or milliseconds??
    CriticalRate = 35, // 暴击率
    CriticalDamage = 36, // 暴击伤害

    MaxACRatePercent = 40, // 强化防御
    MaxMACRatePercent = 41, // 强化魔法防御
    MaxDCRatePercent = 42, // 攻击强化
    MaxMCRatePercent = 43, // 魔法攻击强化
    MaxSCRatePercent = 44, // 道术攻击强化
    AttackSpeedRatePercent = 45, // 攻击速度强化
    HPRatePercent = 46, // 生命值数率
    MPRatePercent = 47, // 法力值数率
    HPDrainRatePercent = 48, // 吸血数率

    ExpRatePercent = 100, // 经验增长数率
    ItemDropRatePercent = 101, // 物品掉落数率
    GoldDropRatePercent = 102, // 金币收益数率
    MineRatePercent = 103, // 采矿出矿数率
    GemRatePercent = 104, // 宝石成功数率
    FishRatePercent = 105, // 钓鱼成功数率
    CraftRatePercent = 106, // 大师概率数率
    SkillGainMultiplier = 107, // 技能熟练度倍率
    AttackBonus = 108, // 武器增伤

    LoverExpRatePercent = 120, // 伴侣专享经验数率
    MentorDamageRatePercent = 121, // 师徒专享伤害数率
    MentorExpRatePercent = 123, // 师徒专享经验数率
    DamageReductionPercent = 124, // 伤害减免数率
    EnergyShieldPercent = 125, // 气功盾恢复数率
    EnergyShieldHPGain = 126, // 气功盾恢复生命值
    ManaPenaltyPercent = 127, // 法力值消耗数率
    TeleportManaPenaltyPercent = 128, // 传送技法力消耗数率
    Hero = 129,

    Unknown = 255
}