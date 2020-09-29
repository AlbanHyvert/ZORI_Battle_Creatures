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

            BattleSystem.SetState(new ChooseAction(BattleSystem));

            yield break;
        }
    }
}
