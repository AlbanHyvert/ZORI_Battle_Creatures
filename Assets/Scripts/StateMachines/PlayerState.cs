using UnityEngine;

public abstract class PlayerState
{
    protected GameObject Player = null;

    public PlayerState(GameObject player)
    {
        Player = player;
    }

    public virtual void Start()
    {
    }

    public virtual void Tick()
    {
    }

    public virtual void Destroy()
    {
    }
}