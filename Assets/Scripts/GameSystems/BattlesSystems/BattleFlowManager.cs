using UnityEngine;

public class BattleFlowManager : BattleStateManager
{
    [Tooltip("The console the player will use to choose his action for the battle.")]
    [SerializeField] private GameObject _playerConsole = null;
    [Tooltip("The hud used by the current player.")]
    [SerializeField] private GameObject _zoriPlayerHud = null;
    [Tooltip("The hud of the zori ennemy.")]
    [SerializeField] private GameObject _zoriEnnemyHud = null;

    private ZoriController m_zoriPlayer = null;
    private ZoriController m_zoriEnnemi = null;
    private Capacity m_zoriPlayerCapacity = null;
    private Capacity m_zoriEnnemyCapacity = null;
    private PlayerCharacterController m_player = null;

    public static BattleFlowManager Instance{ get; private set; }
    
    public ZoriController ZoriPlayer { get => m_zoriPlayer; }
    public ZoriController ZoriEnnemy { get => m_zoriEnnemi; }

    private void Awake()
    {
        Instance = this;

        _playerConsole.SetActive(false);
        _zoriEnnemyHud.SetActive(false);
        _zoriPlayerHud.SetActive(false);
    }

    private void CheckAsBothZori()
    {
        if (!m_zoriPlayer || !m_zoriEnnemi)
            return;

        SetState(new ChooseActionState(this));
    }

    private void CheckAsBothAttack()
    {
        if (!m_zoriEnnemyCapacity || !m_zoriPlayerCapacity)
            return;

        SetState(new ExecuteState(this));
    }

    public void SetPlayer(PlayerCharacterController player)
        => m_player = player;

    public void SetZoriPlayer(ZoriController zori)
    {
        m_zoriPlayer = zori;

        CheckAsBothZori();
    }

    public void SetZoriEnnemi(ZoriController zori)
    {
        m_zoriEnnemi = zori;

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
            _zoriEnnemyHud.SetActive(true);
            _zoriPlayerHud.SetActive(true);

            return;
        }
        else
        {
            _zoriEnnemyHud.SetActive(false);
            _zoriPlayerHud.SetActive(false);
        }
    }

    public Capacity GetPlayerCapacity()
        => m_zoriPlayerCapacity;

    public Capacity GetEnnemyCapacity()
        => m_zoriEnnemyCapacity;

    public void SetPlayerCapacity(Capacity capacity)
    {
        m_zoriPlayerCapacity = capacity;

        CheckAsBothAttack();
    }

    public void SetEnnemyCapacity(Capacity capacity)
    {
        m_zoriEnnemyCapacity = capacity;
        
        CheckAsBothAttack();
    }

    public void ClearCapacity()
    {
        m_zoriEnnemyCapacity = null;
        m_zoriPlayerCapacity = null;
    }

    public void OnDestroy()
    {
        Instance = null;
    }
}