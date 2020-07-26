using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Zori : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name = null;
    [SerializeField] private TextMeshProUGUI _level = null;
    [SerializeField] private TextMeshProUGUI _description = null;
    [SerializeField] private Slider _health = null;

    private IAController _zori = null;

    private void Start()
    {
        _health.minValue = 0;
    }

    public void Init(IAController zori)
    {
        _health.maxValue = zori.GetHealth.MaxHealth;
        _health.value = zori.GetHealth.CurrentHealth;

        _name.text = zori.GetStats.GetName;
        _level.text = zori.GetLevel.ToString();

        zori.GetHealth.ShowCurrentHealth += OnHPChanged;
        zori.ActionText += OnDescription;

        _zori = zori;
    }

    private void OnHPChanged(int value)
    {
        _health.value = value;
    }

    private void OnDescription(string text)
    {
        _description.text = text;
    }

    private void OnDestroy()
    {
        _zori.GetHealth.ShowCurrentHealth -= OnHPChanged;
        _zori.ActionText -= OnDescription;
        _zori = null;
    }
}