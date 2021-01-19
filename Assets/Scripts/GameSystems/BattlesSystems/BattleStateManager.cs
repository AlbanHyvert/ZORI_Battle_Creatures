using UnityEngine;

public abstract class BattleStateManager : MonoBehaviour
{
    protected BattleState State = null;

    public void SetState(BattleState state)
    {
        State = state;

        State.Start();
    }
}
