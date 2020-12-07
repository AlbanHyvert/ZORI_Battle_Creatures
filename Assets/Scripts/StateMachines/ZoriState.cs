public abstract class ZoriState
{
    protected Zori Zori = null;

    public ZoriState(Zori zori)
    {
        Zori = zori;
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
