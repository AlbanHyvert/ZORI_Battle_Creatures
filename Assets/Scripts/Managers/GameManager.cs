using UnityEngine;
using ZORI_Battle_Creatures.Assets.Scripts.Tools;
using UnityEngine.SceneManagement;

namespace ZORI_Battle_Creatures.Assets.Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        private void Start()
        {
            SceneManager.LoadSceneAsync("MenuScene");
        }
    }
}