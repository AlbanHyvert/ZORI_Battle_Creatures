using UnityEngine;
using System.Collections;

namespace ZORI_Battle_Creatures.Assets.Scripts.BattleSystems.States
{
    public class Lost : State
    {
        public Lost(BattleSystem battleSystem) : base(battleSystem)
        {

        }

        public override IEnumerator Start()
        {
            Debug.Log("You Lost");

            BattleSystem.SetMatchFinish = true;

            yield break;
        }
    }
}