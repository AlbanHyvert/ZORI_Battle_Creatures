using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class IA_Zori : MonoBehaviour
{
    #region SERIALIZED
    [SerializeField] private BaseZori _stats = null;
    [Space, Header("Other Stats")]
    [SerializeField] private E_CapacitySlot _favAttack = E_CapacitySlot.SLOT_A;
    [SerializeField] private E_ZoriStates _startingState = E_ZoriStates.WALKING;
    [SerializeField] private E_ZoriWorldStatus _status = E_ZoriWorldStatus.WILD;
    [Space, Header("View Field")]
    [SerializeField] private float _viewField = 70;
    [Space, Header("Animatior")]
    [SerializeField] private Animator _animator = null;
    [Space, Header("Audio")]
    [SerializeField] private AudioSource _audioSource = null;
    [SerializeField] private AudioClip[] _walkingAudio = null;
    [SerializeField] private AudioClip[] _chasingAudio = null;
    [SerializeField] private AudioClip[] _battleAudio = null;
    [SerializeField] private AudioClip[] _koAudio = null;
    [Space, Header("Target")]
    [SerializeField] private LayerMask _target = 0;
    #endregion SERIALIZED

    #region PRIVATE
    private PlayerController _player = null;
    private NavMeshAgent _agent = null;
    private Dictionary<E_ZoriStates, IZoriStates> _states = null;
    private Dictionary<E_CapacitySlot, ZoriMoves> _moves = null;
    private ZoriMoves[] _capacities = null;
    private E_ZoriStates _currentState = E_ZoriStates.WALKING;
    private string _name = string.Empty;
    private Sprite _icon = null;
    private BaseStats _attackStats = null;
    private BaseStats _defenseStats = null;
    private BaseStats _HPStats = null;
    private bool _isMyTurn = false;
    [Range(1, 999)] private int _level = 1;
    private float _experience = 0;
    private E_Regions _biomeFound = E_Regions.EAST;
    private E_ZoriTypes _type = E_ZoriTypes.AERO;
    private E_ZoriRarity _rarity = E_ZoriRarity.COMMON;
    #endregion PRIVATE

    #region PROPERTIES
    public PlayerController Player { get { return _player; } }
    public NavMeshAgent Agent { get => _agent; }
    public string Name { get => _name; set => _name = value; }
    public Sprite Icon { get => _icon; set => _icon = value; }
    public BaseStats AttackStats { get => _attackStats; set => _attackStats = value; }
    public BaseStats DefenseStats { get => _defenseStats; set => _defenseStats = value; }
    public BaseStats HPStats { get => _HPStats; set => _HPStats = value; }
    public ZoriMoves[] Capacities { get { return _capacities; } }
    public Dictionary<E_CapacitySlot, ZoriMoves> Moves { get { return _moves; } }
    public bool IsMyTurn { get { return _isMyTurn; } set { _isMyTurn = value; } }
    public float ViewField { get => _viewField; }
    public int Level { get => _level; }
    public float Experience { get => _experience; set => AddExperience(value); }
    public E_CapacitySlot FavAttack { get => _favAttack; }
    public E_Regions BiomeFound { get => _biomeFound; set => _biomeFound = value; }
    public E_ZoriTypes Type { get => _type; set => _type = value; }
    public E_ZoriRarity Rarity { get => _rarity; set => _rarity = value; }
    public E_ZoriWorldStatus Status { get { return _status; } set { _status = value; } }
    public LayerMask Target { get { return _target; } }
    public Animator Animator { get => _animator; }
    public AudioSource AudioSource { get => _audioSource; }
    public AudioClip[] WalkingAudio { get => _walkingAudio; }
    public AudioClip[] ChasingAudio { get => _chasingAudio; }
    public AudioClip[] BattleAudio { get => _battleAudio; }
    public AudioClip[] KoAudio { get => _koAudio; }
    #endregion PROPERTIES

    private void TakeDamage(int value)
    {
        HPStats.Minimum -= value;

        if (HPStats.Minimum < 0)
            HPStats.Minimum = 0;
    }

    private void TakeHeal(int value)
    {
        HPStats.Minimum += value;

        if (HPStats.Minimum > HPStats.Maximum)
            HPStats.Minimum = HPStats.Maximum;
    }

    private void AddExperience(float value)
    {
        _experience += value;

        float diffBeforeLevelUp = _experience - 100;

        if(diffBeforeLevelUp > 0)
        {
            AddLevelUp(1);
            _experience = 0;
            AddExperience(diffBeforeLevelUp);
        }
    }

    private void AddLevelUp(int value)
    {
        //Sound FX
        _level += value;
    }

    private void Init()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = PlayerManager.Instance.PlayerInstance;
        _name = _stats.name;
        _icon = _stats.Icon;
        _attackStats = _stats.AttackStats;
        _defenseStats = _stats.DefenseStats;
        _HPStats = _stats.HPStats;
        _level = _stats.Level;
        _experience = _stats.Experience;
        _biomeFound = _stats.BiomeFound;
        _type = _stats.Type;
        _rarity = _stats.Rarity;
        _capacities = _stats.Capacities;
    }

    private void Start()
    {
        _states = new Dictionary<E_ZoriStates, IZoriStates>();
        _moves = new Dictionary<E_CapacitySlot, ZoriMoves>();

        _currentState = _startingState;

        _states.Add(E_ZoriStates.WALKING, new Z_WalkingState());
        _states.Add(E_ZoriStates.CHASING, new Z_ChasingState());
        _states.Add(E_ZoriStates.BATTLE, new Z_BattleState());
        _states.Add(E_ZoriStates.KO, new Z_KOState());

        Init();

        _moves.Add(E_CapacitySlot.SLOT_A, _capacities[0]);
        _moves.Add(E_CapacitySlot.SLOT_B, _capacities[1]);
        _moves.Add(E_CapacitySlot.SLOT_C, _capacities[2]);
        _moves.Add(E_CapacitySlot.SLOT_D, _capacities[3]);

        _states[E_ZoriStates.WALKING].Init(this);
        _states[E_ZoriStates.CHASING].Init(this);
        _states[E_ZoriStates.BATTLE].Init(this);
        _states[E_ZoriStates.KO].Init(this);

        GameLoopManager.Instance.Moki += OnUpdate;

        ChangeCurrentState(_currentState);
    }

    private void OnUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Experience = 70;
        }

        _states[_currentState].Tick();
    }

    public void ChangeCurrentState(E_ZoriStates nextState)
    {
        _states[_currentState].Exit();
        _currentState = nextState;
        _states[nextState].Enter();
    }
}