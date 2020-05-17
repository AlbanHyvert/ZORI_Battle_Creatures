using UnityEngine;

public class BaseZori : MonoBehaviour
{
    [SerializeField] private string _name = string.Empty;
    [SerializeField] private Sprite _icon = null;
    [SerializeField] private ZoriStats _attackStats = null;
    [SerializeField] private ZoriStats _defenseStats = null;
    [SerializeField] private ZoriStats _HPStats = null;
    [SerializeField, Range(1,999)] private int _level = 1;
    [SerializeField] private float _experience = 0;
    [SerializeField] private int _speed = 0;
    [SerializeField] private RegionEnums _biomeFound = RegionEnums.EAST;
    [SerializeField] private ZoriTypeEnums _type = ZoriTypeEnums.AERO;
    [SerializeField] private ZoriRarityEnums _rarity = ZoriRarityEnums.COMMON;

    public string Name { get => _name; }
    public Sprite Icon { get => _icon; }
    public ZoriStats AttackStats { get => _attackStats; }
    public ZoriStats DefenseStats { get => _defenseStats; }
    public ZoriStats HPStats { get => _HPStats; }
    public int Level { get => _level; }
    public float Experience { get => _experience; }
    public int Speed { get => _speed; }
    public RegionEnums BiomeFound { get => _biomeFound; }
    public ZoriTypeEnums Type { get => _type; }
    public ZoriRarityEnums Rarity { get => _rarity; }
}
