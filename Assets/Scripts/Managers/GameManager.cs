using Engine.Loading;
using Engine.Singleton;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameStatusEnum _statusToGo = GameStatusEnum.PRELOAD;

    private bool _isChangingState = false;
    private GameStatusEnum _currentGameStatus = GameStatusEnum.PRELOAD;
    private Dictionary<GameStatusEnum, IGamesStates> _states = null;

    public IGamesStates CurrentStateType { get { return _states[_currentGameStatus]; } }
    public GameStatusEnum ChoosenScene { get { return _statusToGo; } set { _statusToGo = value; } }

    private void Start()
    {
        GameLoopManager.Instance.Managers += OnUpdate;
        _states = new Dictionary<GameStatusEnum, IGamesStates>();
        _states.Add(GameStatusEnum.PRELOAD, new PreloadState());
        _states.Add(GameStatusEnum.MENU, new MainMenuState());
        _states.Add(GameStatusEnum.LOADING, new LoadingState());
        _states.Add(GameStatusEnum.GAME, new GameState());
        _states.Add(GameStatusEnum.DEV, new DevState());
        _currentGameStatus = GameStatusEnum.PRELOAD;
        ChangeState(GameStatusEnum.GAME);
    }

    public void ChangeState(GameStatusEnum gameStatus)
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
