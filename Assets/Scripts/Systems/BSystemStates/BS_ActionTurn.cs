using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BS_ActionTurn : BattleState
{
    public BS_ActionTurn(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override void Start()
    {
        if(!BattleSystem.Data.GetZoriB().Owner)
        {
            int rdmAtk = Random.Range(0, BattleSystem.Data.GetZoriB().Data.Holder().CheckTechniqueQuantity() - 1);

            BattleSystem.SetTechniqueB(BattleSystem.Data.GetZoriB().Data.Holder().CurrentTechniques[rdmAtk]);
        }

        if (!BattleSystem.Data.GetZoriA().Owner)
        {
            int rdmAtk = Random.Range(0, BattleSystem.Data.GetZoriA().Data.Holder().CheckTechniqueQuantity() - 1);

            BattleSystem.SetTechniqueA(BattleSystem.Data.GetZoriA().Data.Holder().CurrentTechniques[rdmAtk]);
        }
        else
        {
            //ActivateHUD
        }
    }
}
