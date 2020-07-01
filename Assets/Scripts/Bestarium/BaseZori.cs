using UnityEngine;

[CreateAssetMenu(fileName = "BaseZori", menuName = "Data/BaseZori")]
public class BaseZori : ScriptableObject
{
    [SerializeField] private string _name = string.Empty;
    [SerializeField] private Sprite _icon = null;
    [SerializeField] private BaseStats _attackStats = null;
    [SerializeField] private BaseStats _defenseStats = null;
    [SerializeField] private BaseStats _HPStats = null;
    [SerializeField, Range(1,999)] private int _level = 1;
    [SerializeField] private float _experience = 0;
    [SerializeField] private E_Regions _biomeFound = E_Regions.EAST;
    [SerializeField] private E_ZoriTypes _type = E_ZoriTypes.AERO;
    [SerializeField] private E_ZoriRarity _rarity = E_ZoriRarity.COMMON;

    public string Name { get => _name; }
    public Sprite Icon { get => _icon; }
    public BaseStats AttackStats { get => _attackStats; }
    public BaseStats DefenseStats { get => _defenseStats; }
    public BaseStats HPStats { get => _HPStats; }
    public int Level { get => _level; }
    public float Experience { get => _experience; }
    public E_Regions BiomeFound { get => _biomeFound; }
    public E_ZoriTypes Type { get => _type; }
    public E_ZoriRarity Rarity { get => _rarity; }
}
