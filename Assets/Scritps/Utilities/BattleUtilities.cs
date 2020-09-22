namespace Utilities.Battle
{
    using UnityEngine;

    public static class BattleUtilities
    {
        private static int _damage = 0;
        private static double _bonusDamage = 0;

        public static int CheckDamage(IAController sender, E_Slots choosenMove, IAController receiver)
        {
            int damage = 0;

            switch (sender.GetDicMoves[choosenMove].GetStyle)
            {
                case E_AtkStyles.STATUS:
                    break;
                case E_AtkStyles.SPECIAL:
                    damage = CalculateSpecialDamage(sender, choosenMove, receiver);
                    break;
                case E_AtkStyles.PHYSIQUE:
                    damage = CalculatePhysicalDamage(sender, choosenMove, receiver);
                    break;
            }

            return damage;
        }
        public static int CalculateHealValue(IAController sender, E_Slots choosenMove)
        {
            int heal = sender.GetHealth.CurrentHealth + (sender.GetHealth.MaxHealth * (sender.GetDicMoves[choosenMove].GetPower / 100));

            return heal;
        }
        private static int CalculatePhysicalDamage(IAController sender, E_Slots choosenMove, IAController receiver)
        {
            _bonusDamage = 0;
            _damage = 0;

            _damage = ((((2 * sender.GetLevel) / 5) + 2) * sender.GetDicMoves[choosenMove].GetPower * (sender.GetStats.GetAttack / receiver.GetStats.GetDefence) / 50) + 2;

            Debug.Log(sender.GetStats.GetName + " " + " Physical HTC" + " " + _damage);

            float bonusValue  = Mathf.Abs((float)CheckBonusStats(sender, choosenMove, receiver));

            _damage = (int)Mathf.Abs(_damage * bonusValue);

            Debug.Log(sender.GetStats.GetName + " " + "Physical TTC" + " " + _damage);

            return _damage;
        }
        private static int CalculateSpecialDamage(IAController sender, E_Slots choosenMove, IAController receiver)
        {
            _bonusDamage = 0;
            _damage = 0;

            _damage = ((((2 * sender.GetLevel) / 5) + 2) * sender.GetDicMoves[choosenMove].GetPower * (sender.GetStats.GetSpeAttack / receiver.GetStats.GetSpeDefence) / 50) + 2;

            Debug.Log(sender.GetStats.GetName + " " + "Special HTC" + " " + _damage);

            float bonusValue = Mathf.Abs((float)CheckBonusStats(sender, choosenMove, receiver));

            _damage = (int)Mathf.Abs(_damage * bonusValue);

            Debug.Log(sender.GetStats.GetName + " " + "Special TTC" + " " + _damage);

            return _damage;
        }
        public static float CalculateExperienceGain(IAController beaten)
        {
            float gain = 1 * (beaten.GetExperience + 100) * (beaten.GetLevel / 7);

            return gain;
        }
        private static double CheckBonusStats(IAController sender, E_Slots choosenMove, IAController receiver)
        {
            if (receiver.GetStats.GetTypes.Length < 2)
            {
                switch (sender.GetDicMoves[choosenMove].GetTypes)
                {
                    case E_Types.NEUTRAL:
                        switch (receiver.GetStats.GetTypes[0])
                        {
                            case E_Types.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PYRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.HYDRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PHYTO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.CRYO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.VENO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.GEO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.AERO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.INSECTO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.METAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _bonusDamage = 0;
                                break;
                            case E_Types.UMBRA:
                                _bonusDamage = 1;
                                break;
                            case E_Types.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.PYRO:
                        switch (receiver.GetStats.GetTypes[0])
                        {
                            case E_Types.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PYRO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.HYDRO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.PHYTO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.CRYO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.VENO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.GEO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.AERO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.INSECTO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.METAL:
                                _bonusDamage = 2;
                                break;
                            case E_Types.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.UMBRA:
                                _bonusDamage = 2;
                                break;
                            case E_Types.LUMA:
                                _bonusDamage = 0.5f;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.HYDRO:
                        switch (receiver.GetStats.GetTypes[0])
                        {
                            case E_Types.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PYRO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.HYDRO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.PHYTO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.CRYO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.VENO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.GEO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.AERO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.INSECTO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.METAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.UMBRA:
                                _bonusDamage = 1;
                                break;
                            case E_Types.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.PHYTO:
                        switch (receiver.GetStats.GetTypes[0])
                        {
                            case E_Types.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PYRO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.HYDRO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.PHYTO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.CRYO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.VENO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.GEO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.AERO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.INSECTO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.METAL:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.UMBRA:
                                _bonusDamage = 1;
                                break;
                            case E_Types.LUMA:
                                _bonusDamage = 2;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.ELECTRO:
                        switch (receiver.GetStats.GetTypes[0])
                        {
                            case E_Types.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PYRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.HYDRO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.PHYTO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.ELECTRO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.CRYO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.VENO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.GEO:
                                _bonusDamage = 0;
                                break;
                            case E_Types.AERO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.INSECTO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.METAL:
                                _bonusDamage = 2;
                                break;
                            case E_Types.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.MENTAL:
                                _bonusDamage = 2;
                                break;
                            case E_Types.SPECTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.UMBRA:
                                _bonusDamage = 1;
                                break;
                            case E_Types.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.CRYO:
                        switch (receiver.GetStats.GetTypes[0])
                        {
                            case E_Types.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PYRO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.HYDRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PHYTO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.CRYO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.VENO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.GEO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.AERO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.INSECTO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.METAL:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _bonusDamage = 0;
                                break;
                            case E_Types.UMBRA:
                                _bonusDamage = 1;
                                break;
                            case E_Types.LUMA:
                                _bonusDamage = 0.5f;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.VENO:
                        switch (receiver.GetStats.GetTypes[0])
                        {
                            case E_Types.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PYRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.HYDRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PHYTO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.CRYO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.VENO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.GEO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.AERO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.INSECTO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.METAL:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.MENTAL:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.SPECTRAL:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.UMBRA:
                                _bonusDamage = 1;
                                break;
                            case E_Types.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.GEO:
                        switch (receiver.GetStats.GetTypes[0])
                        {
                            case E_Types.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PYRO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.HYDRO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.PHYTO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.ELECTRO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.CRYO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.VENO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.GEO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.AERO:
                                _bonusDamage = 0;
                                break;
                            case E_Types.INSECTO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.METAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.UMBRA:
                                _bonusDamage = 1;
                                break;
                            case E_Types.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.AERO:
                        switch (receiver.GetStats.GetTypes[0])
                        {
                            case E_Types.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PYRO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.HYDRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PHYTO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.ELECTRO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.CRYO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.VENO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.GEO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.AERO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.INSECTO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.METAL:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.UMBRA:
                                _bonusDamage = 1;
                                break;
                            case E_Types.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.INSECTO:
                        switch (receiver.GetStats.GetTypes[0])
                        {
                            case E_Types.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PYRO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.HYDRO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.PHYTO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.CRYO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.VENO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.GEO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.AERO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.INSECTO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.METAL:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.MARTIAL:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.MENTAL:
                                _bonusDamage = 2;
                                break;
                            case E_Types.SPECTRAL:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.UMBRA:
                                _bonusDamage = 1;
                                break;
                            case E_Types.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.METAL:
                        switch (receiver.GetStats.GetTypes[0])
                        {
                            case E_Types.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PYRO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.HYDRO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.PHYTO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.CRYO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.VENO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.GEO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.AERO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.INSECTO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.METAL:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.UMBRA:
                                _bonusDamage = 1;
                                break;
                            case E_Types.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.MARTIAL:
                        switch (receiver.GetStats.GetTypes[0])
                        {
                            case E_Types.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PYRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.HYDRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PHYTO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.CRYO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.VENO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.GEO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.AERO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.INSECTO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.METAL:
                                _bonusDamage = 2;
                                break;
                            case E_Types.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _bonusDamage = 0;
                                break;
                            case E_Types.UMBRA:
                                _bonusDamage = 2;
                                break;
                            case E_Types.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.MENTAL:
                        switch (receiver.GetStats.GetTypes[0])
                        {
                            case E_Types.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PYRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.HYDRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PHYTO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.CRYO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.VENO:
                                _bonusDamage = 2;
                                break;
                            case E_Types.GEO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.AERO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.INSECTO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.METAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.MARTIAL:
                                _bonusDamage = 2;
                                break;
                            case E_Types.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _bonusDamage = 0;
                                break;
                            case E_Types.UMBRA:
                                _bonusDamage = 2;
                                break;
                            case E_Types.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.SPECTRAL:
                        switch (receiver.GetStats.GetTypes[0])
                        {
                            case E_Types.NEUTRAL:
                                _bonusDamage = 0;
                                break;
                            case E_Types.PYRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.HYDRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PHYTO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.CRYO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.VENO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.GEO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.AERO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.INSECTO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.METAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.MARTIAL:
                                _bonusDamage = 0;
                                break;
                            case E_Types.MENTAL:
                                _bonusDamage = 2;
                                break;
                            case E_Types.SPECTRAL:
                                _bonusDamage = 2;
                                break;
                            case E_Types.UMBRA:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.LUMA:
                                _bonusDamage = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.UMBRA:
                        switch (receiver.GetStats.GetTypes[0])
                        {
                            case E_Types.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PYRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.HYDRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PHYTO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.CRYO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.VENO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.GEO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.AERO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.INSECTO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.METAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.MARTIAL:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.MENTAL:
                                _bonusDamage = 2;
                                break;
                            case E_Types.SPECTRAL:
                                _bonusDamage = 2;
                                break;
                            case E_Types.UMBRA:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.LUMA:
                                _bonusDamage = 2;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.LUMA:
                        switch (receiver.GetStats.GetTypes[0])
                        {
                            case E_Types.NEUTRAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PYRO:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.HYDRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.PHYTO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.ELECTRO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.CRYO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.VENO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.GEO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.AERO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.INSECTO:
                                _bonusDamage = 1;
                                break;
                            case E_Types.METAL:
                                _bonusDamage = 0.5f;
                                break;
                            case E_Types.MARTIAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.MENTAL:
                                _bonusDamage = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _bonusDamage = 2;
                                break;
                            case E_Types.UMBRA:
                                _bonusDamage = 2;
                                break;
                            case E_Types.LUMA:
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
                for (int i = 0; i < receiver.GetStats.GetTypes.Length; i++)
                {
                    switch (sender.GetDicMoves[choosenMove].GetTypes)
                    {
                        case E_Types.NEUTRAL:
                            switch (receiver.GetStats.GetTypes[i])
                            {
                                case E_Types.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PYRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.HYDRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PHYTO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.CRYO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.GEO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.AERO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.INSECTO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.METAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.SPECTRAL:
                                    _bonusDamage += 0;
                                    break;
                                case E_Types.UMBRA:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.LUMA:
                                    _bonusDamage = 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case E_Types.PYRO:
                            switch (receiver.GetStats.GetTypes[i])
                            {
                                case E_Types.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PYRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.HYDRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.PHYTO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.CRYO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.GEO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.AERO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.INSECTO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.METAL:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.SPECTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.UMBRA:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.LUMA:
                                    _bonusDamage += 0.5f;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case E_Types.HYDRO:
                            switch (receiver.GetStats.GetTypes[i])
                            {
                                case E_Types.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PYRO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.HYDRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.PHYTO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.CRYO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.GEO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.AERO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.INSECTO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.METAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.SPECTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.UMBRA:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.LUMA:
                                    _bonusDamage += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case E_Types.PHYTO:
                            switch (receiver.GetStats.GetTypes[i])
                            {
                                case E_Types.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PYRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.HYDRO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.PHYTO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.CRYO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.VENO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.GEO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.AERO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.INSECTO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.METAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.SPECTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.UMBRA:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.LUMA:
                                    _bonusDamage += 2;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case E_Types.ELECTRO:
                            switch (receiver.GetStats.GetTypes[i])
                            {
                                case E_Types.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PYRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.HYDRO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.PHYTO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.ELECTRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.CRYO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.GEO:
                                    _bonusDamage += 0;
                                    break;
                                case E_Types.AERO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.INSECTO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.METAL:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.MENTAL:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.SPECTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.UMBRA:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.LUMA:
                                    _bonusDamage += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case E_Types.CRYO:
                            switch (receiver.GetStats.GetTypes[i])
                            {
                                case E_Types.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PYRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.HYDRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PHYTO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.CRYO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.GEO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.AERO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.INSECTO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.METAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.SPECTRAL:
                                    _bonusDamage += 0;
                                    break;
                                case E_Types.UMBRA:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.LUMA:
                                    _bonusDamage += 0.5f;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case E_Types.VENO:
                            switch (receiver.GetStats.GetTypes[i])
                            {
                                case E_Types.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PYRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.HYDRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PHYTO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.CRYO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.VENO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.GEO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.AERO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.INSECTO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.METAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.MENTAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.SPECTRAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.UMBRA:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.LUMA:
                                    _bonusDamage += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case E_Types.GEO:
                            switch (receiver.GetStats.GetTypes[i])
                            {
                                case E_Types.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PYRO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.HYDRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.PHYTO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.ELECTRO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.CRYO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.GEO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.AERO:
                                    _bonusDamage += 0;
                                    break;
                                case E_Types.INSECTO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.METAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.SPECTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.UMBRA:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.LUMA:
                                    _bonusDamage += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case E_Types.AERO:
                            switch (receiver.GetStats.GetTypes[i])
                            {
                                case E_Types.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PYRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.HYDRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PHYTO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.ELECTRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.CRYO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.GEO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.AERO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.INSECTO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.METAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.SPECTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.UMBRA:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.LUMA:
                                    _bonusDamage += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case E_Types.INSECTO:
                            switch (receiver.GetStats.GetTypes[i])
                            {
                                case E_Types.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PYRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.HYDRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.PHYTO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.CRYO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.GEO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.AERO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.INSECTO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.METAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.MARTIAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.MENTAL:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.SPECTRAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.UMBRA:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.LUMA:
                                    _bonusDamage += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case E_Types.METAL:
                            switch (receiver.GetStats.GetTypes[i])
                            {
                                case E_Types.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PYRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.HYDRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.PHYTO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.CRYO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.GEO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.AERO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.INSECTO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.METAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.SPECTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.UMBRA:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.LUMA:
                                    _bonusDamage += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case E_Types.MARTIAL:
                            switch (receiver.GetStats.GetTypes[i])
                            {
                                case E_Types.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PYRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.HYDRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PHYTO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.CRYO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.VENO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.GEO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.AERO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.INSECTO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.METAL:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.SPECTRAL:
                                    _bonusDamage += 0;
                                    break;
                                case E_Types.UMBRA:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.LUMA:
                                    _bonusDamage += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case E_Types.MENTAL:
                            switch (receiver.GetStats.GetTypes[i])
                            {
                                case E_Types.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PYRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.HYDRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PHYTO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.CRYO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.VENO:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.GEO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.AERO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.INSECTO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.METAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.MARTIAL:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.SPECTRAL:
                                    _bonusDamage += 0;
                                    break;
                                case E_Types.UMBRA:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.LUMA:
                                    _bonusDamage += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case E_Types.SPECTRAL:
                            switch (receiver.GetStats.GetTypes[i])
                            {
                                case E_Types.NEUTRAL:
                                    _bonusDamage += 0;
                                    break;
                                case E_Types.PYRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.HYDRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PHYTO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.CRYO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.GEO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.AERO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.INSECTO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.METAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.MARTIAL:
                                    _bonusDamage += 0;
                                    break;
                                case E_Types.MENTAL:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.SPECTRAL:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.UMBRA:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.LUMA:
                                    _bonusDamage += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case E_Types.UMBRA:
                            switch (receiver.GetStats.GetTypes[i])
                            {
                                case E_Types.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PYRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.HYDRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PHYTO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.CRYO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.GEO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.AERO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.INSECTO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.METAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.MARTIAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.MENTAL:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.SPECTRAL:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.UMBRA:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.LUMA:
                                    _bonusDamage += 2;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case E_Types.LUMA:
                            switch (receiver.GetStats.GetTypes[i])
                            {
                                case E_Types.NEUTRAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PYRO:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.HYDRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.PHYTO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.ELECTRO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.CRYO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.VENO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.GEO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.AERO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.INSECTO:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.METAL:
                                    _bonusDamage += 0.5f;
                                    break;
                                case E_Types.MARTIAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.MENTAL:
                                    _bonusDamage += 1;
                                    break;
                                case E_Types.SPECTRAL:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.UMBRA:
                                    _bonusDamage += 2;
                                    break;
                                case E_Types.LUMA:
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