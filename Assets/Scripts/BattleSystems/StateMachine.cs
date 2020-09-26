using UnityEngine;

namespace ZORI_Battle_Creatures.Assets.Scripts.BattleSystems
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected State State = null;

        public void SetState(State state)
        {
            State = state;
            
            StartCoroutine(State.Start());
        }
    }
}