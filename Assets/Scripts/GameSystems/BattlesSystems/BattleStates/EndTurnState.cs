using UnityEngine;

public class EndTurnState : BattleState
{
    public EndTurnState(BattleFlowManager battleFlow) : base(battleFlow)
    {
    }

    public override void Start()
    {
        //Deal Bonus Damage

        BattleFlowState.ClearCapacity();

        Debug.Log("EndTurn");

        BattleFlowState.SetState(new ChooseActionState(BattleFlowState));
    }
}
