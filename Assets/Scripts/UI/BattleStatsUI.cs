using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleStatsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name = null;
    [SerializeField] private TextMeshProUGUI _level = null;
    [Space]
    [SerializeField] private Slider _health = null;
    [SerializeField] private TextMeshProUGUI _healthText = null;
    [Space]
    [SerializeField] private TextMeshProUGUI _descriptionText = null;

    private Zori _zori = null;

    public TextMeshProUGUI descriptionText { get => _descriptionText; }

    public void Init(Zori zori)
    {
        _zori = zori;

        _name.text = zori.Stats.nickname;
        _level.text = "Level: " + zori.Stats.level.ToString();
        _health.minValue = 0;
        _health.maxValue = zori.Health.maxHealth;
        _health.value = zori.Health.currentHealth;
        _healthText.text = "HP:" + zori.Health.currentHealth.ToString() + "/" + zori.Health.maxHealth.ToString();

        _descriptionText.text = string.Empty;

        zori.Health.onCurrentHealth += UpdateHealth;
    }

    private void UpdateHealth(int value)
    {
        _health.value = value;
        _healthText.text = "HP:" + value + "/" + _zori.Health.maxHealth.ToString();
    }
}