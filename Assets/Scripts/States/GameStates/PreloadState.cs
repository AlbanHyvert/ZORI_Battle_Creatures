using Engine.Loading;

public class PreloadState : IGamesStates
{
    void IGamesStates.Enter()
    {
        LoadingManager.Instance.LoadScene("PreloadScene");
    }

    void IGamesStates.Exit()
    {
        
    }
}