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

        if (BattleFlowState.ZoriPlayer.Zori.CurrentEffect != Effects.E_Effects.NONE)
        {
            switch (BattleFlowState.ZoriPlayer.Zori.CurrentEffect)
            {
                case Effects.E_Effects.BURN:
                    playerZori.Health.TakeDamage((int)(playerZori.Health.currentHealth * 0.06f));
                    DisplayText.AddText(BattleFlowState.PlayerHud.descriptionText, playerZori.Stats.nickname + " has taken damage.", BattleFlowState.readingSpeed);
                    break;
                case Effects.E_Effects.POISON:
                    playerZori.Health.TakeDamage((int)(playerZori.Health.currentHealth * playerZori.CurrentPoisonDmg));
                    DisplayText.AddText(BattleFlowState.PlayerHud.descriptionText, playerZori.Stats.nickname + " has taken damage.", BattleFlowState.readingSpeed);
                    playerZori.CurrentPoisonDmg += 0.01f;
                    break;
            }
        }

        if (BattleFlowState.ZoriEnnemy.Zori.CurrentEffect != Effects.E_Effects.NONE)
        {
            switch (BattleFlowState.ZoriEnnemy.Zori.CurrentEffect)
            {
                case Effects.E_Effects.BURN:
                    ennemyZori.Health.TakeDamage((int)(ennemyZori.Health.currentHealth * 0.06f));
                    DisplayText.AddText(BattleFlowState.PlayerHud.descriptionText, ennemyZori.Stats.nickname + " has taken damage.", BattleFlowState.readingSpeed);
                    break;
                case Effects.E_Effects.POISON:
                    ennemyZori.Health.TakeDamage((int)(ennemyZori.Health.currentHealth * ennemyZori.CurrentPoisonDmg));
                    DisplayText.AddText(BattleFlowState.PlayerHud.descriptionText, ennemyZori.Stats.nickname + " has taken damage.", BattleFlowState.readingSpeed);
                    ennemyZori.CurrentPoisonDmg += 0.01f;
                    break;
            }
        }
    }
}