using UnityEngine;

public class ZoriData
{
    private int _ID = 0;
    private string _name = string.Empty;
    private BaseStats _attack = new BaseStats();
    private BaseStats _defence = new BaseStats();
    private BaseStats _HP = new BaseStats();
    private int _level = 0;
    private int _experience = 0;
    private int _speed = 0;
    private E_ZoriRarity _rarity = E_ZoriRarity.COMMON;
    private E_ZoriTypes _type = E_ZoriTypes.AERO;
    private E_Regions _region = E_Regions.EAST;

    public int ID { get => _ID; set => _ID = value; }
    public string Name { get => _name; set => _name = value; }
    public BaseStats Attack { get => _attack; set => _attack = value; }
    public BaseStats Defence { get => _defence; set => _defence = value; }
    public BaseStats HP { get => _HP; set => _HP = value; }
    public int Level { get => _level; set => _level = value; }
    public int Experience { get => _experience; set => _experience = value; }
    public int Speed { get => _speed; set => _speed = value; }
    public E_ZoriRarity Rarity { get => _rarity; set => _rarity = value; }
    public E_ZoriTypes Type { get => _type; set => _type = value; }
    public E_Regions Region { get => _region; set => _region = value; }
}
