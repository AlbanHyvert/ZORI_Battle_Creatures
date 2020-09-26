using UnityEngine;
using ZORI_Battle_Creatures.Assets.Scripts.Enumerators;

namespace ZORI_Battle_Creatures.Assets.Scripts.DataHolders
{
    [CreateAssetMenu(fileName = "Capacity", menuName = "Datas/CapacityStats")]
    public class d_CapacityStats : ScriptableObject
    {
        [SerializeField] private int _index = 0;
        [SerializeField] private string _name = string.Empty;
        [Space]
        [SerializeField] private ParticleSystem _visualEffect = null;
        [SerializeField] private double _visualEffectDuration = 2;
        [Space]
        [SerializeField] private e_ZoriTypes _type = e_ZoriTypes.NEUTRAL;
        [SerializeField] private e_AttackTypes _actionType = e_AttackTypes.PHYSICAL;
        [SerializeField] private e_BattleTarget _target = e_BattleTarget.ENNEMY;
        [Space]
        [SerializeField] private int _power = 0;
        [SerializeField] private int _staminaQuantity = 10;
        [SerializeField] private int _staminaUsed = 0;

        private int _stamina = 0;

        public int GetIndex { get {return _index; } }
        public string GetName {get {return _name; } }
        public ParticleSystem GetVisualEffect {get {return _visualEffect; } }
        public double GetVisualEffectDuration {get {return _visualEffectDuration; } }
        public e_ZoriTypes GetTypes {get { return _type; } }
        public e_AttackTypes GetActionType {get {return _actionType; } }
        public e_BattleTarget GetTarget {get {return _target; } }
        public int GetPower {get { return _power; } }
        public int GetStaminaQuantity {get { return _staminaQuantity; } }
        public int GetStaminaUsed {get { return _staminaUsed; } }
        public int GetStamina {get {return _stamina; } }
        public int SetStamina {set {_stamina = value; } }
        
        public void RemoveStamina(int amount)
        {
            _stamina -= amount;
        }

        public void AddStamina(int amount)
        {
            _stamina += amount;
        }
    }
}