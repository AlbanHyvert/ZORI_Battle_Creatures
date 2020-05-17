using Engine.Loading;
using System.Collections.Generic;

public class GameState : IGamesStates
{
    private List<string> _nameList = new List<string>();

    void IGamesStates.Enter()
    {
        LoadingManager.Instance.LoadScene("GameScene");
    }

    void IGamesStates.Exit()
    {
        LoadingManager.Instance.UnloadScene("GameScene");
    }
}
