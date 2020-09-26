using ZORI_Battle_Creatures.Assets.Scripts.Utilities;
using ZORI_Battle_Creatures.Assets.Scripts.Bestarium;
using System.Collections;
using UnityEngine;

namespace ZORI_Battle_Creatures.Assets.Scripts.BattleSystems.States
{
    public class PlayerTurn : State
    {
        public PlayerTurn(BattleSystem battleSystem) : base(battleSystem)
        {

        }

        public override IEnumerator Start()
        {
            Debug.Log("Choose Your Attack");
            BattleSystem.GetPlayerUiAction.SetActive(true);

            yield break;
        }

        public override IEnumerator Attack()
        {
            ZoriController zoriEnnemy = BattleSystem.GetZoriEnnemy;
            ZoriController zoriPlayer = BattleSystem.GetZoriPlayer;

            zoriEnnemy.TakeDamage(BattleUtilities.CheckDamage(zoriPlayer, BattleSystem.GetActionSlots, zoriEnnemy));
            
             BattleSystem.GetPlayerUiAction.SetActive(false);

            yield return new WaitForSecondsRealtime((float)zoriPlayer.GetZoriMoves[BattleSystem.GetActionSlots].GetVisualEffectDuration);

            if(BattleSystem.GetZoriEnnemy.GetCurrentHealth <= 0)
            {
                BattleSystem.SetState(new Won(BattleSystem));
            }
            else
            {
                BattleSystem.SetState(new EnnemyTurn(BattleSystem));
            }

            yield break;
        }

        public override IEnumerator Heal()
        {
            BattleUtilities.CalculateHealValue(BattleSystem.GetZoriPlayer, BattleSystem.GetActionSlots);

            yield return new WaitForSecondsRealtime((float)BattleSystem.GetZoriPlayer.GetZoriMoves[BattleSystem.GetActionSlots].GetVisualEffectDuration);

            BattleSystem.SetState(new EnnemyTurn(BattleSystem));

            yield break;
        }
    }
}