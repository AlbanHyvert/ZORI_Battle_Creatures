using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Health))]
[RequireComponent(typeof(BaseStats), typeof(Stats), typeof(CapacityHolder))]
public class Zori : MonoBehaviour
{
    [Tooltip("The zori type(s) will affect battle, and where they can be found in the world. 2 types max.")]
    [SerializeField] private E_Types[] m_Types = null;
    [Tooltip("In witch state the zori is at the moment")]
    [SerializeField] private Effects.E_Effects m_currentEffect = Effects.E_Effects.NONE;

    private Stats m_stats = null;
    private BaseStats m_baseStats = null;
    private Health m_health = null;
    private CapacityHolder m_capacityHolder = null;
    private NavMeshAgent m_navMeshAgent = null;
    private float m_currentPoisonDamage = 0.06f;
    private bool m_isCold = false;

    public Stats Stats { get => m_stats; }
    public Health Health { get => m_health; }
    public CapacityHolder CapacityHolder { get => m_capacityHolder; }
    public NavMeshAgent NavMesh { get => m_navMeshAgent; }
    public E_Types[] Types { get => m_Types; }
    public Effects.E_Effects CurrentEffect { get => m_currentEffect; set => m_currentEffect = value; }
    public float CurrentPoisonDmg { get => m_currentPoisonDamage; set => m_currentPoisonDamage = value; }
    public bool IsCold { get => m_isCold; set => m_isCold = value; }

    private void Awake()
    {
        m_health = GetComponent<Health>();
        m_stats = GetComponent<Stats>();
        m_baseStats = GetComponent<BaseStats>();
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        m_capacityHolder = GetComponent<CapacityHolder>();

        m_health.Init(m_stats);
        m_stats.Init(m_baseStats);
        m_capacityHolder.Init();

        m_health.onDie += OnDie;
    }

    private void OnDie()
    {
        CurrentPoisonDmg = 0.06f;
        CurrentEffect = Effects.E_Effects.NONE;
    }

    public int GetAttackSpeed(Capacity capacity)
    {
        if (capacity == null)
            return 0;

        switch (capacity.Priority)
        {
            case E_Priority.ABSOLUTE:
                return m_stats.speed * 1000;
            case E_Priority.HIGH:
                return m_stats.speed * 10;
            case E_Priority.NEUTRAL:
                return m_stats.speed;
            case E_Priority.NEGATIVE:
                return m_stats.speed / 10;
            case E_Priority.ABYSSAL:
                return m_stats.speed / 1000;
        }

        return 0;
    }
}