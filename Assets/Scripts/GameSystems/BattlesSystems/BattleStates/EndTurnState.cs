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

        BattleFlowState.SetState(new ChooseActionState(BattleFlowState));

        return null;
    }

    private void CheckStatus()
    {
        Zori playerZori = BattleFlowState.ZoriPlayer.Zori;
        Zori ennemyZori = BattleFlowState.ZoriEnnemy.Zori;

        if (BattleFlowState.ZoriPlayer.Zori.GetStatus.CurrentStatus != Effects.E_Status.NONE)
        {
            playerZori.GetStatus.ApplyDamage(BattleFlowState.GetEnnemyCapacity());
        }

        if (BattleFlowState.ZoriEnnemy.Zori.GetStatus.CurrentStatus != Effects.E_Status.NONE)
        {
            ennemyZori.GetStatus.ApplyDamage(BattleFlowState.GetPlayerCapacity());
        }
    }
}