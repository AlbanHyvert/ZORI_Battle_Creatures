using UnityEngine;
using System.Collections;

public abstract class BattleStateManager : MonoBehaviour
{
    protected BattleState State = null;

    public BattleState SetState(BattleState state)
    {
        State = state;

        if (State == null)
            return null;

        IEnumerator enumerator = State.Start();

        if (enumerator == null)
            return null;

        BattleFlowManager.Instance.StartCoroutine(enumerator);

        return state;
    }
}