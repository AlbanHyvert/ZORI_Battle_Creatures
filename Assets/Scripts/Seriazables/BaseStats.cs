using UnityEngine;

[System.Serializable]
public class BaseStats
{
    [SerializeField] private int _minimum = 0;
    [SerializeField] private int _maximum = 0;

    public int Minimum { get { return _minimum; } set { _minimum = value; } }
    public int Maximum { get { return _maximum; } set { _maximum = value; } }
}
