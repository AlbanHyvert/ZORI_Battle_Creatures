using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IAController : MonoBehaviour
{
    [SerializeField] private D_StatSystem _baseStats = null;
    [Space]
    [SerializeField] private S_BattlePointSystem _battleSystem = new S_BattlePointSystem();
    [Space]
    [SerializeField] private List<D_AttackSystem> _moveList = new List<D_AttackSystem>();
    [Space]
    [SerializeField] private bool _hasStartedTheBattle = false;
    [Space]
    [Header("Status")]
    [SerializeField] private E_OwnerState _ownedStatus = E_OwnerState.WILD;
    [SerializeField] private E_WorldState _currentWorldState = E_WorldState.PATROLLING;

    #region Base
    private int _baseMaxExperience = 100;
    #endregion Base

    #region Current
    private Dictionary<E_Slots, D_AttackSystem> _dicMoves = null;
    private Dictionary<E_BattleState, IBattleState> _battleStates = null;
    private Dictionary<E_WorldState, IWorldState> _worldStates = null;
    private E_BattleState _currentBattleState = E_BattleState.WAITTURN;
    private S_HealthSystem _healthSystem = new S_HealthSystem();
    private S_StatSystem _stats = new S_StatSystem();
    private PlayerController _player = null;
    private string _descText = string.Empty;
    private int _level = 1;
    private float _experience = 0;
    private float newXPValue = 0;
    private float _timeXP = 0;
    private bool _isInBattle = false;
    private int _maxExperience = 100;
    #endregion Current

    #region Properties
    #region Get
    public S_StatSystem GetStats { get { return _stats; } }
    public S_HealthSystem GetHealth { get { return _healthSystem; } }
    public int GetLevel { get { return _level; } }
    public float GetExperience { get { return _experience; } }
    public int GetMaxExperience { get { return _maxExperience; } }
    public List<D_AttackSystem> GetMoveList { get { return _moveList; } }
    public Dictionary<E_Slots, D_AttackSystem> GetDicMoves { get { return _dicMoves; } }
    public bool GetHasStartedTheBattle { get { return _hasStartedTheBattle; } }
    public PlayerController GetPlayer { get { return _player; } }
    public bool GetIsInBattle { get { return _isInBattle; } }
    public E_OwnerState GetOwnerStatus { get { return _ownedStatus; } }
    #endregion Properties

    #region Set
    public PlayerController SetPlayer { set { _player = value; } }
    public string DescText
    {
        set
        {
            _descText = value;
            _actionText(_descText);
        } 
    }
    public bool SetIsInBattle { set { _isInBattle = value; } }
    public E_OwnerState SetOwnerStatus { set { _ownedStatus = value; } }
    #endregion Set
    #endregion Properties

    #region Events
    private event Action<string> _actionText = null;
    public event Action<string> ActionText
    {
        add
        {
            _actionText -= value;
            _actionText += value;
        }
        remove
        {
            _actionText -= value;
        }
    }

    private event Action<float> _updateExperience = null;
    public event Action<float> UpdateExperience
    {
        add
        {
            _updateExperience -= value;
            _updateExperience += value;
        }
        remove
        {
            _updateExperience -= value;
        }
    }
    #endregion Events

    #region Setup Events
    private void AddLevel(int amount)
    {
        _level += amount;

        _healthSystem.CalculateNewHealth(_level, _battleSystem.GetBPHp);

        _stats.CalculateStats(_level, _battleSystem.GetBPAtk, _battleSystem.GetBPDef, _battleSystem.GetBPSpeAtk, _battleSystem.GetBPSpeDef, _battleSystem.GetBPSpeed);
    }

    public void SetXP(float amount)
    {
        newXPValue = (_experience + amount);

        float diffBeforeLevelUp = newXPValue - _maxExperience;

        if (diffBeforeLevelUp > 0)
        {
            AddLevel(1);
            _experience = 0;
            _maxExperience = Mathf.Abs((((2 * _baseMaxExperience) * _level) / 10) + _level + 100);
            SetXP(diffBeforeLevelUp);
        }
    }

    private void SetMoves()
    {
        if (_moveList[0] != null)
        {
            _dicMoves.Add(E_Slots.A, _moveList[0]);
        }

        if (_moveList[1] != null)
        {
            _dicMoves.Add(E_Slots.B, _moveList[1]);
        }

        if (_moveList[2] != null)
        {
            _dicMoves.Add(E_Slots.C, _moveList[2]);
        }

        if (_moveList[3] != null)
        {
            _dicMoves.Add(E_Slots.D, _moveList[3]);
        }
    }

    private void SetBattleStates()
    {
        _battleStates.Add(E_BattleState.ACTIONTURN, new ActionState());
        _battleStates.Add(E_BattleState.WAITTURN, new WaitTurnState());
        _battleStates.Add(E_BattleState.ENDTURN, new EndTurnState());

        _currentBattleState = E_BattleState.WAITTURN;

        _battleStates[E_BattleState.ACTIONTURN].Init(this);
        _battleStates[E_BattleState.WAITTURN].Init(this);
        _battleStates[E_BattleState.ENDTURN].Init(this);

        ChangeBattleState(_currentBattleState);
    }

    private void SetWorldStates()
    {

    }

    private void GetCurrentHealth(int health)
    {
        if (health <= 0)
        {
            ChangeBattleState(E_BattleState.WAITTURN);
            ChangeWorldState(E_WorldState.KO);
            GameLoopManager.Instance.UpdateZori -= OnUpdate;
        }
    }
    #endregion Setup Events

    private void Awake()
    {
        Init();

        SetIsInBattle = true;
    }

    private void Init()
    {
        _level = _baseStats.GetLevel;
        _baseMaxExperience = _baseStats.GetBaseMaxExperience;
        _stats.Init(_baseStats, _baseStats.GetBehavior, _baseStats.GetTypes, _battleSystem, _level);

        _healthSystem.Init(_baseStats.GetBaseHp, _battleSystem.GetBPHp, _level);

        _maxExperience = Mathf.Abs((((2 * _baseMaxExperience) * _level) / 10) + _level + 100);

        SetXP(300);
    }

    private void Start()
    {
        _dicMoves = new Dictionary<E_Slots, D_AttackSystem>();

        _battleStates = new Dictionary<E_BattleState, IBattleState>();

        _worldStates = new Dictionary<E_WorldState, IWorldState>();

        SetMoves();

        SetBattleStates();

        SetWorldStates();

        _healthSystem.ShowCurrentHealth += GetCurrentHealth;
    }

    private void OnUpdate()
    {
        if(_isInBattle == true)
        {
            _battleStates[_currentBattleState].Tick();
        }
        else
        {

        }

        UIExperienceVisualised();
    }

    private void UIExperienceVisualised()
    {
        _timeXP += 0.05f * Time.deltaTime;

        _experience = Mathf.Lerp(_experience, newXPValue, _timeXP);

        if (_updateExperience != null)
            _updateExperience(_experience);

        if (_experience >= newXPValue - 0.2f)
        {
            _experience = newXPValue;
            _timeXP = 0;
        }
    }

    public void ChangeBattleState(E_BattleState nextState)
    {
        _battleStates[_currentBattleState].Exit();

        if (GameLoopManager.Instance != null)
            GameLoopManager.Instance.UpdateZori -= OnUpdate;

        _currentBattleState = nextState;
        _battleStates[nextState].Enter();

        if (GameLoopManager.Instance != null)
            GameLoopManager.Instance.UpdateZori += OnUpdate;
    }

    public void ChangeWorldState(E_WorldState nextState)
    {
        _worldStates[_currentWorldState].Exit();

        if (GameLoopManager.Instance != null)
            GameLoopManager.Instance.UpdateZori -= OnUpdate;

        _currentWorldState = nextState;
        _worldStates[nextState].Enter();

        if (GameLoopManager.Instance != null)
            GameLoopManager.Instance.UpdateZori += OnUpdate;
    }

    private void OnDestroy()
    {
        if(GameLoopManager.Instance != null)
            GameLoopManager.Instance.UpdateZori -= OnUpdate;

        _healthSystem.ShowCurrentHealth -= GetCurrentHealth;
    }
}