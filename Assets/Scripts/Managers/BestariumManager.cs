using UnityEngine;
using ZORI_Battle_Creatures.Assets.Scripts.Tools;
using ZORI_Battle_Creatures.Assets.Scripts.Bestarium;
using System.Collections.Generic;

namespace ZORI_Battle_Creatures.Assets.Scripts.Managers
{
    public class BestariumManager : Singleton<BestariumManager>
    {
        [SerializeField] private List<ZoriController> _zoriList = new List<ZoriController>();

        private Dictionary<string, ZoriController> _bestarium  = new Dictionary<string, ZoriController>();

        public List<ZoriController> GetZoris {get{return _zoriList;}}
        public Dictionary<string, ZoriController> GetBestarium {get{return _bestarium;}}

        private void Start()
        {
            for (int i = 0; i < _zoriList.Count; i++)
            {
                _zoriList[i].Awake();
            }

            for (int i = 0; i < _zoriList.Count; i++)
            {
                if(_zoriList[i].GetData.nickName == string.Empty)
                {
                    _bestarium.Add(_zoriList[i].GetData.name, _zoriList[i]);
                }
                else
                {
                    _bestarium.Add(_zoriList[i].GetData.nickName, _zoriList[i]);
                }
            }
        }
    }
}