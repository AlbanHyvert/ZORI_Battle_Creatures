using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnState : IBattleState
{
    private IAController _self = null;
    private float _time = 0;
    private bool _hasInit = false;
    private IAController _ennemy = null;

    void IBattleState.Enter()
    {
        _time = 0;

        if (_hasInit == false)
        {
            if (_self.GetHasStartedTheBattle == false)
                _ennemy = BattleManager.Instance.GetZoriA;
            else
                _ennemy = BattleManager.Instance.GetZoriB;

            _hasInit = true;
        }
    }

    void IBattleState.Exit()
    {
        _time = 0;
        _self.DescText = string.Empty;
        _ennemy.ChangeState(E_BattleState.ACTIONTURN);
    }

    void IBattleState.Init(IAController controller)
    {
        _self = controller;
    }

    void IBattleState.Tick()
    {
        _time += 0.01f + Time.deltaTime;

        if(_time > 1)
        {
            _self.ChangeState(E_BattleState.WAITTURN);
        }
    }
}
