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

            switch (BattleSystem.GetZoriEnnemy.GetStatus)
            {
                case e_HealthStatus.FREEZING:
                    action = e_ActionSlots.NULL;
                    BattleSystem.GetEnnemyUI.GetDescription.text = BattleSystem.GetZoriEnnemy.GetData.nickName + " is Frozen and can't attack.";

                    yield return new WaitForSecondsRealtime(2);

                    BattleSystem.GetEnnemyUI.GetDescription.text = string.Empty;
                break;

                case e_HealthStatus.SLEEPING:
                    action = e_ActionSlots.NULL;
                    BattleSystem.GetEnnemyUI.GetDescription.text = BattleSystem.GetZoriEnnemy.GetData.nickName + " is Sleeping and can't attack.";
                    
                    yield return new WaitForSecondsRealtime(2);

                    BattleSystem.GetEnnemyUI.GetDescription.text = string.Empty;
                break;
            }

            BattleSystem.SetEnnemyAttack = action;

            switch (BattleSystem.GetZoriPlayer.GetStatus)
            {
                case e_HealthStatus.FREEZING:
                    BattleSystem.GetPlayerUiAction.SetActive(false);
                    BattleSystem.SetPlayerAttack = e_ActionSlots.NULL;
                    BattleSystem.GetPlayerUI.GetDescription.text = BattleSystem.GetZoriPlayer.GetData.nickName + " is Frozen and can't attack.";

                    yield return new WaitForSecondsRealtime(2);

                    BattleSystem.SetState(new ResolveTurn(BattleSystem));
                break;

                case e_HealthStatus.SLEEPING:
                    BattleSystem.GetPlayerUiAction.SetActive(false);
                    BattleSystem.SetPlayerAttack = e_ActionSlots.NULL;
                    BattleSystem.GetPlayerUI.GetDescription.text = BattleSystem.GetZoriPlayer.GetData.nickName + " is Sleeping and can't attack.";
                    
                    yield return new WaitForSecondsRealtime(2);
                    
                    BattleSystem.SetState(new ResolveTurn(BattleSystem));
                break;
            }

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