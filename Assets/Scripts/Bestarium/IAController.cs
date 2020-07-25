using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class IAController : MonoBehaviour
{
    [SerializeField] private D_StatSystem _baseStats = null;
    [Space]
    [SerializeField] private S_BattlePointSystem _battleSystem = new S_BattlePointSystem();
    [Space]
    [SerializeField] private List<D_AttackSystem> _moveList = new List<D_AttackSystem>();
    [Space]
    [SerializeField] private bool _hasStartedTheBattle = false;

    #region Base
    private int _baseMaxExperience = 100;
    #endregion Base

    #region Current
    private Dictionary<E_Slots, D_AttackSystem> _dicMoves = null;
    private Dictionary<E_BattleState, IBattleState> _states = null;
    private E_BattleState _currentState = E_BattleState.WAITTURN;
    private S_HealthSystem _healthSystem = new S_HealthSystem();
    private S_StatSystem _stats = new S_StatSystem();
    private PlayerController _player = null;
    private int _level = 1;
    private float _experience = 0;
    private float newXPValue = 0;
    private float _timeXP = 0;
    private int _maxExperience = 100;
    #endregion Current

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
    #endregion Properties

    #region Set
    public PlayerController SetPlayer { set { _player = value; } }
    #endregion Set

    private void AddLevel(int amount)
    {
        _level += amount;

        _healthSystem.CalculateNewHealth(_level, _battleSystem.GetBPHp);

        _stats.CalculateStats(_level, _battleSystem.GetBPAtk, _battleSystem.GetBPDef, _battleSystem.GetBPSpeAtk, _battleSystem.GetBPSpeDef, _battleSystem.GetBPSpeed);
    }

    public void SetXP(float amount)
    {
        newXPValue = (_experience + amount);

        float diffBeforeLevelUp = _experience - _maxExperience;

        if(diffBeforeLevelUp > 0)
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

    private void SetStates()
    {
        _states.Add(E_BattleState.ACTIONTURN, new ActionState());
        _states.Add(E_BattleState.WAITTURN, new WaitTurnState());
        _states.Add(E_BattleState.ENDTURN, new EndTurnState());

        _currentState = E_BattleState.WAITTURN;

        _states[E_BattleState.ACTIONTURN].Init(this);
        _states[E_BattleState.WAITTURN].Init(this);
        _states[E_BattleState.ENDTURN].Init(this);

        ChangeState(_currentState);
    }

    private void GetCurrentHealth(int health)
    {
        if(health <= 0)
        {
            if (_hasStartedTheBattle == false)
                BattleManager.Instance.SetZoriB = null;
            else
                BattleManager.Instance.SetZoriA = null;

            GameLoopManager.Instance.UpdateZori -= OnUpdate;

            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _level = _baseStats.GetLevel;
        _baseMaxExperience = _baseStats.GetBaseMaxExperience;
        _stats.Init(_baseStats, _baseStats.GetBehavior, _baseStats.GetTypes, _battleSystem, _level);

        _healthSystem.Init(_baseStats.GetBaseHp, _battleSystem.GetBPHp, _level);

        _baseMaxExperience = _baseStats.GetBaseMaxExperience;
    }

    private void Start()
    {
        _dicMoves = new Dictionary<E_Slots, D_AttackSystem>();

        _states = new Dictionary<E_BattleState, IBattleState>();

        SetMoves();

        SetStates();

        _healthSystem.ShowCurrentHealth += GetCurrentHealth;
    }

    private void OnUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetXP(30);
        }

        _states[_currentState].Tick();

        UIExperienceVisualised();
    }

    private void UIExperienceVisualised()
    {
        _timeXP += 0.05f * Time.deltaTime;

        _experience = Mathf.Lerp(_experience, newXPValue, _timeXP);

        if(_experience >= newXPValue - 0.2f)
        {
            _experience = newXPValue;
            _timeXP = 0;
        }
    }

    public void ChangeState(E_BattleState nextState)
    {
        _states[_currentState].Exit();
        GameLoopManager.Instance.UpdateZori -= OnUpdate;
        _currentState = nextState;
        _states[nextState].Enter();
        GameLoopManager.Instance.UpdateZori += OnUpdate;
    }

    private void OnDestroy()
    {
        if(GameLoopManager.Instance != null)
            GameLoopManager.Instance.UpdateZori -= OnUpdate;

        _healthSystem.ShowCurrentHealth -= GetCurrentHealth;
    }
}