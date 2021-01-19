using UnityEngine;

public class BaseStats : MonoBehaviour
{
    [Tooltip("Base the actual attack of the zori with the stat given here + other factor")]
    [SerializeField] private int _attack = 0;
    [Tooltip("Base the actual defence of the zori with the stat given here + other factor")]
    [SerializeField] private int _defence = 0;
    [Tooltip("Base the actual special attack of the zori with the stat given here + other factor")]
    [SerializeField] private int _speAttack = 0;
    [Tooltip("Base the actual special defence of the zori with the stat given here + other factor")]
    [SerializeField] private int _speDefence = 0;
    [Tooltip("Base the actual speed of the zori with the stat given here + other factor")]
    [SerializeField] private int _speed = 0;

    public int attack { get => _attack; }
    public int defence { get => _defence; }
    public int speAttack { get => _speAttack; }
    public int speDefence { get => _speDefence; }
    public int speed { get => _speed; }
}