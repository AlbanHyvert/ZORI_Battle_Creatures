using UnityEngine;
using System.Collections;

namespace ZORI_Battle_Creatures.Assets.Scripts.BattleSystems
{
    public abstract class State
    {
        protected BattleSystem BattleSystem = null;

        public State(BattleSystem battleSystem)
        {
            BattleSystem = battleSystem;
        }

        public virtual IEnumerator Start()
        {
            yield break;
        }

        public virtual IEnumerator Attack()
        {
            yield break;
        }

        public virtual IEnumerator Heal()
        {
            yield break;
        }

        public virtual IEnumerator WinBattle()
        {
            yield break;
        }
        public virtual IEnumerator LostBattle()
        {
            yield break;
        }
    }
}
