using UnityEngine;
using System;

public class Zori : ZoriStateMachine
{
    [SerializeField] private ZoriData _data = null;
    [SerializeField] private Zori _prefab = null;
    [Space]
    [SerializeField] private bool _isInBattle = false;
    [Space]
    [SerializeField] private E_Status _status = E_Status.WILD;

    public ZoriData Data { get => _data; set => _data = value; }
    public E_Status Status { get => _status; set => _status = value; }

    private event Action<bool> _isBattling = null;
    public event Action<bool> IsBattling
    {
        add
        {
            _isBattling -= value;
            _isBattling += value;
        }
        remove
        {
            _isBattling -= value;
        }
    }

    private void Start()
    {
        if (string.IsNullOrEmpty(_data.Nickname))
            _data.Nickname = _data.Name;

        if(ZoriDataManager.Instance.Datas().ContainsKey(_data.Nickname) == true)
        {
            _data = ZoriDataManager.Instance.Datas()[_data.Nickname];

            _data.UpdateExperience += CheckExprience;
            _data.UpdateLevel += CheckLevel;
        }
        else
        {
            _data.UpdateExperience += CheckExprience;
            _data.UpdateLevel += CheckLevel;

            ZoriDataManager.Instance.SaveData(this);
        }

        SetIsInBattle(_isInBattle);
    }

    public bool SetIsInBattle(bool value)
    {
        _isInBattle = value;

        if (_isBattling != null)
            _isBattling(value);

        if (value == true)
        {
            switch (_status)
            {
                case E_Status.WILD:
                    BattleManager.Instance.GetBattleSystem().Data.SetZoriB(this);
                    break;
                case E_Status.CAPTURED:
                    BattleManager.Instance.GetBattleSystem().Data.SetZoriA(this);
                    break;
            }
        }

        return _isInBattle;
    }

    private void CheckLevel(int level)
    {
        ZoriDataManager.Instance.SaveData(this);
    }

    private void CheckExprience(float experience)
    {
        ZoriDataManager.Instance.SaveData(this);
    }
}