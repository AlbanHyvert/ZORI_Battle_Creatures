using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _baseHealth = 0;
    [Tooltip("Maximum amount of health")]
    [SerializeField] private int _maxHealth = 10;
    [Tooltip("Health ratio at which the critical health vignette starts appearing")]
    [SerializeField] private float _criticalHealthRatio = 0.3f;

    public UnityAction<float> onDamaged;
    public UnityAction<float> onHealed;
    public UnityAction onDie;

    public float currentHealth { get; set; }
    public bool invincible { get; set; }
    public bool canPickup() => currentHealth < _maxHealth;

    public float getRatio() => currentHealth / _maxHealth;
    public bool isCritical() => getRatio() <= _criticalHealthRatio;

    private bool m_IsDead = false;
    private Stats m_stats = null;

    public void Init(Stats stats = null)
    {
        currentHealth = _maxHealth;
        m_stats = stats;
        m_stats.onGainedLevel += CalculateNewHealth;
    }

    public void CalculateNewHealth()
    {
        _maxHealth = ((2 * _baseHealth + 5 + (m_stats.GetBP().health / 4)) * m_stats.level) / 50 + m_stats.level + 10;

        currentHealth = _maxHealth;
    }

    public void Heal(float healAmount)
    {
        float healthBefore = currentHealth;
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, _maxHealth);

        // call OnHeal action
        float trueHealAmount = currentHealth - healthBefore;
        if (trueHealAmount > 0f && onHealed != null)
        {
            onHealed.Invoke(trueHealAmount);
        }
    }

    public void TakeDamage(float damage)
    {
        if (invincible)
            return;

        float healthBefore = currentHealth;
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, _maxHealth);

        // call OnDamage action
        float trueDamageAmount = healthBefore - currentHealth;
        if (trueDamageAmount > 0f && onDamaged != null)
        {
            onDamaged.Invoke(trueDamageAmount);
        }

        HandleDeath();
    }

    public void Kill()
    {
        currentHealth = 0f;

        // call OnDamage action
        if (onDamaged != null)
        {
            onDamaged.Invoke(_maxHealth);
        }

        HandleDeath();
    }

    private void HandleDeath()
    {
        if (m_IsDead)
            return;

        // call OnDie action
        if (currentHealth <= 0f)
        {
            if (onDie != null)
            {
                m_IsDead = true;
                onDie.Invoke();
            }
        }
    }
}
