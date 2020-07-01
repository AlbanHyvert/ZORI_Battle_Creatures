using Engine.Loading;
using Engine.Singleton;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private E_GameStatus _statusToGo = E_GameStatus.PRELOAD;

    private bool _isChangingState = false;
    private E_GameStatus _currentGameStatus = E_GameStatus.PRELOAD;
    private Dictionary<E_GameStatus, IGamesStates> _states = null;

    public IGamesStates CurrentStateType { get { return _states[_currentGameStatus]; } }
    public E_GameStatus ChoosenScene { get { return _statusToGo; } set { _statusToGo = value; } }

    private void Start()
    {
        GameLoopManager.Instance.Managers += OnUpdate;
        _states = new Dictionary<E_GameStatus, IGamesStates>();
        _states.Add(E_GameStatus.PRELOAD, new PreloadState());
        _states.Add(E_GameStatus.MENU, new MainMenuState());
        _states.Add(E_GameStatus.LOADING, new LoadingState());
        _states.Add(E_GameStatus.GAME, new GameState());
        _states.Add(E_GameStatus.DEV, new DevState());
        _currentGameStatus = E_GameStatus.PRELOAD;
        ChangeState(E_GameStatus.GAME);
    }

    public void ChangeState(E_GameStatus gameStatus)
    {
        _isChangingState = true;
        _states[gameStatus].Enter();
        _currentGameStatus = gameStatus;
    }

    private void OnUpdate()
    {
        if(_isChangingState == true)
        {
            if(LoadingManager.Instance.AsEndedLoading == true)
            {
                _states[_currentGameStatus].Exit();
                _isChangingState = false;
            }
        }
    }
}
