using Engine.Loading;

public class LoadingState : IGamesStates
{
    void IGamesStates.Enter()
    {
        LoadingManager.Instance.LoadScene("LOADING");
    }

    void IGamesStates.Exit()
    {
        LoadingManager.Instance.UnloadScene("LOADING");
    }
}
