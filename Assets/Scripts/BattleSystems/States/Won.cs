using ZORI_Battle_Creatures.Assets.Scripts.Utilities;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

namespace ZORI_Battle_Creatures.Assets.Scripts.BattleSystems.States
{
    public class Won : State
    {
        public Won(BattleSystem battleSystems) : base(battleSystems)
        {
            
        }

        public override IEnumerator Start()
        {
            Debug.Log("You Win");

            BattleSystem.GetZoriPlayer.GainExperience(BattleUtilities.CalculateExperienceGain(BattleSystem.GetZoriEnnemy));

            BattleSystem.GetZoriPlayer.SetBattlePoints(BattleSystem.GetZoriEnnemy.GetGivenBattlePoints);

            yield return new WaitForSecondsRealtime(2);

            BattleSystem.SetMatchFinish = true;

            SceneManager.LoadSceneAsync("MenuScene");

            yield break;
        }
    }
}