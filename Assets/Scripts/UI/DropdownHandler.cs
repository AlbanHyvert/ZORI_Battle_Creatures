using UnityEngine;
using ZORI_Battle_Creatures.Assets.Scripts.Bestarium;
using ZORI_Battle_Creatures.Assets.Scripts.Managers;
using System.Collections.Generic;
using TMPro;

namespace ZORI_Battle_Creatures.Assets.Scripts.UI
{
    public class DropdownHandler : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _dropdown = null;
        [Space]
        [SerializeField] private e_Dropdown _dropdownChoice = e_Dropdown.ENNEMY;

        private List<string> zorisName = new List<string>();

        private enum e_Dropdown
        {
            PLAYER,
            ENNEMY
        }

        private void Start()
        {
            int lenth = BestariumManager.Instance.GetZoris.Count;
            
            ZoriController[] zoris = BestariumManager.Instance.GetZoris.ToArray();

            for (int i = 0; i < lenth; i++)
            {
                if(zoris[i].GetData.nickName == string.Empty)
                {
                    zorisName.Add(zoris[i].GetData.name);
                }
                else
                {
                    zorisName.Add(zoris[i].GetData.nickName);
                }
            }

            _dropdown.options.Clear();

            _dropdown.AddOptions(zorisName);
        }
    
        public void DropdownInteger()
        {
            Dictionary<string, ZoriController> _dic = BestariumManager.Instance.GetBestarium;

            int index = _dropdown.value;

            Debug.Log("updated");

            switch(_dropdownChoice)
            {
                case e_Dropdown.PLAYER:
                    BattleManager.Instance.SetZoriPlayer = _dic[zorisName[index]];
                break;

                case e_Dropdown.ENNEMY:
                    BattleManager.Instance.SetZoriEnnemy = _dic[zorisName[index]];
                break;
            }
        }
    }
}