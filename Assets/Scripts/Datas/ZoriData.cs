using UnityEngine;

public class ZoriData
{
    private int _ID = 0;
    private string _name = string.Empty;
    private ZoriStats _attack = new ZoriStats();
    private ZoriStats _defence = new ZoriStats();
    private ZoriStats _HP = new ZoriStats();
    private int _level = 0;
    private int _experience = 0;
    private int _speed = 0;
    private ZoriRarityEnums _rarity = ZoriRarityEnums.COMMON;
    private ZoriTypeEnums _type = ZoriTypeEnums.AERO;
    private RegionEnums _region = RegionEnums.EAST;

    public int ID { get => _ID; set => _ID = value; }
    public string Name { get => _name; set => _name = value; }
    public ZoriStats Attack { get => _attack; set => _attack = value; }
    public ZoriStats Defence { get => _defence; set => _defence = value; }
    public ZoriStats HP { get => _HP; set => _HP = value; }
    public int Level { get => _level; set => _level = value; }
    public int Experience { get => _experience; set => _experience = value; }
    public int Speed { get => _speed; set => _speed = value; }
    public ZoriRarityEnums Rarity { get => _rarity; set => _rarity = value; }
    public ZoriTypeEnums Type { get => _type; set => _type = value; }
    public RegionEnums Region { get => _region; set => _region = value; }
}
