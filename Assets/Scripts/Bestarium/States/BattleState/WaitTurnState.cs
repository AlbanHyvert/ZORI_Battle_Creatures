public class WaitTurnState : IBattleState
{
    private IAController _self = null;
    private bool _hasInit = false;

    void IBattleState.Enter()
    {
        if(_hasInit == false)
        {
            BattleManager.Instance.SetBattle(_self);

            _hasInit = true;
        }
    }

    void IBattleState.Exit()
    {
        //Anim
        //Sound Effect
        //Visual Effect
    }

    void IBattleState.Init(IAController controller)
    {
        _self = controller;
    }

    void IBattleState.Tick()
    {


        //Anim
        //Sound Effect
        //Visual Effect
    }
}
