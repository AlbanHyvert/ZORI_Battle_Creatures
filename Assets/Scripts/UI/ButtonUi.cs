using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace ZORI_Battle_Creatures.Assets.Scripts.UI
{
    public class ButtonUi : MonoBehaviour
    {
        [SerializeField] private Data _data;

        public Data GetData {get{return _data;}}

        [System.Serializable]
        public struct Data
        {
            public Button self;
            public Image background;
            public TextMeshProUGUI attackName;
            public TextMeshProUGUI attackStamina;
            public Image attackType;
        }
    }
}