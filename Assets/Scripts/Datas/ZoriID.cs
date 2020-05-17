using UnityEngine;

[CreateAssetMenu(fileName = "ZoriDex", menuName = "Data/ZoriDex")]
public class ZoriID : ScriptableObject
{
    [SerializeField,Range(000, 999)] private int _ID = 000;
    [SerializeField] private BaseZori _zoriPrefab = null;

    public int ID { get => _ID; }
    public BaseZori ZoriPrefab { get => _zoriPrefab; }
}