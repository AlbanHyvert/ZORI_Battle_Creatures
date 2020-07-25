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

    private void FixedUpdate()
    {
        if (_updateZori != null)
            _updateZori();
    }
}
