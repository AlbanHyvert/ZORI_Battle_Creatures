using UnityEngine;

public class ExecuteState : BattleState
{
    public ExecuteState(BattleFlowManager battleFlow) : base(battleFlow)
    {
    }

    private bool m_playerTurnEnded = false;
    private bool m_ennemyTurnEnded = false;

    public override void Start()
    {
        Debug.Log("ExecuteTurn");

        BattleFlowState.ControlPlayerConsole(false);

        int playerSpeed = BattleFlowState.ZoriPlayer.Zori.GetAttackSpeed(BattleFlowState.GetPlayerCapacity());
        int ennemySpeed = BattleFlowState.ZoriEnnemy.Zori.GetAttackSpeed(BattleFlowState.GetEnnemyCapacity());

        if (playerSpeed >= ennemySpeed)
        {
            PlayerAttack();

            return;
        }
        else
        {
            EnnemyAttack();
        }
    }

    private void PlayerAttack()
    {
        //Calculate Player Dealt Damage
        //Deal Damage To Ennemy

        m_playerTurnEnded = true;

        CheckEndedTurn();

        if (!m_ennemyTurnEnded)
            EnnemyAttack();
    }

    private void EnnemyAttack()
    {
        //Calculate Ennemy Dealt Damage
        //Deal Damage To Player

        m_ennemyTurnEnded = true;

        CheckEndedTurn();

        if (!m_playerTurnEnded)
            PlayerAttack();
    }

    private void CheckEndedTurn()
    {
        if (!m_ennemyTurnEnded || !m_playerTurnEnded)
            return;

        BattleFlowState.SetState(new EndTurnState(BattleFlowState));
    }
}
