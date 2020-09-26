using UnityEngine;
using ZORI_Battle_Creatures.Assets.Scripts.Enumerators;
using ZORI_Battle_Creatures.Assets.Scripts.Bestarium;

namespace ZORI_Battle_Creatures.Assets.Scripts.Utilities
{
    public static class BattleUtilities
    {
        private static int _damage = 0;
        private static double _bonusDamage = 0;

        public static int CheckDamage(ZoriController sender, e_ActionSlots choosenMove, ZoriController receiver)
        {
            int damage = 0;

            switch (sender.GetZoriMoves[choosenMove].GetActionType)
            {
                case e_AttackTypes.STATUS:
                    break;
                case e_AttackTypes.SPECIAL:
                    damage = CalculateSpecialDamage(sender, choosenMove, receiver);
                    break;
                case e_AttackTypes.PHYSICAL:
                    damage = CalculatePhysicalDamage(sender, choosenMove, receiver);
                    break;
            }

            return damage;
        }
        public static int CalculateHealValue(ZoriController sender, e_ActionSlots choosenMove)
        {
            int heal = sender.GetCurrentHealth + (sender.GetData.stats.maxHp * (sender.GetZoriMoves[choosenMove].GetPower / 100));

            return heal;
        }
        private static int CalculatePhysicalDamage(ZoriController sender, e_ActionSlots choosenMove, ZoriController receiver)
        {
            _bonusDamage = 0;
            _damage = 0;

            _damage = ((((2 * sender.GetData.stats.level) / 5) + 2) * sender.GetZoriMoves[choosenMove].GetPower * (sender.GetData.stats.attack / receiver.GetData.stats.defence) / 50) + 2;

            Debug.Log(sender.GetData.nickName + " " + " Physical HTC" + " " + _damage);

            float bonusValue  = Mathf.Abs((float)CheckBonusStats(sender, choosenMove, receiver));

            _damage = (int)Mathf.Abs(_damage * bonusValue);

            Debug.Log(sender.GetData.nickName + " " + "Physical TTC" + " " + _damage);

            return _damage;
        }
        private static int CalculateSpecialDamage(ZoriController sender, e_ActionSlots choosenMove, ZoriController receiver)
        {
            _bonusDamage = 0;
            _damage = 0;

            _damage = ((((2 * sender.GetData.stats.level) / 5) + 2) * sender.GetZoriMoves[choosenMove].GetPower * (sender.GetData.stats.specialAtt / receiver.GetData.stats.specialDef) / 50) + 2;

            Debug.Log(sender.GetData.nickName + " " + "Special HTC" + " " + _damage);

            float bonusValue = Mathf.Abs((float)CheckBonusStats(sender, choosenMove, receiver));

            _damage = (int)Mathf.Abs(_damage * bonusValue);

            Debug.Log(sender.GetData.nickName + " " + "Special TTC" + " " + _damage);

            return _damage;
        }
        public static float CalculateExperienceGain(ZoriController beaten)
        {
            float gain = 1 * (beaten.GetData.stats.experience + 100) * (beaten.GetData.stats.level / 7);

            return gain;
        }
        public static int CalculateNewMaxHealthValue(ZoriController sender)
        {
            int level = sender.GetData.stats.level;

            Debug.Log("level: " + level);

            int newHp = (((2 * sender.GetBaseStats.hp + sender.GetBattlePoints.hp / 4) * level) / 100) + level + 15;
            return newHp;
        }
        private static double CheckBonusStats(ZoriController sender, e_ActionSlots choosenMove, ZoriController receiver)
        {
            if (receiver.GetData.types.Length < 2)
            {
                switch (sender.GetZoriMoves[choosenMove].GetTypes)
                {
                    case e_ZoriTypes.NEUTRAL:
                        switch (receiver.GetData.types[0])
                        {
                            case e_ZoriTypes.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PYRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.HYDRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PHYTO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.CRYO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.VENO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.GEO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.AERO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.INSECTO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.METAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.SPECTRAL:
                                _bonusDamage = 0;
                                break;
                            case e_ZoriTypes.UMBRA:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case e_ZoriTypes.PYRO:
                        switch (receiver.GetData.types[0])
                        {
                            case e_ZoriTypes.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PYRO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.HYDRO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.PHYTO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.CRYO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.VENO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.GEO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.AERO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.INSECTO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.METAL:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.SPECTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.UMBRA:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.LUMA:
                                _bonusDamage = 0.5f;
                                break;
                            default:
                                break;
                        }
                        break;
                    case e_ZoriTypes.HYDRO:
                        switch (receiver.GetData.types[0])
                        {
                            case e_ZoriTypes.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PYRO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.HYDRO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.PHYTO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.CRYO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.VENO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.GEO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.AERO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.INSECTO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.METAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.SPECTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.UMBRA:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case e_ZoriTypes.PHYTO:
                        switch (receiver.GetData.types[0])
                        {
                            case e_ZoriTypes.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PYRO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.HYDRO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.PHYTO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.CRYO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.VENO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.GEO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.AERO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.INSECTO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.METAL:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.SPECTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.UMBRA:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.LUMA:
                                _bonusDamage = 2;
                                break;
                            default:
                                break;
                        }
                        break;
                    case e_ZoriTypes.ELECTRO:
                        switch (receiver.GetData.types[0])
                        {
                            case e_ZoriTypes.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PYRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.HYDRO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.PHYTO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.ELECTRO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.CRYO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.VENO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.GEO:
                                _bonusDamage = 0;
                                break;
                            case e_ZoriTypes.AERO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.INSECTO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.METAL:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.MENTAL:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.SPECTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.UMBRA:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case e_ZoriTypes.CRYO:
                        switch (receiver.GetData.types[0])
                        {
                            case e_ZoriTypes.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PYRO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.HYDRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PHYTO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.CRYO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.VENO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.GEO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.AERO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.INSECTO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.METAL:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.SPECTRAL:
                                _bonusDamage = 0;
                                break;
                            case e_ZoriTypes.UMBRA:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.LUMA:
                                _bonusDamage = 0.5f;
                                break;
                            default:
                                break;
                        }
                        break;
                    case e_ZoriTypes.VENO:
                        switch (receiver.GetData.types[0])
                        {
                            case e_ZoriTypes.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PYRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.HYDRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PHYTO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.CRYO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.VENO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.GEO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.AERO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.INSECTO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.METAL:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.MENTAL:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.SPECTRAL:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.UMBRA:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case e_ZoriTypes.GEO:
                        switch (receiver.GetData.types[0])
                        {
                            case e_ZoriTypes.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PYRO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.HYDRO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.PHYTO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.ELECTRO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.CRYO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.VENO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.GEO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.AERO:
                                _bonusDamage = 0;
                                break;
                            case e_ZoriTypes.INSECTO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.METAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.SPECTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.UMBRA:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case e_ZoriTypes.AERO:
                        switch (receiver.GetData.types[0])
                        {
                            case e_ZoriTypes.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PYRO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.HYDRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PHYTO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.ELECTRO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.CRYO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.VENO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.GEO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.AERO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.INSECTO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.METAL:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.SPECTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.UMBRA:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case e_ZoriTypes.INSECTO:
                        switch (receiver.GetData.types[0])
                        {
                            case e_ZoriTypes.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PYRO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.HYDRO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.PHYTO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.CRYO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.VENO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.GEO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.AERO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.INSECTO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.METAL:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.MARTIAL:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.MENTAL:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.SPECTRAL:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.UMBRA:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case e_ZoriTypes.METAL:
                        switch (receiver.GetData.types[0])
                        {
                            case e_ZoriTypes.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PYRO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.HYDRO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.PHYTO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.CRYO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.VENO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.GEO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.AERO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.INSECTO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.METAL:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.SPECTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.UMBRA:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case e_ZoriTypes.MARTIAL:
                        switch (receiver.GetData.types[0])
                        {
                            case e_ZoriTypes.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PYRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.HYDRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PHYTO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.CRYO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.VENO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.GEO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.AERO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.INSECTO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.METAL:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.SPECTRAL:
                                _bonusDamage = 0;
                                break;
                            case e_ZoriTypes.UMBRA:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case e_ZoriTypes.MENTAL:
                        switch (receiver.GetData.types[0])
                        {
                            case e_ZoriTypes.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PYRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.HYDRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PHYTO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.CRYO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.VENO:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.GEO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.AERO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.INSECTO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.METAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.MARTIAL:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.SPECTRAL:
                                _bonusDamage = 0;
                                break;
                            case e_ZoriTypes.UMBRA:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case e_ZoriTypes.SPECTRAL:
                        switch (receiver.GetData.types[0])
                        {
                            case e_ZoriTypes.NEUTRAL:
                                _bonusDamage = 0;
                                break;
                            case e_ZoriTypes.PYRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.HYDRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PHYTO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.CRYO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.VENO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.GEO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.AERO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.INSECTO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.METAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.MARTIAL:
                                _bonusDamage = 0;
                                break;
                            case e_ZoriTypes.MENTAL:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.SPECTRAL:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.UMBRA:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case e_ZoriTypes.UMBRA:
                        switch (receiver.GetData.types[0])
                        {
                            case e_ZoriTypes.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PYRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.HYDRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PHYTO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.CRYO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.VENO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.GEO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.AERO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.INSECTO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.METAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.MARTIAL:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.MENTAL:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.SPECTRAL:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.UMBRA:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.LUMA:
                                _bonusDamage = 2;
                                break;
                            default:
                                break;
                        }
                        break;
                    case e_ZoriTypes.LUMA:
                        switch (receiver.GetData.types[0])
                        {
                            case e_ZoriTypes.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PYRO:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.HYDRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.PHYTO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.CRYO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.VENO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.GEO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.AERO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.INSECTO:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.METAL:
                                _bonusDamage = 0.5f;
                                break;
                            case e_ZoriTypes.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case e_ZoriTypes.SPECTRAL:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.UMBRA:
                                _bonusDamage = 2;
                                break;
                            case e_ZoriTypes.LUMA:
                                _bonusDamage = 0.5f;
                                break;
                            default:
                                break;
                        }
                        break;
                }
            }
            else
            {
                for (int i = 0; i < receiver.GetData.types.Length; i++)
                {
                    switch (sender.GetZoriMoves[choosenMove].GetTypes)
                    {
                        case e_ZoriTypes.NEUTRAL:
                            switch (receiver.GetData.types[i])
                            {
                                case e_ZoriTypes.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PYRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.HYDRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PHYTO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.CRYO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.GEO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.AERO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.INSECTO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.METAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.SPECTRAL:
                                    _bonusDamage += 0;
                                    break;
                                case e_ZoriTypes.UMBRA:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.LUMA:
                                    _bonusDamage = 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case e_ZoriTypes.PYRO:
                            switch (receiver.GetData.types[i])
                            {
                                case e_ZoriTypes.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PYRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.HYDRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.PHYTO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.CRYO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.GEO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.AERO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.INSECTO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.METAL:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.SPECTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.UMBRA:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.LUMA:
                                    _bonusDamage += 0.5f;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case e_ZoriTypes.HYDRO:
                            switch (receiver.GetData.types[i])
                            {
                                case e_ZoriTypes.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PYRO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.HYDRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.PHYTO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.CRYO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.GEO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.AERO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.INSECTO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.METAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.SPECTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.UMBRA:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.LUMA:
                                    _bonusDamage += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case e_ZoriTypes.PHYTO:
                            switch (receiver.GetData.types[i])
                            {
                                case e_ZoriTypes.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PYRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.HYDRO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.PHYTO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.CRYO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.VENO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.GEO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.AERO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.INSECTO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.METAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.SPECTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.UMBRA:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.LUMA:
                                    _bonusDamage += 2;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case e_ZoriTypes.ELECTRO:
                            switch (receiver.GetData.types[i])
                            {
                                case e_ZoriTypes.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PYRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.HYDRO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.PHYTO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.ELECTRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.CRYO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.GEO:
                                    _bonusDamage += 0;
                                    break;
                                case e_ZoriTypes.AERO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.INSECTO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.METAL:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.MENTAL:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.SPECTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.UMBRA:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.LUMA:
                                    _bonusDamage += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case e_ZoriTypes.CRYO:
                            switch (receiver.GetData.types[i])
                            {
                                case e_ZoriTypes.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PYRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.HYDRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PHYTO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.CRYO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.GEO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.AERO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.INSECTO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.METAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.SPECTRAL:
                                    _bonusDamage += 0;
                                    break;
                                case e_ZoriTypes.UMBRA:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.LUMA:
                                    _bonusDamage += 0.5f;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case e_ZoriTypes.VENO:
                            switch (receiver.GetData.types[i])
                            {
                                case e_ZoriTypes.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PYRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.HYDRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PHYTO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.CRYO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.VENO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.GEO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.AERO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.INSECTO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.METAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.MENTAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.SPECTRAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.UMBRA:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.LUMA:
                                    _bonusDamage += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case e_ZoriTypes.GEO:
                            switch (receiver.GetData.types[i])
                            {
                                case e_ZoriTypes.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PYRO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.HYDRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.PHYTO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.ELECTRO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.CRYO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.GEO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.AERO:
                                    _bonusDamage += 0;
                                    break;
                                case e_ZoriTypes.INSECTO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.METAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.SPECTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.UMBRA:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.LUMA:
                                    _bonusDamage += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case e_ZoriTypes.AERO:
                            switch (receiver.GetData.types[i])
                            {
                                case e_ZoriTypes.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PYRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.HYDRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PHYTO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.ELECTRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.CRYO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.GEO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.AERO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.INSECTO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.METAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.SPECTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.UMBRA:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.LUMA:
                                    _bonusDamage += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case e_ZoriTypes.INSECTO:
                            switch (receiver.GetData.types[i])
                            {
                                case e_ZoriTypes.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PYRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.HYDRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.PHYTO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.CRYO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.GEO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.AERO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.INSECTO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.METAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.MARTIAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.MENTAL:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.SPECTRAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.UMBRA:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.LUMA:
                                    _bonusDamage += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case e_ZoriTypes.METAL:
                            switch (receiver.GetData.types[i])
                            {
                                case e_ZoriTypes.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PYRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.HYDRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.PHYTO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.CRYO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.GEO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.AERO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.INSECTO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.METAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.SPECTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.UMBRA:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.LUMA:
                                    _bonusDamage += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case e_ZoriTypes.MARTIAL:
                            switch (receiver.GetData.types[i])
                            {
                                case e_ZoriTypes.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PYRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.HYDRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PHYTO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.CRYO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.VENO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.GEO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.AERO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.INSECTO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.METAL:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.SPECTRAL:
                                    _bonusDamage += 0;
                                    break;
                                case e_ZoriTypes.UMBRA:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.LUMA:
                                    _bonusDamage += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case e_ZoriTypes.MENTAL:
                            switch (receiver.GetData.types[i])
                            {
                                case e_ZoriTypes.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PYRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.HYDRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PHYTO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.CRYO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.VENO:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.GEO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.AERO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.INSECTO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.METAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.MARTIAL:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.SPECTRAL:
                                    _bonusDamage += 0;
                                    break;
                                case e_ZoriTypes.UMBRA:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.LUMA:
                                    _bonusDamage += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case e_ZoriTypes.SPECTRAL:
                            switch (receiver.GetData.types[i])
                            {
                                case e_ZoriTypes.NEUTRAL:
                                    _bonusDamage += 0;
                                    break;
                                case e_ZoriTypes.PYRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.HYDRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PHYTO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.CRYO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.GEO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.AERO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.INSECTO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.METAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.MARTIAL:
                                    _bonusDamage += 0;
                                    break;
                                case e_ZoriTypes.MENTAL:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.SPECTRAL:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.UMBRA:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.LUMA:
                                    _bonusDamage += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case e_ZoriTypes.UMBRA:
                            switch (receiver.GetData.types[i])
                            {
                                case e_ZoriTypes.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PYRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.HYDRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PHYTO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.CRYO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.GEO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.AERO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.INSECTO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.METAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.MARTIAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.MENTAL:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.SPECTRAL:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.UMBRA:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.LUMA:
                                    _bonusDamage += 2;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case e_ZoriTypes.LUMA:
                            switch (receiver.GetData.types[i])
                            {
                                case e_ZoriTypes.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PYRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.HYDRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.PHYTO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.CRYO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.GEO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.AERO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.INSECTO:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.METAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case e_ZoriTypes.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case e_ZoriTypes.SPECTRAL:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.UMBRA:
                                    _bonusDamage += 2;
                                    break;
                                case e_ZoriTypes.LUMA:
                                    _bonusDamage += 0.5f;
                                    break;
                                default:
                                    break;
                            }
                            break;
                    }
                }
            }

            Debug.Log("Bonus Damage: " + _bonusDamage);

            return _bonusDamage;
        }
    }
}