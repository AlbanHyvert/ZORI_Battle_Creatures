using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Health))]
[RequireComponent(typeof(BaseStats), typeof(Stats), typeof(CapacityHolder))]
[RequireComponent(typeof(BeastStatus), typeof(BeastBonusEffects))]
public class Zori : MonoBehaviour
{
    [Tooltip("The zori type(s) will affect battle, and where they can be found in the world. 2 types max.")]
    [SerializeField] private E_Types[] m_types = null;
    [Tooltip("In witch state the zori is at the moment")]
    [SerializeField] private BeastStatus m_status = null;
    [SerializeField] private BeastBonusEffects m_bonusEffect = null;

    private Stats m_stats = null;
    private BaseStats m_baseStats = null;
    private Health m_health = null;
    private CapacityHolder m_capacityHolder = null;
    private NavMeshAgent m_navMeshAgent = null;

    public Stats Stats { get => m_stats; }
    public Health Health { get => m_health; set => m_health = value; }
    public CapacityHolder CapacityHolder { get => m_capacityHolder; }
    public NavMeshAgent NavMesh { get => m_navMeshAgent; }
    public E_Types[] Types { get => m_types; }
    public BeastStatus GetStatus { get => m_status; }
    public BeastBonusEffects GetBonusEffect { get => m_bonusEffect; }

    private void Awake()
    {
        m_status = GetComponent<BeastStatus>();
        m_health = GetComponent<Health>();
        m_stats = GetComponent<Stats>();
        m_baseStats = GetComponent<BaseStats>();
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        m_capacityHolder = GetComponent<CapacityHolder>();
        m_bonusEffect = GetComponent<BeastBonusEffects>();

        m_health.Init(m_stats);
        m_stats.Init(m_baseStats);
        m_capacityHolder.Init();
        m_status.Init(m_types, m_health);
        m_bonusEffect.Reset();

        m_health.onDie += OnDie;
    }

    private void OnDie()
    {
        m_status.AllReset();
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