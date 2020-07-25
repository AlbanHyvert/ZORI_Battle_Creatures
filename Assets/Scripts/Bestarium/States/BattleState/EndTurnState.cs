using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnState : IBattleState
{
    private IAController _self = null;
    private float _time = 0;

    void IBattleState.Enter()
    {
        _time = 0;
    }

    void IBattleState.Exit()
    {
        _time = 0;
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
