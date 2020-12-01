using Utilities.Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private string[] _scenesToLoad = null;

    private int _index = 0;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadSceneAsync(_scenesToLoad[_index]);

            if (_index < _scenesToLoad.Length)
                _index++;
            else
            {
                _index = 0;
            }
        }
    }
}
