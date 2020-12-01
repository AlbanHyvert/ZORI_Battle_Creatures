using UnityEngine;

public abstract class BattleStateMachine : MonoBehaviour
{
    protected BattleState State = null;

    public void SetState(BattleState state)
    {
        State = state;

        State.Start();
    }
}
