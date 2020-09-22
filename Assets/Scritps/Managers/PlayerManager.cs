using Engine.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    private PlayerController _playerInstance = null;

    public PlayerController GetPlayer { get { return _playerInstance; } }
    public PlayerController SetPlayer { set { _playerInstance = value; } }
}
