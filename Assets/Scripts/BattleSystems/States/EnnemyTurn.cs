using ZORI_Battle_Creatures.Assets.Scripts.Utilities;
using ZORI_Battle_Creatures.Assets.Scripts.Enumerators;
using ZORI_Battle_Creatures.Assets.Scripts.Bestarium;
using ZORI_Battle_Creatures.Assets.Scripts.DataHolders;
using ZORI_Battle_Creatures.Assets.Scripts.UI;
using UnityEngine;
using System.Collections;

namespace ZORI_Battle_Creatures.Assets.Scripts.BattleSystems.States
{
    public class EnnemyTurn : State
    {
        private int _damageDone = 0;

        public EnnemyTurn(BattleSystem battleSystem) : base(battleSystem)
        {

        }

        public override IEnumerator Start()
        {
            int rdmAtt = Random.Range(0,3);
            e_ActionSlots action = e_ActionSlots.A;

            ZoriController zoriPlayer = BattleSystem.GetZoriPlayer;
            ZoriController zoriEnnemy = BattleSystem.GetZoriEnnemy;
            d_CapacityStats attack = zoriEnnemy.GetZoriMoves[BattleSystem.GetActionSlots];
            BattleUI battleUI = BattleSystem.GetEnnemyUI;

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

            battleUI.GetDescription.text = zoriEnnemy.GetData.nickName + " use " + attack.GetName;

            yield return new WaitForSecondsRealtime(2);

            zoriPlayer.TakeDamage(BattleUtilities.CheckDamage(zoriEnnemy, action, zoriPlayer));

            CheckDamage(zoriPlayer);

            yield return new WaitForSeconds((float)zoriEnnemy.GetZoriMoves[action].GetVisualEffectDuration);

            if(zoriPlayer.GetCurrentHealth <= 0)
            {
                BattleSystem.SetState(new Lost(BattleSystem));
            }
            else
            {
                BattleSystem.SetState(new PlayerTurn(BattleSystem));
            }

            yield break;
        }

        private void CheckDamage(ZoriController receiver)
        {
            BattleUI battleUI = BattleSystem.GetEnnemyUI;

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