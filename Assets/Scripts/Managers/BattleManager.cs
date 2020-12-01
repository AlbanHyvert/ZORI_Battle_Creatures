using Utilities.Singleton;

public class BattleManager : Singleton<BattleManager>
{
    private Zori _wildZori = null;
    private BattleSystem _currentBattleSystem = null;

    public BattleSystem SetBattleSystem(BattleSystem system)
        => _currentBattleSystem = system;

    public BattleSystem GetBattleSystem()
        => _currentBattleSystem;

    public Zori SetWildZori(Zori zori)
        => _wildZori = zori;

    public Zori GetWildZori()
        => _wildZori;
}