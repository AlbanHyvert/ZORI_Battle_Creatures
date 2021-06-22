using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Effects))]
[CreateAssetMenu(fileName = "Capacity", menuName = "Creatures/Zori/Capacity")]
public class Capacity : ScriptableObject
{
    [Tooltip("The name of the capacity, as no use in combat except identifying the attack.")]
    [SerializeField] private string m_name = string.Empty;
    [Tooltip("The capacity position in the idex. No use in combat.")]
    [SerializeField, Range(0,1000)] private int m_index = 0;
    [Tooltip("The brut power of the capacity.")]
    [SerializeField, Range(0, 1000)] private int m_power = 10;
    [Tooltip("The number of time the capacity can be used.")]
    [SerializeField, Range(0,100)] private int m_maxUse = 10;
    [Tooltip("The type of the capacity.")]
    [SerializeField] private E_Types m_type = E_Types.NEUTRAL;
    [Tooltip("The priority of the attack.")]
    [SerializeField] private E_Priority m_priority = E_Priority.NEUTRAL;
    [Tooltip("Attack Type")]
    [SerializeField] private E_Style _style = E_Style.PHYSICS; 
    [SerializeField] private Effects.E_Status _effects = Effects.E_Status.NONE;
    [SerializeField] private BonusStat m_bonusStat = new BonusStat();
    [Space]
    [SerializeField] private E_Target e_Target = E_Target.ENNEMY;
    [Space]
    [Tooltip("The quantity of use left.")]
    [Range(0, 100)] private int m_currentUse = 10;
    

    public UnityAction<int> onUse = null;

    [System.Serializable]
    public struct BonusStat
    {
        public float speed;
        public float attack;
        public float def;
        public float speAtk;
        public float speDef;
    }

    public string Name { get => m_name; }
    public int Index { get => m_index; }
    public int Power { get => m_power; }
    public E_Types Type { get => m_type; }
    public E_Priority Priority { get => m_priority; }
    public E_Style Style { get => _style; }
    public Effects.E_Status Effect { get => _effects; }
    public int CurrentUse { get => m_currentUse; }
    public BonusStat BonusStats { get => m_bonusStat; }
    public E_Target Target { get => e_Target; }
    public int MaxUse { get => m_maxUse;
        set
        {
            m_maxUse = value;
            m_currentUse = value;
        }
    }

    public void Init()
    {
        m_currentUse = m_maxUse;
    }

    public Capacity UseCapacity()
    {
        if (m_currentUse > 0)
        {
            m_currentUse--;

            if (onUse != null)
                onUse.Invoke(m_currentUse);

            return this;
        }
        else
            return null;
    }

    public Capacity CheckCapacity()
        => this;
}