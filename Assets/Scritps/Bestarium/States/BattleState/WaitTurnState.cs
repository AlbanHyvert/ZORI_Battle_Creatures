public class WaitTurnState : IBattleState
{
    private IAController _self = null;
    private bool _isInit = false;

    void IBattleState.Enter()
    {
        if(_isInit == false && _self.GetIsInBattle == true)
        {
            BattleManager.Instance.GetZoriList.Add(_self);
            _isInit = true;
        }
    }

    void IBattleState.Exit()
    {

    }

    void IBattleState.Init(IAController controller)
    {
        _self = controller;
    }

    void IBattleState.Tick()
    {

    }
}
