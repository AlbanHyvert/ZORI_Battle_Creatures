using UnityEngine;

public class BattleFlowManager : BattleStateManager
{
    [Tooltip("The console the player will use to choose his action for the battle.")]
    [SerializeField] private GameObject _playerConsole = null;
    [Tooltip("The hud used by the current player.")]
    [SerializeField] private BattleStatsUI _zoriPlayerHud = null;
    [Tooltip("The hud of the zori ennemy.")]
    [SerializeField] private BattleStatsUI _zoriEnnemyHud = null;
    [SerializeField] private float _readingSpeed = 0.1f;
    [Header("DEBUG ONLY")]
    [Tooltip("The item hold by the zori, if value is 1 he doesnt hold anything.")]
    [SerializeField] private float _itemMult = 1f;
    [Tooltip("If the food eaten by the zori, buff its stats then it will be above 1.")]
    [SerializeField] private float _foodMult = 1f;
    [SerializeField] private int m_maxSleepTurn = 5;

    private ZoriController m_zoriPlayer = null;
    private ZoriController m_zoriEnnemy = null;
    private Capacity m_zoriPlayerCapacity = null;
    private Capacity m_zoriEnnemyCapacity = null;
    private PlayerCharacterController m_player = null;
    private BattleState m_currentState = null;
    private int m_playerSleepTurnLeft = 0;
    private int m_ennemySleepTurnLeft = 0;

    public static BattleFlowManager Instance{ get; private set; }
    
    public ZoriController ZoriPlayer { get => m_zoriPlayer; }
    public ZoriController ZoriEnnemy { get => m_zoriEnnemy; }
    public BattleStatsUI PlayerHud { get => _zoriPlayerHud; }
    public BattleStatsUI EnnemyHud { get => _zoriEnnemyHud; }
    public float ItemMult { get => _itemMult; }
    public float FoodMult { get => _foodMult; }
    public float readingSpeed { get => _readingSpeed; }
    public bool playerWon { get; private set; }
    public bool battleEnded { get; private set; }
    public bool ennemyHasCapacity { get; set; }
    public bool playerHasCapacity { get; set; }
    public int playerSleepTurnLeft { get => m_playerSleepTurnLeft; set => m_playerSleepTurnLeft = value; }
    public int ennemySleepTurnLeft { get => m_ennemySleepTurnLeft; set => m_ennemySleepTurnLeft = value; }

    private void Awake()
    {
        Instance = this;

        _playerConsole.SetActive(false);

        ennemyHasCapacity = false;
        playerHasCapacity = false;

        _zoriEnnemyHud.gameObject.SetActive(false);
        _zoriPlayerHud.gameObject.SetActive(false);
    }

    private void Update()
    {
        DisplayText.Tick();

        if (Input.GetKeyDown(KeyCode.W))
            ZoriEnnemy.Zori.Health.TakeDamage(ZoriEnnemy.Zori.Health.maxHealth);

        if (Input.GetKeyDown(KeyCode.L))
            ZoriPlayer.Zori.Health.TakeDamage(ZoriPlayer.Zori.Health.maxHealth);

    }

    private void CheckAsBothZori()
    {
        if (!m_zoriPlayer || !m_zoriEnnemy)
            return;

        _zoriEnnemyHud.Init(m_zoriEnnemy.Zori);
        _zoriPlayerHud.Init(m_zoriPlayer.Zori);

        m_currentState = SetState(new ChooseActionState(this));
    }

    private void CheckAsBothAttack()
    {
        if (!ennemyHasCapacity || !playerHasCapacity)
            return;

        StopAllCoroutines();

        m_currentState = SetState(new ExecuteState(this));
    }

    public void SetPlayer(PlayerCharacterController player)
        => m_player = player;

    public void SetZoriPlayer(ZoriController zori)
    {
        m_zoriPlayer = zori;

        zori.Zori.Health.onDie += ZoriPlayerIsDead;

        CheckAsBothZori();
    }

    public void SetZoriEnnemi(ZoriController zori)
    {
        m_zoriEnnemy = zori;

        zori.Zori.Health.onDie += ZoriEnnemyIsDead;

        CheckAsBothZori();
    }

    public void ControlPlayerConsole(bool value)
    {
        if(value == true)
        {
            _playerConsole.SetActive(true);
            return;
        }
        else
        {
            _playerConsole.SetActive(false);
        }
    }

    public void ControlUIActivation(bool value)
    {
        if(value == true)
        {
            _zoriEnnemyHud.gameObject.SetActive(true);
            _zoriPlayerHud.gameObject.SetActive(true);

            return;
        }
        else
        {
            _zoriEnnemyHud.gameObject.SetActive(false);
            _zoriPlayerHud.gameObject.SetActive(false);
        }
    }

    public Capacity GetPlayerCapacity()
        => m_zoriPlayerCapacity;

    public Capacity GetEnnemyCapacity()
        => m_zoriEnnemyCapacity;

    public void SetPlayerCapacity(Capacity capacity)
    {
        m_zoriPlayerCapacity = capacity;
        playerHasCapacity = true;
        CheckAsBothAttack();
    }

    public void SetEnnemyCapacity(Capacity capacity)
    {
        m_zoriEnnemyCapacity = capacity;
        ennemyHasCapacity = true;
        CheckAsBothAttack();
    }

    public void ClearCapacity()
    {
        playerHasCapacity = false;
        ennemyHasCapacity = false;
        m_zoriEnnemyCapacity = null;
        m_zoriPlayerCapacity = null;
    }

    private void ZoriPlayerIsDead()
    {
        StopAllCoroutines();
        battleEnded = true;
        playerWon = false;

        SetState(new BattleEndState(this));
    }

    private void ZoriEnnemyIsDead()
    {
        StopAllCoroutines();
        battleEnded = true;
        playerWon = true;

        SetState(new BattleEndState(this));
    }

    public int CheckPlayerSleep(int value = 0)
    {
        if (value == -1)
            m_playerSleepTurnLeft = 0;

        if (m_playerSleepTurnLeft <= 0)
        {
            m_zoriPlayer.Zori.CurrentEffect = Effects.E_Effects.NONE;
            return 0;
        }

        m_playerSleepTurnLeft--;

        return m_playerSleepTurnLeft;
    }

    public int CheckEnnemySleep(int value = 0)
    {
        if (value == -1)
            m_ennemySleepTurnLeft = 0;

        if (m_ennemySleepTurnLeft <= 0)
        {
            m_zoriEnnemy.Zori.CurrentEffect = Effects.E_Effects.NONE;
            return 0;
        }

        m_ennemySleepTurnLeft--;

        return m_ennemySleepTurnLeft;
    }

    public void OnDestroy()
    {
        Instance = null;
    }
}