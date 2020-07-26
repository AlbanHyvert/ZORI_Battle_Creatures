using Engine.Singleton;
using System;

public class GameLoopManager : Singleton<GameLoopManager>
{
    private event Action _updateZori = null;
    public event Action UpdateZori
    {
        add
        {
            _updateZori -= value;
            _updateZori += value;
        }
        remove
        {
            _updateZori -= value;
        }
    }

    private event Action _updateManager = null;
    public event Action UpdateManager
    {
        add
        {
            _updateManager -= value;
            _updateManager += value;
        }
        remove
        {
            _updateManager -= value;
        }
    }

    private void FixedUpdate()
    {
        if (_updateZori != null)
            _updateZori();

        if (_updateManager != null)
            _updateManager();
    }
}
