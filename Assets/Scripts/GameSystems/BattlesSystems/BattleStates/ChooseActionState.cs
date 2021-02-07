using System.Collections;
using UnityEngine;

public class ChooseActionState : BattleState
{
    public ChooseActionState(BattleFlowManager battleFlow) : base(battleFlow)
    {
    }

    public override IEnumerator Start()
    {
        CheckStatus();

        BattleFlowState.ControlPlayerConsole(true);
        BattleFlowState.ControlUIActivation(true);

        int capacityLenght = BattleFlowState.ZoriEnnemy.Zori.CapacityHolder.GetCapacitySize;
        int chooseAction = Random.Range(0, capacityLenght - 1);

        Zori zoriEnnemy = BattleFlowState.ZoriEnnemy.Zori;

        switch (chooseAction)
        {
            case 0:
                BattleFlowState.SetEnnemyCapacity(zoriEnnemy.CapacityHolder.GetCapacityA());
                break;
            case 1:
                BattleFlowState.SetEnnemyCapacity(zoriEnnemy.CapacityHolder.GetCapacityB());
                break;
            case 2:
                BattleFlowState.SetEnnemyCapacity(zoriEnnemy.CapacityHolder.GetCapacityC());
                break;
            case 3:
                BattleFlowState.SetEnnemyCapacity(zoriEnnemy.CapacityHolder.GetCapacityD());
                break;
            default:
                zoriEnnemy.Health.Kill();
                break;
        }

        return null;
    }

    private void CheckStatus()
    {
        if (BattleFlowState.ZoriPlayer.Zori.CurrentEffect != Effects.E_Effects.NONE)
        {
            switch (BattleFlowState.ZoriPlayer.Zori.CurrentEffect)
            {
                case Effects.E_Effects.FREEZE:
                    BattleFlowState.playerHasCapacity = true;
                    break;
                case Effects.E_Effects.SLEEP:
                    BattleFlowState.playerHasCapacity = true;
                    BattleFlowState.CheckEnnemySleep();
                    break;
                default:
                    break;
            }
        }

        if (BattleFlowState.ZoriEnnemy.Zori.CurrentEffect != Effects.E_Effects.NONE)
        {
            switch (BattleFlowState.ZoriEnnemy.Zori.CurrentEffect)
            {
                case Effects.E_Effects.FREEZE:
                    BattleFlowState.ennemyHasCapacity = true;
                    break;
                case Effects.E_Effects.SLEEP:
                    BattleFlowState.ennemyHasCapacity = true;
                    BattleFlowState.CheckEnnemySleep();
                    break;
                default:
                    break;
            }
        }
    }
}