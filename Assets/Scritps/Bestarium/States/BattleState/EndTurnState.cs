using UnityEngine;

public class EndTurnState : IBattleState
{
    private IAController _self = null;
    private IAController _ennemy = null;
    private float _time = 0;
    private float _timeBeforeNextState = 1;

    void IBattleState.Enter()
    {
        _ennemy = BattleManager.Instance.GetBattleData.receiver;

        if (_self.GetHealth.CurrentHealth <= 0)
        {
            _self.GetHealth.CurrentHealth = 0;
            BattleManager.Instance.EndBattle();
        }

        if(_ennemy.GetHealth.CurrentHealth <= 0)
        {
            BattleManager.Instance.EndBattle();
        }
    }

    void IBattleState.Exit()
    {
        _time = 0;
        _ennemy.ChangeBattleState(E_BattleState.ACTIONTURN);
    }

    void IBattleState.Init(IAController controller)
    {
        _self = controller;
    }

    void IBattleState.Tick()
    {
        _self.ChangeBattleState(E_BattleState.WAITTURN);
    }
}
