using UnityEngine;
using ZORI_Battle_Creatures.Assets.Scripts.Enumerators;

namespace ZORI_Battle_Creatures.Assets.Scripts.DataHolders
{
    [CreateAssetMenu(fileName = "ZoriStats", menuName = "Datas/ZoriStats")]
    public class d_ZoriStats : ScriptableObject
    {
        [SerializeField] private int _index = 0;
        [SerializeField] private string _name = string.Empty;
        [SerializeField] private string _nickName = string.Empty;
        [SerializeField] private int _level = 1;
        [SerializeField] private float _experience = 0;
        [SerializeField] private Stats _baseStats;
        [Space]
        [SerializeField] private e_ZoriTypes[] _types = null;
        [Space]
        [SerializeField, TextArea] private string _description = string.Empty;


        public int GetIndex {get {return _index; } }
        public string GetName {get {return _name; } }
        public string GetNickName {get {return _nickName; } }
        public int GetLevel {get {return _level; } }
        public float GetExperience {get {return _experience; } }
        public Stats GetStats { get {return _baseStats; } }
        public e_ZoriTypes[] GetTypes {get {return _types; } }
        public string GetDescription {get {return _description; } }

        [System.Serializable]
        public struct Stats
        {
            public int baseHp;
            public int baseMaxHp;
            public int baseMaxExperience;
            public int baseAttack;
            public int baseDefence;
            public int baseSpecialAtt;
            public int baseSpecialDef;
            public int baseSpeed;
        }
    }
}