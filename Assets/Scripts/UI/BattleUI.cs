using UnityEngine;
using TMPro;
using ZORI_Battle_Creatures.Assets.Scripts.Bestarium;
using UnityEngine.UI;

namespace ZORI_Battle_Creatures.Assets.Scripts.UI
{
    public class BattleUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name = null;
        [SerializeField] private TextMeshProUGUI _level = null;
        [Space]
        [SerializeField] private Button[] _attackButtons = null;
        [Space]
        [SerializeField] private Slider _lifeBar = null;
        [SerializeField] private Slider _experienceBar = null;
        
        private ZoriController _zori = null;

        public void Init(ZoriController zori)
        {
            _lifeBar.minValue = 0;

            _lifeBar.maxValue = zori.GetData.stats.maxHp;
            _lifeBar.value = zori.GetCurrentHealth;

            _experienceBar.minValue = 0;
            _experienceBar.maxValue = zori.GetData.stats.maxExperience;

            _experienceBar.value = zori.GetData.stats.experience;

            zori.UpdateHp += UpdateLifeBar;
            zori.UpdateExperience += UpdateXpBar;

            _name.text = zori.GetData.nickName;
            _level.text = "Level: " + zori.GetData.stats.level.ToString();

            _zori = zori;
        }

        private void UpdateLifeBar(int value)
        {
            _lifeBar.value = value;
        }

        private void UpdateXpBar(float amount)
        {
            _experienceBar.value = amount;
        }   

        private void UpdateLevel(int amount)
        {
            _level.text = "Level: " + amount.ToString();
        }

        private void OnDestroy()
        {
            _zori.UpdateHp -= UpdateLifeBar;
            _zori.UpdateExperience -= UpdateXpBar;
        }
    }
}