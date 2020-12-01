using UnityEngine;

public abstract class PlayerState
{
    protected GameObject Player = null;

    public PlayerState(GameObject player)
    {
        Player = player;
    }

    public void Start()
    {
    }

    public void Tick()
    {
    }

    public void Destroy()
    {
    }
}