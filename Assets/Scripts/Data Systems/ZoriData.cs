using UnityEngine;
using System;
using ZORI.Enums;

[System.Serializable]
public class ZoriData
{
    #region Variables
    [SerializeField] private string _name = string.Empty;
    [SerializeField] private string _nickname = string.Empty;
    [SerializeField] private int _index = 0;
    [Space]
    [SerializeField] private E_Types[] _types = null;
    [Space]
    [SerializeField] private TechniquesHolder _holder = null;
    [Space]
    [SerializeField] private E_Rarity _rarity = E_Rarity.COMMON;
    [Space]
    [SerializeField] private BaseData _baseData = new BaseData();
    [Space]
    [SerializeField] private BattlePoints _battlePoint = new BattlePoints();
    [SerializeField] private GivenBP _givenBp = new GivenBP();
    [Space]
    [SerializeField] private E_Behavior _behavior = E_Behavior.NONE;
    [Space]
    [SerializeField] private float _size = 1f;
    [SerializeField] private float _weight = 1f;
    [Space]
    [SerializeField] private int _level = 1;
    [SerializeField] private float _experience = 0f;
    [SerializeField] private float _maxExperience = 0f;
    [SerializeField] private float _givenExperience = 0f;
    [Space, TextArea(1, 50)]
    [SerializeField] private string _description = string.Empty;
    #endregion Variables

    private int _currentHp = 0;
    private Data _data = new Data();
    private bool _isInit = false;

    #region Properties
    public string Name { get => _name; set => _name = value; }
    public string Nickname { get => _nickname; set => _nickname = value; }
    public int Index { get => _index; }
    public string Description { get => _description; }
    public int Level { get => _level; }
    public float Experience { get => _experience; }
    public float GivenExperience { get => _givenExperience; }
    public float Size { get => _size; }
    public float Weight { get => _weight; }
    public int CurrentHp { get => _currentHp;
        set
        {
            _currentHp = value;

            if (_currentHpValue != null)
                _currentHpValue(_currentHp);
        }
    }
    #endregion Properties

    #region Events
    private event Action<int> _currentHpValue = null;
    public event Action<int> CurrentHpValue
    {
        add
        {
            _currentHpValue -= value;
            _currentHpValue += value;
        }
        remove
        {
            _currentHpValue -= value;
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
    #endregion Events

    #region Structs
    [System.Serializable]
    public struct BaseData
    {
        public int maxHp;
        public int attack;
        public int defence;
        public int speAtk;
        public int speDef;
        public int speed;
    }

    [System.Serializable]
    public struct Data
    {
        public int maxHp;
        public int attack;
        public int defence;
        public int speAtk;
        public int speDef;
        public int speed;

        public void NewValues(int newHp, int newAttack, int newDefence, int newSpeAtk, int newSpeDef, int newSpeed)
        {
            maxHp = newHp;
            attack = newAttack;
            defence = newDefence;
            speAtk = newSpeAtk;
            speDef = newSpeDef;
            speed = newSpeed;
        }
    }
    
    [System.Serializable]
    public struct BattlePoints
    {
        public int hp;
        public int attack;
        public int defence;
        public int speAttack;
        public int speDefence;
        public int speed;

        public void AddBP(GivenBP givenBP)
        {
            hp += givenBP.hp;
            attack += givenBP.attack;
            defence += givenBP.defence;
            speAttack += givenBP.speAttack;
            speDefence += givenBP.speDefence;
            speed += givenBP.speed;
        }
    }

    [System.Serializable]
    public struct GivenBP
    {
        public int hp;
        public int attack;
        public int defence;
        public int speAttack;
        public int speDefence;
        public int speed;
    }
    #endregion Structs

    public void Init()
    {
        if(_isInit == false)
        {
            _currentHp = _data.maxHp;
            _holder.Init();

            _isInit = true;
        }
    }

    #region Functions Get Data
    public GivenBP GivenBPs()
        => _givenBp;

    public BattlePoints BattlePoint()
        => _battlePoint;

    public Data Datas()
        => _data;

    public E_Types[] Types()
        => _types;

    public E_Rarity Rarity()
        => _rarity;

    public TechniquesHolder Holder()
        => _holder;
    #endregion Functions Get Data

    #region Functions Add Data
    public int AddLevel(int amount)
    {
        _level += amount;

        if (_updateLevel != null)
            _updateLevel(_level);

        return _level;
    }

    public float AddExperience(float amount)
    {
        _experience += amount;

        float diff = _experience - _maxExperience;

        if (diff > 0)
        {
            AddLevel(1);
            AddExperience(diff);
        }

        if (_updateExperience != null)
            _updateExperience(_experience);

        return _experience;
    }
    #endregion Functions Add Data

    #region Functions Control HP
    public void SetCurrentHp(int value)
    => CurrentHp = value;

    public int RemoveHp(int amount)
    {
        if (CurrentHp > 0)
            CurrentHp -= amount;

        return CurrentHp;
    }

    public int AddHp(int amount)
    {
        if (CurrentHp < _data.maxHp)
            CurrentHp += amount;

        return CurrentHp;
    }
    #endregion Functions Control HP
}