using UnityEngine;
using System.Collections;
using ZORI_Battle_Creatures.Assets.Scripts.Enumerators;

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

        public virtual IEnumerator ChooseAttack()
        {
            yield break;
        }

        public virtual IEnumerator ExecuteAction(e_ActionSlots move)
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
