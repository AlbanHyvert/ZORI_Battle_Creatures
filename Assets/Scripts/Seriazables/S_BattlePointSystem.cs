using UnityEngine;

[System.Serializable]
public class S_BattlePointSystem
{
    [SerializeField] private int _BPHp = 0;
    [SerializeField] private int _BPAtk = 0;
    [SerializeField] private int _BPDef = 0;
    [SerializeField] private int _BPSpeAtk = 0;
    [SerializeField] private int _BPSpeDef = 0;
    [SerializeField] private int _BPSpeed = 0;

    public int GetBPHp { get { return _BPHp; } }
    public int GetBPAtk { get { return _BPAtk; } }
    public int GetBPDef { get { return _BPDef; } }
    public int GetBPSpeAtk { get { return _BPSpeAtk; } }
    public int GetBPSpeDef { get { return _BPSpeDef; } }
    public int GetBPSpeed { get { return _BPSpeed; } }

    #region Add Battle Points
    public void AddBPHp(int amount)
    {
        _BPHp += amount;
    }

    public void AddBPAtk(int amount)
    {
        _BPAtk += amount;
    }

    public void AddBPDef(int amount)
    {
        _BPDef += amount;
    }

    public void AddBPSpeAtk(int amount)
    {
        _BPSpeAtk += amount;
    }

    public void AddBPSpeDef(int amount)
    {
        _BPSpeDef += amount;
    }

    public void AddBPSpeed(int amount)
    {
        _BPSpeed += amount;
    }
    #endregion Add Battle Points

    #region Remove Battle Points
    public void RemoveBPHp(int amount)
    {
        _BPHp -= amount;

        if (_BPHp < 0)
            _BPHp = 0;
    }

    public void RemoveBPAtk(int amount)
    {
        _BPAtk -= amount;

        if (_BPAtk < 0)
            _BPAtk = 0;
    }

    public void RemoveBPDef(int amount)
    {
        _BPDef -= amount;

        if (_BPDef < 0)
            _BPDef = 0;
    }

    public void RemoveBPSpeAtk(int amount)
    {
        _BPSpeAtk -= amount;

        if (_BPSpeAtk < 0)
            _BPSpeAtk = 0;
    }

    public void RemoveBPSpeDef(int amount)
    {
        _BPSpeDef -= amount;

        if (_BPSpeDef < 0)
            _BPSpeDef = 0;
    }

    public void RemoveBPSpeed(int amount)
    {
        _BPSpeed -= amount;

        if (_BPSpeed < 0)
            _BPSpeed = 0;
    }
    #endregion Remove Battle Points
}