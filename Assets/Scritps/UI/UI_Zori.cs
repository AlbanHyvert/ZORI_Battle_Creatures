using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Zori : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name = null;
    [SerializeField] private TextMeshProUGUI _level = null;
    [SerializeField] private TextMeshProUGUI _description = null;
    [SerializeField] private Slider _health = null;
    [SerializeField] private Slider _experience = null;
    [SerializeField] private Image _fill = null;
    [Space]
    [SerializeField] private GameObject _actionUI = null;
    [Space]
    [SerializeField] private bool _isCloserToCam = false;

    private IAController _zori = null;
    private int midHp = 0;
    private int lowHp = 0;

    public GameObject GetActionUI { get { return _actionUI; } }
    public bool GetIsCloserToCam { get { return _isCloserToCam; } }

    private void Awake()
    {
        _health.minValue = 0;
        BattleManager.Instance.GetUI_Zoris.Add(this);
    }

    public void Init(IAController zori)
    {
        _health.maxValue = zori.GetHealth.MaxHealth;
        _health.value = zori.GetHealth.CurrentHealth;

        _experience.maxValue = zori.GetMaxExperience;
        _experience.value = zori.GetExperience;

        midHp = (int)_health.maxValue / 2;
        lowHp = (int)Mathf.Abs(_health.maxValue / 2.5f);

        _name.text = zori.GetStats.GetName;
        _level.text = "Lvl:" + " " + zori.GetLevel.ToString();

        zori.GetHealth.ShowCurrentHealth += OnHPChanged;
        zori.ActionText += OnDescription;
        zori.UpdateExperience += OnExperienceChanged;

        _zori = zori;
    }

    private void OnHPChanged(int value)
    {
        _health.value = value;

        if(_health.value >= midHp)
        {
            _fill.color = new Color(0, 255, 0);
        }
        else if(_health.value >= lowHp && _health.value < midHp)
        {
            _fill.color = new Color(255, 177, 0);
        }
        else if(_health.value < lowHp)
        {
            _fill.color = new Color(255, 0, 0);
        }
    }

    private void OnExperienceChanged(float value)
    {
        _experience.value = value;
    }

    private void OnDescription(string text)
    {
        _description.text = text;
    }

    private void OnDestroy()
    {
        _zori.GetHealth.ShowCurrentHealth -= OnHPChanged;
        _zori.ActionText -= OnDescription;
        _zori.UpdateExperience -= OnExperienceChanged;
        _zori = null;
    }
}