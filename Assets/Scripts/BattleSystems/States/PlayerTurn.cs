using ZORI_Battle_Creatures.Assets.Scripts.Utilities;
using ZORI_Battle_Creatures.Assets.Scripts.Bestarium;
using ZORI_Battle_Creatures.Assets.Scripts.UI;
using ZORI_Battle_Creatures.Assets.Scripts.DataHolders;
using ZORI_Battle_Creatures.Assets.Scripts.Enumerators;
using System.Collections;
using UnityEngine;

namespace ZORI_Battle_Creatures.Assets.Scripts.BattleSystems.States
{
    public class PlayerTurn : State
    {
        private int _damageDone = 0;

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
            BattleUI battleUI = BattleSystem.GetPlayerUI;
            d_CapacityStats attack = zoriPlayer.GetZoriMoves[BattleSystem.GetActionSlots];

            battleUI.GetDescription.text = zoriPlayer.GetData.nickName + " use " + attack.GetName;

            BattleSystem.GetPlayerUiAction.SetActive(false);

            yield return new WaitForSecondsRealtime(2);

            _damageDone = BattleUtilities.CheckDamage(zoriPlayer, BattleSystem.GetActionSlots, zoriEnnemy);

            zoriEnnemy.TakeDamage(_damageDone);
            
            battleUI.GetDescription.text = string.Empty;

            CheckDamage(zoriEnnemy);

            yield return new WaitForSecondsRealtime((float)attack.GetVisualEffectDuration);

            battleUI.GetDescription.text = string.Empty;

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
            ZoriController zoriPlayer = BattleSystem.GetZoriPlayer;
            BattleUI battleUI = BattleSystem.GetPlayerUI;
            d_CapacityStats heal = zoriPlayer.GetZoriMoves[BattleSystem.GetActionSlots];

            battleUI.GetDescription.text = zoriPlayer.GetData.nickName + " use " + heal.GetName;

            BattleUtilities.CalculateHealValue(zoriPlayer, BattleSystem.GetActionSlots);

            yield return new WaitForSecondsRealtime((float)heal.GetVisualEffectDuration);

            battleUI.GetDescription.text = string.Empty;

            BattleSystem.SetState(new EnnemyTurn(BattleSystem));

            yield break;
        }
    
        private void CheckDamage(ZoriController receiver)
        {
            BattleUI battleUI = BattleSystem.GetPlayerUI;

            int oneFifth = receiver.GetData.stats.maxHp / 5;
            int oneThird = receiver.GetData.stats.maxHp / 3;
            int half = receiver.GetData.stats.maxHp / 2;

            if(_damageDone < oneFifth)
            {
                battleUI.GetDescription.text = "this was not effective.";
                return;
            }
            else if(_damageDone >= oneFifth && _damageDone < oneThird)
            {
                battleUI.GetDescription.text = "this was effective.";
                return;
            }
            else if(_damageDone >= oneThird && _damageDone < half)
            {
                battleUI.GetDescription.text = "this was very effective!";
                return;
            }
            else if(_damageDone >= half && _damageDone < receiver.GetData.stats.maxHp)
            {
                battleUI.GetDescription.text = "this was a critical damage!";
                return;
            }
            else if(_damageDone >= receiver.GetData.stats.maxHp)
            {
                battleUI.GetDescription.text = "this was a ONE HIT KO!";
                return;
            }
        }
    }
}