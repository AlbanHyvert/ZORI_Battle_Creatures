using UnityEngine;
using ZORI.Enums;

[CreateAssetMenu(fileName = "Technique", menuName = "Zori/Techniques/Technique")]
public class Techniques : ScriptableObject
{
    [SerializeField] private string _name = string.Empty;
    [Space]
    [SerializeField] private E_Types _type = E_Types.NEUTRAL;
    [SerializeField] private E_Styles _style = E_Styles.PHYSICS;
    [SerializeField] private E_EffectsTag _tag = E_EffectsTag.NULL;
    [SerializeField] private E_Targets _target = E_Targets.ENNEMY;
    [SerializeField] private E_Priority _priority = E_Priority.NEUTRAL;
    [Space]
    [SerializeField] private int _power = 10;
    [SerializeField] private int _maxUse = 10;
    [Space]
    [SerializeField, TextArea(0,50)] private string _description = string.Empty;

    private int _currentUse = 0;

    public string Name { get => _name; }
    public E_Types Type { get => _type; }
    public E_Styles Style { get => _style; }
    public E_Targets Targets { get => _target; }
    public E_Priority Priority { get => _priority; }
    public E_EffectsTag Tag { get => _tag; }
    public int Power { get => _power; }

    public void Init()
    {
        _currentUse = _maxUse;
    }

    public void RemoveUse(int amount)
    {
        if (_currentUse > 0)
            _currentUse -= amount;
    }
    
    public void AddUse(int amount)
    {
        if (_currentUse < _maxUse)
            _currentUse += amount;
    }

    public void UpdateMaxUse(int value)
    {
        _maxUse = value;
        _currentUse = value;
    }

    public int CurrentUse()
        => _currentUse;

    public string Description()
        => _description;

    public Techniques Value()
        => this;
}