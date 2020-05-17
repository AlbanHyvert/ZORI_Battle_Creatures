using Engine.Loading;

public class DevState : IGamesStates
{
    void IGamesStates.Enter()
    {
        LoadingManager.Instance.LoadScene("DEV");
    }

    void IGamesStates.Exit()
    {
        LoadingManager.Instance.UnloadScene("DEV");
    }
}
