using UnityEngine;
using Engine.Singleton;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private PlayerController _playerPrefab = null;
    [SerializeField] private string _playerName = string.Empty;

    private PlayerController _playerInstance = null;

    public PlayerController PlayerInstance { get { return _playerInstance; } }
    public string PlayerName { get { return _playerName; } set { _playerName = value; } }

    public void CreateAPlayer(Vector3 pos, Quaternion rot)
    {
        _playerInstance = Instantiate(_playerPrefab, pos, rot);
    }
}