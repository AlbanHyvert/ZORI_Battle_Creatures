using ZORI_Battle_Creatures.Assets.Scripts.Utilities;
using ZORI_Battle_Creatures.Assets.Scripts.Enumerators;
using ZORI_Battle_Creatures.Assets.Scripts.Bestarium;
using UnityEngine;
using System.Collections;

namespace ZORI_Battle_Creatures.Assets.Scripts.BattleSystems.States
{
    public class EnnemyTurn : State
    {
        public EnnemyTurn(BattleSystem battleSystem) : base(battleSystem)
        {

        }

        public override IEnumerator Start()
        {
            int rdmAtt = Random.Range(0,3);
            e_ActionSlots action = e_ActionSlots.A;

            ZoriController zoriPlayer = BattleSystem.GetZoriPlayer;
            ZoriController zoriEnnemy = BattleSystem.GetZoriEnnemy;

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

            zoriPlayer.TakeDamage(BattleUtilities.CheckDamage(zoriEnnemy, action, zoriPlayer));

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
    }
}