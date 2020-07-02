using UnityEngine;

[CreateAssetMenu(fileName = "Capacity", menuName = "Data/Capacity")]
public class ZoriMoves : ScriptableObject
{
    [SerializeField] private string _moveName = string.Empty;
    [SerializeField] private bool _isTimeBasedDmg = false;
    [SerializeField] private int _damage = 5;

    public string MoveName { get { return _moveName; } }
    public bool IsTimeBasedDmg { get { return _isTimeBasedDmg; } }
    public int Damage { get { return _damage; } set { _damage = value; } }
}
