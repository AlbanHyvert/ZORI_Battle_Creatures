public abstract class BattleState
{
    protected BattleSystem BattleSystem = null;

    public  BattleState(BattleSystem battleSystem)
    {
        BattleSystem = battleSystem;
    }

    public virtual void Start()
    {
    }

    public virtual void Tick()
    {
    }

    public virtual void EndTurn()
    {
    }
}
