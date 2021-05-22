using System.Collections;

public class EndTurnState : BattleState
{
    public EndTurnState(BattleFlowManager battleFlow) : base(battleFlow)
    {
    }

    public override IEnumerator Start()
    {
        CheckStatus();

        BattleFlowState.ClearCapacity();
        BattleFlowState.ClearChange();

        BattleFlowState.SetState(new ChooseActionState(BattleFlowState));

        return null;
    }

    private void CheckStatus()
    {
        Zori playerZori = BattleFlowState.ZoriPlayer.Zori;
        Zori ennemyZori = BattleFlowState.ZoriEnnemy.Zori;
        
        playerZori.GetStatus.ApplyDamage();
        ennemyZori.GetStatus.ApplyDamage();
    }
}