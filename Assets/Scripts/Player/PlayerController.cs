using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private List<BaseZori> _ownedZori = new List<BaseZori>();
    [SerializeField] private CharacterController _characterController = null;
    [SerializeField] private AudioSource _audioSource = null;
    [SerializeField] private Camera _camera = null;
    [SerializeField] private PlayerStats _stats = null;

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

    public List<BaseZori> OwnedZori { get => _ownedZori; }
    public CharacterController CharacterController { get => _characterController; }
    public AudioSource AudioSource { get => _audioSource; }
    public Camera Camera { get => _camera; }
    public bool IsInBattleMode { get => _isInBattleMode; 
        set
        {
            _isInBattleMode = value;
            _playerInBattle(_isInBattleMode);
        }
    }
}