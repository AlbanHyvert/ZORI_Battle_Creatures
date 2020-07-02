using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource = null;
    [SerializeField] private Camera _camera = null;
    [SerializeField] private PlayerStats _stats = null;
    [SerializeField] private BattleSettings _battleSettings = null;

    private NavMeshAgent _agent = null;
    private bool _isInBattleMode = false;

    private event Action<bool> _playerInBattle = null;
    public event Action<bool> PlayerInBattle
    {
        add
        {
            _playerInBattle -= value;
            _playerInBattle += value;
        }
        remove
        {
            _playerInBattle -= value;
        }
    }

    public BattleSettings BattleSettings { get { return _battleSettings; } }
    public NavMeshAgent Agen { get => _agent; }
    public AudioSource AudioSource { get => _audioSource; }
    public Camera Camera { get => _camera; }
    public bool IsInBattleMode { get => _isInBattleMode; 
        set
        {
            _isInBattleMode = value;
            _playerInBattle(_isInBattleMode);
        }
    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        PlayerManager.Instance.PlayerInstance = this;
        PlayerInBattle += BattleMode;
    }

    private void BattleMode(bool value)
    {
        if(value == true)
        {
            _battleSettings.Camera.enabled = true;
            _camera.enabled = false;
        }
        else
        {
            _camera.enabled = true;
            _battleSettings.Camera.enabled = false;
        }
    }
}