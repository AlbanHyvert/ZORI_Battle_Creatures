using UnityEngine;

public class BattleSettings : MonoBehaviour
{
    [SerializeField] private UI_Zori _zoriA = null;
    [SerializeField] private UI_Zori _zoriB = null;

    private int _damage = 0;
    private float _doubleBonus = 1;
    [Range(1,10)] private float _bonusDamage = 1;

    public int GetDamage { get { return _damage; } }
    public UI_Zori GetUIZoriA { get { return _zoriA; } }
    public UI_Zori GetUIZoriB { get { return _zoriB; } }

    public int CalculateDamage(IAController sender, E_Slots choosenMove, IAController receiver)
    {
        _damage = ((((2 * sender.GetLevel) / 5) + 2) * sender.GetDicMoves[choosenMove].GetPower * (sender.GetStats.GetAttack / receiver.GetStats.GetDefence) / 50) + 2;

        CheckBonusStats(sender, choosenMove, receiver);

        Debug.Log(sender.GetStats.GetName + " " + "HTC" + " " +_damage);

        int dmg = (int)Mathf.Abs(_damage * _bonusDamage);

        _damage = dmg;

        Debug.Log(sender.GetStats.GetName + " " + "TTC" + " " + _damage);

        _doubleBonus = 0;
        _bonusDamage = 0;

        return _damage;
    }

    private void CheckBonusStats(IAController sender, E_Slots choosenMove, IAController receiver)
    {
        if(receiver.GetStats.GetTypes.Length < 2)
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
                default:
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
                                _doubleBonus = 1;
                                break;
                            case E_Types.PYRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.HYDRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PHYTO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.ELECTRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.CRYO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.VENO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.GEO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.AERO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.INSECTO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.METAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.MARTIAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.MENTAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _doubleBonus = 0;
                                break;
                            case E_Types.UMBRA:
                                _doubleBonus = 1;
                                break;
                            case E_Types.LUMA:
                                _doubleBonus = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.PYRO:
                        switch (receiver.GetStats.GetTypes[i])
                        {
                            case E_Types.NEUTRAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PYRO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.HYDRO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.PHYTO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.ELECTRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.CRYO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.VENO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.GEO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.AERO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.INSECTO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.METAL:
                                _doubleBonus = 2;
                                break;
                            case E_Types.MARTIAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.MENTAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.UMBRA:
                                _doubleBonus = 2;
                                break;
                            case E_Types.LUMA:
                                _doubleBonus = 0.5f;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.HYDRO:
                        switch (receiver.GetStats.GetTypes[i])
                        {
                            case E_Types.NEUTRAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PYRO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.HYDRO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.PHYTO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.ELECTRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.CRYO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.VENO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.GEO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.AERO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.INSECTO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.METAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.MARTIAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.MENTAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.UMBRA:
                                _doubleBonus = 1;
                                break;
                            case E_Types.LUMA:
                                _doubleBonus = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.PHYTO:
                        switch (receiver.GetStats.GetTypes[i])
                        {
                            case E_Types.NEUTRAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PYRO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.HYDRO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.PHYTO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.ELECTRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.CRYO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.VENO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.GEO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.AERO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.INSECTO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.METAL:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.MARTIAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.MENTAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.UMBRA:
                                _doubleBonus = 1;
                                break;
                            case E_Types.LUMA:
                                _doubleBonus = 2;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.ELECTRO:
                        switch (receiver.GetStats.GetTypes[i])
                        {
                            case E_Types.NEUTRAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PYRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.HYDRO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.PHYTO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.ELECTRO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.CRYO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.VENO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.GEO:
                                _doubleBonus = 0;
                                break;
                            case E_Types.AERO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.INSECTO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.METAL:
                                _doubleBonus = 2;
                                break;
                            case E_Types.MARTIAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.MENTAL:
                                _doubleBonus = 2;
                                break;
                            case E_Types.SPECTRAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.UMBRA:
                                _doubleBonus = 1;
                                break;
                            case E_Types.LUMA:
                                _doubleBonus = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.CRYO:
                        switch (receiver.GetStats.GetTypes[i])
                        {
                            case E_Types.NEUTRAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PYRO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.HYDRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PHYTO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.ELECTRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.CRYO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.VENO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.GEO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.AERO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.INSECTO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.METAL:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.MARTIAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.MENTAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _doubleBonus = 0;
                                break;
                            case E_Types.UMBRA:
                                _doubleBonus = 1;
                                break;
                            case E_Types.LUMA:
                                _doubleBonus = 0.5f;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.VENO:
                        switch (receiver.GetStats.GetTypes[i])
                        {
                            case E_Types.NEUTRAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PYRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.HYDRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PHYTO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.ELECTRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.CRYO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.VENO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.GEO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.AERO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.INSECTO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.METAL:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.MARTIAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.MENTAL:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.SPECTRAL:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.UMBRA:
                                _doubleBonus = 1;
                                break;
                            case E_Types.LUMA:
                                _doubleBonus = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.GEO:
                        switch (receiver.GetStats.GetTypes[i])
                        {
                            case E_Types.NEUTRAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PYRO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.HYDRO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.PHYTO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.ELECTRO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.CRYO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.VENO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.GEO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.AERO:
                                _doubleBonus = 0;
                                break;
                            case E_Types.INSECTO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.METAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.MARTIAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.MENTAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.UMBRA:
                                _doubleBonus = 1;
                                break;
                            case E_Types.LUMA:
                                _doubleBonus = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.AERO:
                        switch (receiver.GetStats.GetTypes[i])
                        {
                            case E_Types.NEUTRAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PYRO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.HYDRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PHYTO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.ELECTRO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.CRYO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.VENO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.GEO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.AERO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.INSECTO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.METAL:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.MARTIAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.MENTAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.UMBRA:
                                _doubleBonus = 1;
                                break;
                            case E_Types.LUMA:
                                _doubleBonus = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.INSECTO:
                        switch (receiver.GetStats.GetTypes[i])
                        {
                            case E_Types.NEUTRAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PYRO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.HYDRO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.PHYTO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.ELECTRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.CRYO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.VENO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.GEO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.AERO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.INSECTO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.METAL:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.MARTIAL:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.MENTAL:
                                _doubleBonus = 2;
                                break;
                            case E_Types.SPECTRAL:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.UMBRA:
                                _doubleBonus = 1;
                                break;
                            case E_Types.LUMA:
                                _doubleBonus = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.METAL:
                        switch (receiver.GetStats.GetTypes[i])
                        {
                            case E_Types.NEUTRAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PYRO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.HYDRO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.PHYTO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.ELECTRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.CRYO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.VENO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.GEO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.AERO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.INSECTO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.METAL:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.MARTIAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.MENTAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.UMBRA:
                                _doubleBonus = 1;
                                break;
                            case E_Types.LUMA:
                                _doubleBonus = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.MARTIAL:
                        switch (receiver.GetStats.GetTypes[i])
                        {
                            case E_Types.NEUTRAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PYRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.HYDRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PHYTO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.ELECTRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.CRYO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.VENO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.GEO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.AERO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.INSECTO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.METAL:
                                _doubleBonus = 2;
                                break;
                            case E_Types.MARTIAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.MENTAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _doubleBonus = 0;
                                break;
                            case E_Types.UMBRA:
                                _doubleBonus = 2;
                                break;
                            case E_Types.LUMA:
                                _doubleBonus = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.MENTAL:
                        switch (receiver.GetStats.GetTypes[i])
                        {
                            case E_Types.NEUTRAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PYRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.HYDRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PHYTO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.ELECTRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.CRYO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.VENO:
                                _doubleBonus = 2;
                                break;
                            case E_Types.GEO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.AERO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.INSECTO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.METAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.MARTIAL:
                                _doubleBonus = 2;
                                break;
                            case E_Types.MENTAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _doubleBonus = 0;
                                break;
                            case E_Types.UMBRA:
                                _doubleBonus = 2;
                                break;
                            case E_Types.LUMA:
                                _doubleBonus = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.SPECTRAL:
                        switch (receiver.GetStats.GetTypes[i])
                        {
                            case E_Types.NEUTRAL:
                                _doubleBonus = 0;
                                break;
                            case E_Types.PYRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.HYDRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PHYTO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.ELECTRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.CRYO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.VENO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.GEO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.AERO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.INSECTO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.METAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.MARTIAL:
                                _doubleBonus = 0;
                                break;
                            case E_Types.MENTAL:
                                _doubleBonus = 2;
                                break;
                            case E_Types.SPECTRAL:
                                _doubleBonus = 2;
                                break;
                            case E_Types.UMBRA:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.LUMA:
                                _doubleBonus = 1;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.UMBRA:
                        switch (receiver.GetStats.GetTypes[i])
                        {
                            case E_Types.NEUTRAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PYRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.HYDRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PHYTO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.ELECTRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.CRYO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.VENO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.GEO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.AERO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.INSECTO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.METAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.MARTIAL:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.MENTAL:
                                _doubleBonus = 2;
                                break;
                            case E_Types.SPECTRAL:
                                _doubleBonus = 2;
                                break;
                            case E_Types.UMBRA:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.LUMA:
                                _doubleBonus = 2;
                                break;
                            default:
                                break;
                        }
                        break;
                    case E_Types.LUMA:
                        switch (receiver.GetStats.GetTypes[i])
                        {
                            case E_Types.NEUTRAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PYRO:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.HYDRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.PHYTO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.ELECTRO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.CRYO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.VENO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.GEO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.AERO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.INSECTO:
                                _doubleBonus = 1;
                                break;
                            case E_Types.METAL:
                                _doubleBonus = 0.5f;
                                break;
                            case E_Types.MARTIAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.MENTAL:
                                _doubleBonus = 1;
                                break;
                            case E_Types.SPECTRAL:
                                _doubleBonus = 2;
                                break;
                            case E_Types.UMBRA:
                                _doubleBonus = 2;
                                break;
                            case E_Types.LUMA:
                                _doubleBonus = 0.5f;
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }

                _bonusDamage += _doubleBonus;
            }
        }
    }

    private void Start()
    {
        BattleManager.Instance.BattleSettings = this;
    }

    private void OnDestroy()
    {
        if(BattleManager.Instance != null)
            BattleManager.Instance.BattleSettings = null;
    }
}