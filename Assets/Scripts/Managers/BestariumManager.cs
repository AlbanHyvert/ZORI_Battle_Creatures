using Engine.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestariumManager : Singleton<BestariumManager>
{
    [SerializeField] private IAController[] _zories = null;

    private Dictionary<int, IAController> _levelTracker = null;
    private Dictionary<int, IAController> _idTracker = null;
    private Dictionary<string, IAController> _nameTracker = null;
    private Dictionary<E_Types, IAController> _typeTracker = null;

    public Dictionary<int, IAController> GetLevelTracker { get { return _levelTracker; } }
    public Dictionary<int, IAController> GetIDTracker { get { return _idTracker; } }
    public Dictionary<string, IAController> GetNameTracker { get { return _nameTracker; } }
    public Dictionary<E_Types, IAController> GetTypeTracker { get { return _typeTracker; } }

    private void SetNameTracker(int i)
    {
        Debug.Log("Zori Name :" + " " + _zories[i].GetStats.GetName);

        _nameTracker.Add(_zories[i].GetStats.GetName, _zories[i]);
    }
    /*
    private void SetIDTracker(int i)
    {
        _idTracker.Add(_zories[i].GetStats.GetID, _zories[i]);
    }
    
    private void SetLevelTracker(int i)
    {
        _levelTracker.Add(_zories[i].GetLevel, _zories[i]);
    }

    private void SetTypeTracker(int i)
    {
        for (int j = 0; j < _zories[i].GetStats.GetTypes.Length; j++)
        {
            _typeTracker.Add(_zories[i].GetStats.GetTypes[j], _zories[i]);
        }
    }
    */
    public void Init()
    {
        _nameTracker = new Dictionary<string, IAController>();

        if (_zories.Length > 0)
        {
            for (int i = 0; i < _zories.Length; i++)
            {
                if (_zories[i] != null)
                {
                    SetNameTracker(i);
                }
            }
        }

        for (int i = 0; i < _zories.Length; i++)
        {
            Debug.Log("Name search :" + " " + _zories[i].GetStats.GetName);
            Debug.Log("Name : " + " " + _nameTracker[_zories[i].GetStats.GetName].GetStats.GetName);
            Debug.Log("ID :" + " " + _nameTracker[_zories[i].GetStats.GetName].GetStats.GetID);

            /*
            Debug.Log("ID search :" + " " + _zories[i].GetStats.GetID);
            Debug.Log("Name :" + " " + _idTracker[_zories[i].GetStats.GetID].GetStats.GetName);
            Debug.Log("ID :" + " " + _idTracker[_zories[i].GetStats.GetID].GetStats.GetID);

            Debug.Log("Level search :" + " " + _zories[i].GetLevel);
            Debug.Log("Name :" + " " + _levelTracker[_zories[i].GetLevel].GetStats.GetName);
            Debug.Log("ID :" + " " + _levelTracker[_zories[i].GetLevel].GetStats.GetID);
            Debug.Log("Level :" + " " + _levelTracker[_zories[i].GetLevel].GetLevel);
            */

            for (int j = 0; j < _zories[i].GetStats.GetTypes.Length; j++)
            {
                Debug.Log("Type " + j + "search:" +" " + _zories[i].GetStats.GetTypes[j]);
                Debug.Log("Name :" + " " + _typeTracker[_zories[i].GetStats.GetTypes[j]].GetStats.GetName);
                Debug.Log("ID :" + " " + _typeTracker[_zories[i].GetStats.GetTypes[j]].GetStats.GetID);
                Debug.Log("Type " + j + ":" + " " + _typeTracker[_zories[i].GetStats.GetTypes[j]].GetStats.GetTypes[j]);
            }
        }
    }
}