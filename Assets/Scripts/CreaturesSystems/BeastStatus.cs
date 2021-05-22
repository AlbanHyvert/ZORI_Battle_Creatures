using UnityEngine;

public class BeastStatus : MonoBehaviour
{
    [SerializeField] private Effects.E_Status m_currentStatus = Effects.E_Status.NONE;
    [SerializeField] private float m_currentAfflictedDamage = 0f;
    [SerializeField] private bool m_isCold = false;
    [SerializeField] private int m_effectTurnLeft = 0;
    [SerializeField] private float m_bonusDamage = 0f;

    private E_Types[] m_types = null;
    private Health m_health = null;

    public Effects.E_Status CurrentStatus { get => m_currentStatus; }
    public int UpdateTurnLeft
    {
        get
        {
            m_effectTurnLeft--;

            if (m_effectTurnLeft <= 0)
            {
                AllReset();
                return 0;
            }

            return m_effectTurnLeft;
        }
    }

    public void Init(E_Types[] types, Health health)
    {
        m_types = types;
        m_health = health;
    }

    public void ApplyEffect(Capacity capacity)
    {
        if (m_currentStatus != Effects.E_Status.NONE)
            return;

        switch (capacity.Effect)
        {
            case Effects.E_Status.PARALYSIS:
                m_currentStatus = Effects.TryStatus(m_types, capacity);
                break;
            case Effects.E_Status.BURN:
                m_currentStatus = Effects.TryStatus(m_types, capacity);

                if (m_currentStatus == Effects.E_Status.NONE)
                    break;

                m_currentAfflictedDamage = 0.06f;

                break;
            case Effects.E_Status.FREEZE:
                if (!Effects.CanBeAffected(m_types, capacity))
                    break;

                if(m_isCold == true)
                {
                    m_currentStatus = capacity.Effect;
                    m_effectTurnLeft = 3;
                    ResetDamage();
                }
                else
                {
                    m_isCold = true;
                }
                break;
            case Effects.E_Status.POISON:
                m_currentStatus = Effects.TryStatus(m_types, capacity);

                if (m_currentStatus == Effects.E_Status.NONE)
                    break;

                m_bonusDamage = 1f;
                m_currentAfflictedDamage = 0.06f;
                
                break;
            case Effects.E_Status.SLEEP:
                m_currentStatus = Effects.TryStatus(m_types, capacity);
                break;
        }
    }

    public void ApplyDamage()
    {
        if (m_currentStatus == Effects.E_Status.NONE)
            return;

        switch (m_currentStatus)
        {
            case Effects.E_Status.BURN:
                m_health.TakeDamage((int)(m_health.maxHealth * (m_currentAfflictedDamage)));
                break;
            case Effects.E_Status.POISON:
                m_health.TakeDamage((int)(m_health.maxHealth * (m_currentAfflictedDamage * m_bonusDamage)));
                m_bonusDamage += 1f;
                break;
            case Effects.E_Status.FREEZE:
                m_effectTurnLeft--;

                if (m_effectTurnLeft <= 0)
                    AllReset();
                break;
        }
    }

    public void OnReset()
    {
        m_currentAfflictedDamage = 0f;
        m_isCold = false;
        m_effectTurnLeft = 0;
        m_bonusDamage = 0;
    }

    private void ResetDamage()
    {
        m_currentAfflictedDamage = 0f;
        m_bonusDamage = 0;
    }

    public void AllReset()
    {
        m_currentStatus = Effects.E_Status.NONE;
        OnReset();
    }
}
