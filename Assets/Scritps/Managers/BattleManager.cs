using Engine.Singleton;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{
    private List<IAController> _zoriList = new List<IAController>();
    private bool _hasInitBattle = false;
    private BattleData _battleData;
    private List<UI_Zori> _zoriUiList = new List<UI_Zori>();
    private GameObject _actionUi = null;
    private ZoriA _zoriPlayer;
    private ZoriB _zoriEnnemy;

    #region Properties
    public List<IAController> GetZoriList { get { return _zoriList; } }
    public bool GetHasInitBattle { get { return _hasInitBattle; } }
    public bool SetHasInitBattle { set { _hasInitBattle = value; } }
    public BattleData GetBattleData { get { return _battleData; } }
    public List<UI_Zori> GetUI_Zoris { get { return _zoriUiList; } }
    public GameObject GetActionUI { get { return _actionUi; } }
    public ZoriA GetZoriPlayer { get { return _zoriPlayer; } }
    public ZoriB GetZoriEnnemy { get { return _zoriEnnemy; } }
    #endregion Properties

    public struct BattleData
    {
        public IAController sender;
        public E_Slots choosenAtt;
        public IAController receiver;
    }

    public struct ZoriA
    {
        public IAController zori;
        public UI_Zori ui;
    }

    public struct ZoriB
    {
        public IAController zori;
        public UI_Zori ui;
    }


    public void EndBattle()
    {
        for (int i = 0; i < _zoriList.Count; i++)
        {
            _zoriList[i].SetIsInBattle = false;
            _zoriList[i].ChangeBattleState(E_BattleState.WAITTURN);
        }

        Debug.Log("BattleEndend");
    }
    public void SetBattleData(IAController sender, E_Slots e_move, IAController receiver)
    {
        _battleData.sender = sender;
        _battleData.choosenAtt = e_move;
        _battleData.receiver = receiver;
    }

    private void Start()
    {
        GameLoopManager.Instance.UpdateManager += Tick;
    }

    private void Tick()
    {
        if (_hasInitBattle == false && _zoriList.Count > 1 && _zoriUiList.Count > 1)
        {
            ConnectUI();
            CheckSpeed();
            _hasInitBattle = true;
        }
    }

    private void CheckSpeed()
    {
        int zoriASpeed = _zoriList[0].GetStats.GetSpeed;
        int zoriBSpeed = _zoriList[1].GetStats.GetSpeed;

        if(zoriASpeed > zoriBSpeed)
        {
            _zoriList[0].ChangeBattleState(E_BattleState.ACTIONTURN);
            _zoriList[0].SetAttackPosition = 0;
            _zoriList[1].SetAttackPosition = 1;
            return;
        }
        else if(zoriASpeed < zoriBSpeed)
        {
            _zoriList[1].ChangeBattleState(E_BattleState.ACTIONTURN);
            _zoriList[0].SetAttackPosition = 1;
            _zoriList[1].SetAttackPosition = 0;
            return;
        }
        else if(zoriASpeed == zoriBSpeed)
        {
            int rdm = UnityEngine.Random.Range(0, 1);

            switch (rdm)
            {
                case 0:
                    _zoriList[0].ChangeBattleState(E_BattleState.ACTIONTURN);
                    _zoriList[0].SetAttackPosition = 0;
                    _zoriList[1].SetAttackPosition = 1;
                    break;
                case 1:
                    _zoriList[1].ChangeBattleState(E_BattleState.ACTIONTURN);
                    _zoriList[0].SetAttackPosition = 1;
                    _zoriList[1].SetAttackPosition = 0;
                    break;
            }
            return;
        }
    }

    private void ConnectUI()
    {
        if(_zoriList[0].GetPlayer != null)
        {
            for (int i = 0; i < _zoriUiList.Count; i++)
            {
                if(_zoriUiList[i].GetIsCloserToCam == true)
                {
                    _zoriUiList[i].Init(_zoriList[0]);
                    _actionUi = _zoriUiList[i].GetActionUI;
                    _zoriPlayer.zori = _zoriList[i];
                    _zoriPlayer.ui = _zoriUiList[i]; 
                }
            }
        }

        if (_zoriList[0].GetPlayer == null)
        {
            for (int i = 0; i < _zoriUiList.Count; i++)
            {
                if (_zoriUiList[i].GetIsCloserToCam == false)
                {
                    _zoriUiList[i].Init(_zoriList[0]);
                    _zoriEnnemy.zori = _zoriList[i];
                    _zoriEnnemy.ui = _zoriUiList[i];
                }
            }
        }

        if (_zoriList[1].GetPlayer != null)
        {
            for (int i = 0; i < _zoriUiList.Count; i++)
            {
                if (_zoriUiList[i].GetIsCloserToCam == true)
                {
                    _zoriUiList[i].Init(_zoriList[1]);
                    _actionUi = _zoriUiList[i].GetActionUI;
                    _zoriPlayer.zori = _zoriList[i];
                    _zoriPlayer.ui = _zoriUiList[i];
                }
            }
        }

        if (_zoriList[1].GetPlayer == null)
        {
            for (int i = 0; i < _zoriUiList.Count; i++)
            {
                if (_zoriUiList[i].GetIsCloserToCam == false)
                {
                    _zoriUiList[i].Init(_zoriList[1]);
                    _zoriPlayer.zori = _zoriList[i];
                    _zoriPlayer.ui = _zoriUiList[i];
                }
            }
        }
    }
}