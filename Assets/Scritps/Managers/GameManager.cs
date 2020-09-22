using Engine.Singleton;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private void Start()
    {
        SceneManager.LoadSceneAsync("BattleScene");
    }
}
