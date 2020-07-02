using UnityEngine;

public class BattleSettings : MonoBehaviour
{
    [SerializeField] private Camera _camera = null;
    [SerializeField] private Transform[] _zoriPosition = null;

    public Camera Camera { get { return _camera; } }
    public Transform[] ZoriPosition { get { return _zoriPosition; } }
}