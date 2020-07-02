using Engine.Singleton;

public class BattleManager : Singleton<BattleManager>
{
    private IA_Zori _playerZori = null;
    private IA_Zori _wildZori = null;

    public IA_Zori PlayerZori { get { return _playerZori; } set { _playerZori = value; } }
    public IA_Zori WildZori { get { return _wildZori; } set { _wildZori = value; } }
}