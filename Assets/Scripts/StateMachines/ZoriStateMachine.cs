using UnityEngine;

public abstract class ZoriStateMachine : MonoBehaviour
{
    protected ZoriState State = null;

    public void SetState(ZoriState state)
    {
        State = state;

        State.Start();
    }
}
