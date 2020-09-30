using UnityEngine;
using ZORI_Battle_Creatures.Assets.Scripts.DataHolders;
using ZORI_Battle_Creatures.Assets.Scripts.Enumerators;
using ZORI_Battle_Creatures.Assets.Scripts.Utilities;
using System.Collections.Generic;
using System;

namespace ZORI_Battle_Creatures.Assets.Scripts.Bestarium
 {
    public class ZoriController : MonoBehaviour
    {
        [SerializeField] private d_ZoriStats _dataBaseStats = null;
        [Space]
        [SerializeField] private d_CapacityStats[] _capacities = null;
        [Space]
        [SerializeField] private BattlePoints _battlePoints;
        [Space]
        [SerializeField] private GivenBattlePoints _givenBattlePoints;

        private Data _data;
        private BaseStats _baseStats;
        private Dictionary<e_ActionSlots, d_CapacityStats> _zoriMoves = null;
        private int _currentHp = 0;
        private int _successful = 0;

        private event Action<int> _updateHp = null;
        public event Action<int> UpdateHp
        {
            add
            {
                _updateHp -= value;
                _updateHp += value;
            }
            remove
            {
                _updateHp -= value;
            }
        }

        private event Action<float> _updateExperience = null;
        public event Action<float> UpdateExperience
        {
            add
            {
                _updateExperience -= value;
                _updateExperience += value;
            }
            remove
            {
                _updateExperience -= value;
            }
        }

        private event Action<int> _updateLevel = null;
        public event Action<int> UpdateLevel
        {
            add
            {
                _updateLevel -= value;
                _updateLevel += value;
            }
            remove
            {
                _updateLevel -= value;
            }
        }

        #region Properties
        public Data GetData { get { return _data; } }
        public BaseStats GetBaseStats {get {return _baseStats; } }
        public d_ZoriStats GetDataBaseStats {get{return _dataBaseStats;}}
        public d_CapacityStats[] GetCapacities {get {return _capacities; } }
        public Dictionary<e_ActionSlots, d_CapacityStats> GetZoriMoves {get {return _zoriMoves; } }
        public BattlePoints GetBattlePoints {get {return _battlePoints; } }
        public GivenBattlePoints GetGivenBattlePoints {get {return _givenBattlePoints; } }
        public int GetCurrentHealth {get {return _currentHp; } }
        public int GetSuccessful {get{return _successful;}}
        #endregion

        #region Structs
        public struct BaseStats
        {       
            public int hp;
            public int maxExperience;
            public int attack;
            public int defence;
            public int specialAtt;
            public int specialDef;
            public int speed;
        }
        public struct Data
         {
             public int index;
             public string name;
             public string nickName;
             public Sprite icon;
             public Stats stats;
             public e_ZoriTypes[] types;
             public string description;
         }
        public struct Stats
         {
             public int hp;
             public int maxHp;
             public int level;
             public float experience;
             public int maxExperience;
             public int attack;
             public int defence;
             public int specialAtt;
             public int specialDef;
             public int speed;
         }
        
        [System.Serializable]
        public struct BattlePoints
        {
            public int hp;
            public int attack;
            public int defence;
            public int specialAtt;
            public int specialDef;
            public int speed;
        }
        
        [System.Serializable]
        public struct GivenBattlePoints
        {
            public int hp;
            public int attack;
            public int defence;
            public int specialAtt;
            public int specialDef;
            public int speed;
        }
        #endregion
    
        private int Init()
        {
            e_ActionSlots action = e_ActionSlots.A;

            _zoriMoves = new Dictionary<e_ActionSlots, d_CapacityStats>();

            _data.index = _dataBaseStats.GetIndex;
            _data.name = _dataBaseStats.GetName;

            if(_dataBaseStats.GetNickName == string.Empty)
            {
                _data.nickName = _data.name;
            }
            else
            {
                _data.nickName = _dataBaseStats.GetNickName;
            }

            _data.icon = _dataBaseStats.GetIcon;
            _data.stats.level = _dataBaseStats.GetLevel;
            _data.description = _dataBaseStats.GetDescription;
            _data.types = _dataBaseStats.GetTypes;

            _baseStats.hp = _dataBaseStats.GetStats.baseHp;
            _data.stats.experience = _dataBaseStats.GetExperience;
            _baseStats.maxExperience = _dataBaseStats.GetStats.baseMaxExperience;

            _baseStats.attack = _dataBaseStats.GetStats.baseAttack;
            _baseStats.defence = _dataBaseStats.GetStats.baseDefence;
            _baseStats.specialAtt = _dataBaseStats.GetStats.baseSpecialAtt;
            _baseStats.specialDef = _dataBaseStats.GetStats.baseSpecialDef;
            _baseStats.speed = _dataBaseStats.GetStats.baseSpeed;

            CalculateNewStats();

            _zoriMoves.Add(e_ActionSlots.A, _capacities[0]);
            _zoriMoves.Add(e_ActionSlots.B, _capacities[1]);
            _zoriMoves.Add(e_ActionSlots.C, _capacities[2]);
            _zoriMoves.Add(e_ActionSlots.D, _capacities[3]);

              for (int i = 0; i < _zoriMoves.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        action = e_ActionSlots.A;
                    break;

                    case 1:
                        action = e_ActionSlots.B;
                    break;

                    case 2:
                        action = e_ActionSlots.C;
                    break;

                    case 3:
                        action = e_ActionSlots.D;
                    break;
                }

                _zoriMoves[action].SetStamina = _zoriMoves[action].GetStaminaQuantity;
            }

            _successful = 1;

            return _successful;
        }
        
        public void Awake()
        {
            if(Init() == 0)
            {
                Init();
            }
        }

        private void CalculateNewStats()
        {
            int curLevel = _data.stats.level;

             int atk = (((2 * _baseStats.attack + (_battlePoints.attack / 4)) * curLevel) / 100) + 5;
            int def = (((2 * _baseStats.defence + (_battlePoints.defence / 4)) * curLevel) / 100) + 5;
            int speAtk = (((2 * _baseStats.specialAtt + (_battlePoints.specialAtt / 4)) * curLevel) / 100) + 5;
            int speDef = (((2 * _baseStats.specialDef + (_battlePoints.specialDef / 4)) * curLevel) / 100) + 5;
            int speed = (((2 * _baseStats.speed + (_battlePoints.speed / 4)) * curLevel) / 100) + 5;
            int maxXP = (((2 * _baseStats.maxExperience) * curLevel) / 10) + curLevel + 100;
            int maxHp = BattleUtilities.CalculateNewMaxHealthValue(this);

            _data.stats.attack = Mathf.Abs(atk);
            _data.stats.defence = Mathf.Abs(def);
            _data.stats.specialAtt = Mathf.Abs(speAtk);
            _data.stats.specialDef = Mathf.Abs(speDef);
            _data.stats.speed = Mathf.Abs(speed);
            _data.stats.maxExperience = maxXP;
            _data.stats.maxHp = maxHp;
            SetHealth(maxHp);
        }

        private void LevelUp(int amount)
        {
            e_ActionSlots action = e_ActionSlots.A;

            _data.stats.level += amount;

            if(_updateLevel != null)
            {
                _updateLevel(_data.stats.level);
            }
            
            _data.stats.maxHp = BattleUtilities.CalculateNewMaxHealthValue(this);
            SetHealth(_data.stats.maxHp);

            for (int i = 0; i < _zoriMoves.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        action = e_ActionSlots.A;
                    break;

                    case 1:
                        action = e_ActionSlots.B;
                    break;

                    case 2:
                        action = e_ActionSlots.C;
                    break;

                    case 3:
                        action = e_ActionSlots.D;
                    break;
                }

                _zoriMoves[action].SetStamina = _zoriMoves[action].GetStaminaQuantity;
            }
        }

        public void GainExperience(float amount)
        {
            Debug.Log("Xp gain: " + amount);

            float newXP = _data.stats.experience + amount;

            Debug.Log("Total Xp: " + newXP);

            if(newXP >= _data.stats.maxExperience)
            {
                LevelUp(1);

                float addNewXP = newXP - _data.stats.maxExperience;
                GainExperience(addNewXP);
            }
            else
            {
                _data.stats.experience = newXP;
            }

            if(_updateExperience != null)
            {
                _updateExperience(_data.stats.experience);
            }
        }

        private void SetHealth(int amount)
        {
            _currentHp = amount;

            if(_updateHp != null)
            {
                _updateHp(_currentHp);
            }
        }

        public void TakeDamage(int amount)
        {
            int newHp = _currentHp - amount;
            
            SetHealth(newHp);
            
            if(_currentHp < 0)
            {
                _currentHp = 0;
            }
        }

        public void Heal(int amount)
        {
            int newHp = _currentHp += amount;

            SetHealth(newHp);

            if(_currentHp > _data.stats.maxHp)
            {
                _currentHp = _data.stats.maxHp;
            }
        }

        public void SetBattlePoints(GivenBattlePoints earnedBP)
        {
            _battlePoints.hp += earnedBP.hp;
            _battlePoints.attack += earnedBP.attack;
            _battlePoints.defence += earnedBP.defence;
            _battlePoints.specialAtt += earnedBP.specialAtt;
            _battlePoints.specialDef += earnedBP.specialDef;
            _battlePoints.speed += earnedBP.speed;
        }
    }
 }
