using Engine.Loading;

public class MainMenuState : IGamesStates
{
    void IGamesStates.Enter()
    {
        LoadingManager.Instance.LoadScene("MENU");
    }

    void IGamesStates.Exit()
    {
        LoadingManager.Instance.UnloadScene("MENU");
    }
}
