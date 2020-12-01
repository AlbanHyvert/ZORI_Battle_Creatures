using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZoriHolder", menuName = "Player/Inventory/Zori Holder")]
public class ZoriHolder : ScriptableObject
{
    [SerializeField] private List<Zori> _zoriList = new List<Zori>();

    public List<Zori> Zoris()
        => _zoriList;
}