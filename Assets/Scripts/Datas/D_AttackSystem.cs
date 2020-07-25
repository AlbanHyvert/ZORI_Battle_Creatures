using UnityEngine;

[CreateAssetMenu(fileName = "Capacity", menuName = "DataHolder/Capacities")]
public class D_AttackSystem : ScriptableObject
{
    [SerializeField] private string _name = string.Empty;
    [SerializeField] private E_Types _type = E_Types.AERO;
    [SerializeField] private E_AtkStyles _style = E_AtkStyles.PHYSIQUE;
    [SerializeField, Range(0,1000)] private int _power = 10;
    [SerializeField] private int _consomation = 10;

    public string GetName { get { return _name; } }
    public E_Types GetTypes { get { return _type; } }
    public E_AtkStyles GetStyle { get { return _style; } }
    public int GetPower { get { return _power; } }
    public int GetConsomation { get { return _consomation; } }
}
