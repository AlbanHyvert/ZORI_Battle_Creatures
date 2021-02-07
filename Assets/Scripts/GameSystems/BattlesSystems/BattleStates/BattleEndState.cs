using System.Collections;
using UnityEngine;

public class BattleEndState : BattleState
{
    public BattleEndState(BattleFlowManager battleFlow) : base(battleFlow)
    {
    }

    public override IEnumerator Start()
    {
        BattleFlowState.ControlPlayerConsole(false);

        BattleFlowState.StopAllCoroutines();

        if(BattleFlowState.playerWon)
        {
            Debug.Log("PLAYER WON");
            return null;
        }
        else
        {
            Debug.Log("PLAYER LOST");
        }

        return null;
    }
}
