using System;
using UnityEngine;

[System.Serializable]
public class S_HealthSystem
{
    private int _baseHp = 0;
    private int _baseMaxHp = 0;
    private int _currentHealth = 0;
    private int _maxhealth = 100;

    public int CurrentHealth { get { return _currentHealth; } set { SetHealth(value); } }
    public int MaxHealth { get { return _maxhealth; } set { SetMaxHealth(value); } }

    #region Events
    private event Action<int> _showCurrentHealth = null;
    public event Action<int> ShowCurrentHealth
    {
        add
        {
            _showCurrentHealth -= value;
            _showCurrentHealth += value;
        }
        remove
        {
            _showCurrentHealth -= value;
        }
    }

    private event Action<int> _showMaxHealth = null;
    public event Action<int> ShowMaxHealth
    {
        add
        {
            _showMaxHealth -= value;
            _showMaxHealth += value;
        }
        remove
        {
            _showMaxHealth -= value;
        }
    }
    #endregion Events

    public void Init(int baseHp, int BPHealth, int curLevel)
    {
        _baseHp = baseHp;
        _baseMaxHp = _baseHp;
        CalculateNewHealth(curLevel, BPHealth);
    }

    public void CalculateNewHealth(int curLevel, int BPHealth)
    {
        CurrentHealth = Mathf.Abs((((2 * _baseHp + (BPHealth / 4)) * curLevel) / 100) + curLevel + 10);
        MaxHealth = CurrentHealth;
    }

    private void SetHealth(int value)
    {
        _currentHealth = value;

        if(_showCurrentHealth != null)
            _showCurrentHealth(_currentHealth);
    }

    private void SetMaxHealth(int value)
    {
        _maxhealth = value;
        if (_showMaxHealth != null)
            _showMaxHealth(_maxhealth);
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;

        if(CurrentHealth < 0)
        {
            CurrentHealth = 0;
        }
    }

    public void Heal(int amount)
    {
        CurrentHealth += amount;

        if(CurrentHealth > _maxhealth)
        {
            CurrentHealth = _maxhealth;
        }
    }
}