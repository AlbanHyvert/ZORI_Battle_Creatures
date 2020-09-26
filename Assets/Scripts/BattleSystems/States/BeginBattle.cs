using UnityEngine;
using System.Collections;

namespace ZORI_Battle_Creatures.Assets.Scripts.BattleSystems.States
{
    public class BeginBattle : State
    {
        public BeginBattle(BattleSystem battleSystem) : base(battleSystem)
        {

        }

        public override IEnumerator Start()
        {
            BattleSystem.GetPlayerUI.Init(BattleSystem.GetZoriPlayer);
            BattleSystem.GetEnnemyUI.Init(BattleSystem.GetZoriEnnemy);

            Debug.Log("Begin Battle");

            int playerSpeed = BattleSystem.GetZoriPlayer.GetData.stats.speed;
            int ennemySpeed = BattleSystem.GetZoriEnnemy.GetData.stats.speed;

            if(playerSpeed >= ennemySpeed)
            {
                BattleSystem.SetState(new PlayerTurn(BattleSystem));
            }
            else if(playerSpeed < ennemySpeed)
            {
                BattleSystem.SetState(new EnnemyTurn(BattleSystem));
            }

            yield break;
        }
    }
}
