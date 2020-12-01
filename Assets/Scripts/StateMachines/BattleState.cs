public abstract class BattleState
{
    protected BattleSystem BattleSystem = null;

    public  BattleState(BattleSystem battleSystem)
    {
        BattleSystem = battleSystem;
    }

    public void Start()
    {
    }

    public void Tick()
    {
    }

    public void EndTurn()
    {
    }
}
