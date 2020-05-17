using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    [SerializeField] private int _rank = 0;
    [SerializeField] private int _movementSpeed = 5;

    public int Rank { get => _rank; }
    public int MovementSpeed { get => _movementSpeed; }
}
