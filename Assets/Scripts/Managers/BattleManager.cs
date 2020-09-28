using UnityEngine;
using ZORI_Battle_Creatures.Assets.Scripts.Tools;
using ZORI_Battle_Creatures.Assets.Scripts.Bestarium;

namespace ZORI_Battle_Creatures.Assets.Scripts.Managers
{
    public class BattleManager : Singleton<BattleManager>
    {
        [SerializeField] private ZoriController _zoriPlayer = null;
        [SerializeField] private ZoriController _zoriEnnemy = null;

        public ZoriController GetZoriPlayer {get{return _zoriPlayer;}}
        public ZoriController SetZoriPlayer {set{_zoriPlayer = value;}}
        public ZoriController GetZoriEnnemy {get{return _zoriEnnemy;}}
        public ZoriController SetZoriEnnemy {set{_zoriEnnemy = value;}}
    }
}