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
        if (controller.GetHasStartedTheBattle == false)
            SetZoriB = controller;
        else
            SetZoriA = controller;
    }

    protected override void Awake()
    {
        base.Awake();
    }
}