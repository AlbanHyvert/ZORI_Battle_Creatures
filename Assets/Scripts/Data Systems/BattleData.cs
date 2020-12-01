using UnityEngine;

[System.Serializable]
public class BattleData
{
    [SerializeField] private Camera _camera = null;
    [Space]
    [SerializeField] private Zori _zoriA = null;
    [SerializeField] private Zori _zoriB = null;

    private Zori _currentZoriA = null;
    private Zori _currentZoriB = null;

    public void SetZoriA(Zori zori)
    {
        _currentZoriA = zori;

        _currentZoriA.Data.CurrentHpValue += CheckHpZoriA;
    }

    public void SetZoriB(Zori zori)
    {
        _currentZoriB = zori;

        _currentZoriB.Data.CurrentHpValue += CheckHpZoriB;
    }

    private void CheckHpZoriA(int value)
    {
        if(value < 0)
        {
            Debug.Log("Zori A Lost");
            _currentZoriA.Data.CurrentHpValue -= CheckHpZoriA;
            _currentZoriB.Data.CurrentHpValue -= CheckHpZoriB;
        }
    }

    private void CheckHpZoriB(int value)
    {
        if (value < 0)
        {
            Debug.Log("Zori B Lost");
            _currentZoriA.Data.CurrentHpValue -= CheckHpZoriA;
            _currentZoriB.Data.CurrentHpValue -= CheckHpZoriB;
        }
    }
}