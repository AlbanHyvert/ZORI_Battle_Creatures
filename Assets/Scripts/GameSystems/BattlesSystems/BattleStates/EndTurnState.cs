using System.Collections;

public class EndTurnState : BattleState
{
    public EndTurnState(BattleFlowManager battleFlow) : base(battleFlow)
    {
    }

    public override IEnumerator Start()
    {
        //Deal Bonus Damage

        BattleFlowState.ClearCapacity();

        BattleFlowState.SetState(new ChooseActionState(BattleFlowState));

        return null;
    }
}
