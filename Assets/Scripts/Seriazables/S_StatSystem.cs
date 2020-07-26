using UnityEngine;

[System.Serializable]
public class S_StatSystem
{
    #region Base
    private int _baseAttack = 0;
    private int _baseDefence = 0;
    private int _baseSpeAttack = 0;
    private int _baseSpeDefence = 0;
    private int _baseSpeed = 0;
    private int _baseMana = 0;
    #endregion Base

    #region Current
    private string _name = string.Empty;
    private int _attack = 0;
    private int _defence = 0;
    private int _speAttack = 0;
    private int _speDefence = 0;
    private int _speed = 0;
    private E_Behavior _behavior = E_Behavior.AGGRESSIVE;
    private E_Types[] _types = null;
    private int _mana = 0;
    #endregion Current

    #region Temp Value Holder
    private int _tempMana = 0;
    #endregion Temp Value Holder

    public void Init(D_StatSystem statSystem, E_Behavior behavior, E_Types[] types, S_BattlePointSystem s_BattlePoint, int level)
    {
        _name = statSystem.GetName;
        _baseAttack = statSystem.GetBaseAttack;
        _baseDefence = statSystem.GetBaseDefence;
        _baseSpeAttack = statSystem.GetBaseSpeAttack;
        _baseSpeDefence = statSystem.GetBaseSpeDefence;
        _baseSpeed = statSystem.GetBaseSpeed;
        _behavior = behavior;
        _types = types;
        _baseMana = statSystem.GetBaseMana;

        CalculateStats(level, s_BattlePoint.GetBPAtk, s_BattlePoint.GetBPDef, s_BattlePoint.GetBPSpeAtk, s_BattlePoint.GetBPSpeDef, s_BattlePoint.GetBPSpeed);
    }

    public void CalculateStats(int curLevel, int BPAtk, int BPDef, int BPSpeAtk, int BPSpeDef, int BPSpeed)
    {
        int atk = (((2 * _baseAttack + (BPAtk / 4)) * curLevel) / 100) + 5;
        int def = (((2 * _baseDefence + (BPDef / 4)) * curLevel) / 100) + 5;
        int speAtk = (((2 * _baseSpeAttack + (BPSpeAtk / 4)) * curLevel) / 100) + 5;
        int speDef = (((2 * _baseSpeDefence + (BPSpeDef / 4)) * curLevel) / 100) + 5;
        int speed = (((2 * _baseSpeed + (BPSpeed / 4)) * curLevel) / 100) + 5;
        int mana = (((2 * _baseMana + (BPSpeed / 4)) * curLevel) / 100) + 5;

        _attack = Mathf.Abs(atk);
        _defence = Mathf.Abs(def);
        _speAttack = Mathf.Abs(speAtk);
        _speDefence = Mathf.Abs(speDef);
        _speed = Mathf.Abs(speed);
        _mana += Mathf.Abs(mana);

        _tempMana = _mana;     
    }

    #region Get Variables
    public string GetName { get { return _name; } }
    public int GetAttack { get { return _attack; } }
    public int GetDefence { get { return _defence; } }
    public int GetSpeAttack { get { return _speAttack; } }
    public int GetSpeDefence { get { return _speDefence; } }
    public int GetSpeed { get { return _speed; } }
    public E_Behavior GetBehavior { get { return _behavior; } }
    public E_Types[] GetTypes { get { return _types; } }
    public int GetMana { get { return _mana; } }
    #endregion Get Variables

    public int SetMana { set { _mana = value; } }
}