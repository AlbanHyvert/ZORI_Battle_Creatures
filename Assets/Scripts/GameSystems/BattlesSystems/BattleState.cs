using System.Collections;

public abstract class BattleState
{
    protected BattleFlowManager BattleFlowState = null;

    public BattleState(BattleFlowManager battleFlow)
    {
        BattleFlowState = battleFlow;
    }

    public virtual IEnumerator Start()
    {
        return null;
    }
    
    public virtual void Tick()
    {

    }

    public virtual void Stop()
    {

    }
}
