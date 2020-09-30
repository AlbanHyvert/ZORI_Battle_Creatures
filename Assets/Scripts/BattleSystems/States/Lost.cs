using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace ZORI_Battle_Creatures.Assets.Scripts.BattleSystems.States
{
    public class Lost : State
    {
        public Lost(BattleSystem battleSystem) : base(battleSystem)
        {

        }

        public override IEnumerator Start()
        {
            Debug.Log("You Lost");

            yield return new WaitForSecondsRealtime(2);

            BattleSystem.SetMatchFinish = true;

            SceneManager.LoadSceneAsync("MenuScene");

            yield break;
        }
    }
}