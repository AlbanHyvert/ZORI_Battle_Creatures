using ZORI_Battle_Creatures.Assets.Scripts.BattleSystems;
using ZORI_Battle_Creatures.Assets.Scripts.Bestarium;
using ZORI_Battle_Creatures.Assets.Scripts.Enumerators;
using ZORI_Battle_Creatures.Assets.Scripts.DataHolders;
using UnityEngine;
using System.Collections;

namespace ZORI_Battle_Creatures.Assets.Scripts.BattleSystems.States
{
    public class ChooseAction : State
    {
        public ChooseAction(BattleSystem battleSystem) : base(battleSystem)
        {
            
        }

        public override IEnumerator Start()
        {
            Debug.Log("Choose your Attack");

            int rdmAtt = Random.Range(0,3);
            e_ActionSlots action = e_ActionSlots.A;

            BattleSystem.GetPlayerUiAction.SetActive(true);

            switch (rdmAtt)
            {
                case 0:
                    action = e_ActionSlots.A;
                break;

                case 1:
                    action = e_ActionSlots.B;
                break;

                case 2:
                    action = e_ActionSlots.C;
                break;

                case 3:
                    action = e_ActionSlots.D;
                break;
            }

            BattleSystem.SetEnnemyAttack = action;

            yield break;
        }

        public override IEnumerator ChooseAttack()
        {
            BattleSystem.GetPlayerUiAction.SetActive(false);

            BattleSystem.SetState(new ResolveTurn(BattleSystem));

            yield break;
        }
    }
}