using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Health))]
[RequireComponent(typeof(BaseStats), typeof(Stats), typeof(CapacityHolder))]
public class Zori : MonoBehaviour
{
    [Tooltip("The zori type(s) will affect battle, and where they can be found in the world. 2 types max.")]
    [SerializeField] private E_Types[] m_Types = null;

    private Stats m_stats = null;
    private BaseStats m_baseStats = null;
    private Health m_health = null;
    private CapacityHolder m_capacityHolder = null;
    private NavMeshAgent m_navMeshAgent = null;

    public Stats Stats { get => m_stats; }
    public Health Health { get => m_health; }
    public CapacityHolder CapacityHolder { get => m_capacityHolder; }
    public NavMeshAgent NavMesh { get => m_navMeshAgent; }

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
    }

    public int GetAttackSpeed(Capacity capacity)
    {
        int speed = 0;

        switch (capacity.Priority)
        {
            case E_Priority.ABSOLUTE:
                speed = m_stats.speed * 1000;
                break;
            case E_Priority.HIGH:
                speed = m_stats.speed * 10;
                break;
            case E_Priority.NEUTRAL:
                speed = m_stats.speed;
                break;
            case E_Priority.NEGATIVE:
                speed = m_stats.speed / 10;
                break;
            case E_Priority.ABYSSAL:
                speed = m_stats.speed / 1000;
                break;
            default:
                break;
        }

        return speed;
    }
}