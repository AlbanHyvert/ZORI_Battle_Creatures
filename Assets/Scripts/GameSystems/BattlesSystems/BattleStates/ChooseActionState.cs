using System.Collections;
using UnityEngine;

public class ChooseActionState : BattleState
{
    public ChooseActionState(BattleFlowManager battleFlow) : base(battleFlow)
    {
    }

    public override IEnumerator Start()
    {
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
}