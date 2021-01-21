using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    [Tooltip("Name of the species of the zori.")]
    [SerializeField] private string _name = string.Empty;
    [Tooltip("Name given by the player, that will overwrite the name of the species.")]
    [SerializeField] private string _nickname = string.Empty;
    [Tooltip("The current level of the zori.")]
    [SerializeField, Range(1, 1000)] private int _level = 1;
    [Tooltip("the current experience of the zori.")]
    [SerializeField, Range(0, 5000000)] private int _experience = 1;
    [Tooltip("The current max experience to obtain to gain a level.")]
    [SerializeField] private int _maxLevelExperience = 100;
    [Space]
    [Tooltip("This points (BP), affect the stats at each level")]
    [SerializeField] private BattlePoints _battlePoints = new BattlePoints();
    [Tooltip("This points (GBP), will be gain by the zori owned by the player when winning a fight")]
    [SerializeField] private GivenBattlePoint _givenBattlePoints = new GivenBattlePoint();

    private BaseStats m_baseStats = null;

    public string nickname { get => _nickname; set => _nickname = value; }
    public int attack { get; private set; }
    public int defence { get; private set; }
    public int speAttack { get; private set; }
    public int speDefence { get; private set; }
    public int speed { get; private set; }
    public int level { get => _level; }
    public int experience { get => _experience; }

    [System.Serializable]
    public struct BattlePoints
    {
        public int health;
        public int attack;
        public int defence;
        public int speAttack;
        public int speDefence;
        public int speed;
    }

    [System.Serializable]
    public struct GivenBattlePoint
    {
        public int health;
        public int attack;
        public int defence;
        public int speAttack;
        public int speDefence;
        public int speed;
    }

    public UnityAction onGainedLevel = null;

    public void Init(BaseStats baseStats = null)
    {
        if (_nickname == string.Empty)
            _nickname = _name;

        m_baseStats = baseStats;
        GainedLevel(0);
    }

    public BattlePoints GetBP()
        => _battlePoints;

    public GivenBattlePoint GetGivenBP()
        => _givenBattlePoints;

    public void GainedExperience(int amount = 0)
    {
        int currentExperience = _experience;

        int newExperienceValue = currentExperience + amount;

        if(newExperienceValue < _maxLevelExperience)
        {
            _experience = newExperienceValue;
            return;
        }

        int diffBetweenCurrentAndMax = currentExperience - _maxLevelExperience;

        if(diffBetweenCurrentAndMax > 0)
        {
            GainedExperience(diffBetweenCurrentAndMax);
            GainedLevel(1);
            return;
        }
        else
        {
            _experience = 0;
        }
    }

    public void GainedLevel(int amount = 0)
    {
        int currentLevel = _level;

        int newLevel = currentLevel + amount;

        if(newLevel < 1000)
        {
            _level = newLevel;

            if (onGainedLevel != null)
                onGainedLevel.Invoke();

            CalculateNewPower();
            CalculateNewMaxExperience();
        }
    }

    private void CalculateNewPower()
    {
        attack = (((2 * m_baseStats.attack + (_battlePoints.attack / 4)) + _level) / 100) + 5;
        defence = (((2 * m_baseStats.defence + (_battlePoints.defence / 4)) + _level) / 100) + 5;
        speAttack = (((2 * m_baseStats.speAttack + (_battlePoints.speAttack / 4)) + _level) / 100) + 5;
        speDefence = (((2 * m_baseStats.speDefence + (_battlePoints.speDefence / 4)) + _level) / 100) + 5;
        speed = (((2 * m_baseStats.speed + (_battlePoints.speed / 4)) + _level) / 100) + 5;
    }

    private void CalculateNewMaxExperience()
    {
        int maxLevelExperience = Mathf.RoundToInt(1.2f * (_level ^ 3) - 10 * (_level ^ 2) + 170 * _level - 130);

        _maxLevelExperience = maxLevelExperience;
    }
}