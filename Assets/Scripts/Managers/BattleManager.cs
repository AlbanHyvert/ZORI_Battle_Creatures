using Engine.Singleton;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{
    private BattleSettings _battleSettings = null;
    private IAController _zoriA = null;
    private IAController _zoriB = null;

    public BattleSettings BattleSettings { get { return _battleSettings; } set { _battleSettings = value; } }

    public IAController GetZoriA { get { return _zoriA; } }
    public IAController GetZoriB { get { return _zoriB; } }
    
    public IAController SetZoriA { set { _zoriA = value; } }
    public IAController SetZoriB { set { _zoriB = value; } }

    public void SetBattle(IAController controller)
    {
        if (controller.GetHasStartedTheBattle == true)
        {
            SetZoriA = controller;
            _battleSettings.GetUIZoriA.Init(controller);
            //_zoriA.gameObject.SetActive(false);
        }
        else
        {
            SetZoriB = controller;
            _battleSettings.GetUIZoriB.Init(controller);
            //_zoriA.gameObject.SetActive(true);
        }
    }

    private void OnUpdate()
    {
        if(_zoriA != null && _zoriB != null)
        {
            if (_zoriA.GetStats.GetSpeed > _zoriB.GetStats.GetSpeed)
            {
                _zoriA.ChangeState(E_BattleState.ACTIONTURN);
            }
            else
                _zoriB.ChangeState(E_BattleState.ACTIONTURN);

            GameLoopManager.Instance.UpdateManager -= OnUpdate;
        }
    }

    protected override void Awake()
    {
        base.Awake();

        GameLoopManager.Instance.UpdateManager += OnUpdate;
    }
}