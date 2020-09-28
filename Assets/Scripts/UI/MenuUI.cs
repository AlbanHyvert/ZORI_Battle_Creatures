using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ZORI_Battle_Creatures.Assets.Scripts.UI
{
    public class MenuUI : MonoBehaviour
    {
        public void StartBattle()
        {
            SceneManager.LoadSceneAsync("BattleScene");
        }
    }
}