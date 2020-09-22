using UnityEngine;

[CreateAssetMenu(fileName = "StatSystem", menuName = "DataHolder/StatSystem")]
[ExecuteInEditMode]
public class D_StatSystem : ScriptableObject
{
    #region Serialized Variables
    [SerializeField] private string _name = string.Empty;
    [SerializeField] private int _iD = 0;
    [SerializeField, Range(1, 999)] private int _level = 0;
    [Space]
    [SerializeField] private int _baseHp = 0;
    [SerializeField] private int _baseAttack = 0;
    [SerializeField] private int _baseDefence = 0;
    [SerializeField] private int _baseSpeAttack = 0;
    [SerializeField] private int _baseSpeDefence = 0;
    [SerializeField] private int _baseSpeed = 0;
    [Space]
    [SerializeField] private E_Behavior _behavior = E_Behavior.NONE;
    [SerializeField] private E_Types[] _types = null;
    [Space]
    [SerializeField] private int _baseMana = 30;
    [Space]
    [SerializeField] private int _baseMaxExperience = 100;
    #endregion Serialized Variables

    #region Private
    private int _hp = 0;
    private int _attack = 0;
    private int _defence = 0;
    private int _speAttack = 0;
    private int _speDefence = 0;
    private int _speed = 0;
    private int _mana = 0;
    private float _maxXP = 0;
    #endregion Private

    public void SetData(string name, int id, int baseHp, int baseAtk, int baseDef, int baseSpeAtk, int baseSpeDef, int baseSpeed, E_Behavior behavior, E_Types[] types,int baseMana)
    {
        _name = name;
        _iD = id;
        _baseHp = baseHp;
        _baseAttack = baseAtk;
        _baseDefence = baseDef;
        _baseSpeAttack = baseSpeAtk;
        _baseSpeDefence = baseSpeDef;
        _baseSpeed = baseSpeed;
        _behavior = behavior;
        _types = types;
        _baseMana = baseMana;
    }
    
    #region Get Value
    public string GetName { get { return _name; } }
    public int GetID { get { return _iD; } }
    public int GetLevel { get { return _level; } }
    public int GetBaseHp { get { return _baseHp; } }
    public int GetBaseAttack { get { return _baseAttack; } }
    public int GetBaseDefence { get { return _baseDefence; } }
    public int GetBaseSpeAttack { get { return _baseSpeAttack; } }
    public int GetBaseSpeDefence { get { return _baseSpeDefence; } }
    public int GetBaseSpeed { get { return _baseSpeed; } }
    public E_Behavior GetBehavior { get { return _behavior; } }
    public E_Types[] GetTypes { get { return _types; } }
    public int GetBaseMana { get { return _baseMana; } }
    public int GetBaseMaxExperience { get { return _baseMaxExperience; } }
    #endregion Get Value

    #region Get Inspector Only Value
    public int GetHp { get { return _hp; } }
    public int GetAttack { get { return _attack; } }
    public int GetDefence { get { return _defence; } }
    public int GetSpeAttack { get { return _speAttack; } }
    public int GetSpeDefence { get { return _speDefence; } }
    public int GetSpeed { get { return _speed; } }
    public int GetMana { get { return _mana; } }
    public float GetMaxExperience { get { return _maxXP; } }
    #endregion Get Inspector Only Value

    #region Set Value
    public string SetName { set { _name= value; } }
    public int SetID { set { _iD = value; } }
    public int SetLevel { get { return _level; } }
    public int SetBaseHp { set { _baseHp = value; } }
    public int SetBaseAttack { set { _baseAttack = value; } }
    public int SetBaseDefence { set { _baseDefence = value; } }
    public int SetBaseSpeAttack { set { _baseSpeAttack = value; } }
    public int SetBaseSpeDefence { set { _baseSpeDefence = value; } }
    public int SetBaseSpeed { set { _baseSpeed = value; } }
    public E_Behavior SetBehavior { set { _behavior = value; } }
    public E_Types[] SetTypes { set { _types = value; ; } }
    public int SetBaseMana { set { _baseMana = value; ; } }
    public int SetBaseMaxExperience { set { _baseMaxExperience = value; } }
    #endregion Set Value

    public void OnValueChanged()
    {
        int atk = (((2 * _baseAttack + (1 / 4)) * _level) / 100) + 5;
        int def = (((2 * _baseDefence + (1 / 4)) * _level) / 100) + 5;
        int speAtk = (((2 * _baseSpeAttack + (1 / 4)) * _level) / 100) + 5;
        int speDef = (((2 * _baseSpeDefence + (1 / 4)) * _level) / 100) + 5;
        int speed = (((2 * _baseSpeed + (1 / 4)) * _level) / 100) + 5;
        int mana = (((2 * _baseMana + (1 / 4)) * _level) / 100) + 5;
        int maxXP = (((2 * _baseMaxExperience) * _level) / 10) + _level + 100;
        _hp = Mathf.Abs((((2 * _baseHp + (1 / 4)) * _level) / 100) + _level + 10);

        _attack = Mathf.Abs(atk);
        _defence = Mathf.Abs(def);
        _speAttack = Mathf.Abs(speAtk);
        _speDefence = Mathf.Abs(speDef);
        _speed = Mathf.Abs(speed);
        _mana = Mathf.Abs(mana);
        _maxXP = Mathf.Abs(maxXP);
    }
}