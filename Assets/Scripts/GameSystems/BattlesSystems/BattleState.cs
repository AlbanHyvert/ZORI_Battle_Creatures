public abstract class BattleState
{
    protected BattleFlowManager BattleFlowState = null;

    public BattleState(BattleFlowManager battleFlow)
    {
        BattleFlowState = battleFlow;
    }

    public virtual void Start()
    {

    }

    public virtual void Tick()
    {

    }

    public virtual void Stop()
    {

    }
}
