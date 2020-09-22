using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_AttackSlot : MonoBehaviour
{
    [SerializeField] private E_Slots _activeSlot = E_Slots.A;
    [Space]
    [SerializeField] private TextMeshProUGUI _name = null;

    private IAController _playerZori = null;

    private void OnEnable()
    {
        _playerZori = PlayerManager.Instance.GetPlayer.GetBattlingZori;

        switch (_activeSlot)
        {
            case E_Slots.A:
                _name.text = _playerZori.GetDicMoves[E_Slots.A].GetName;
                break;
            case E_Slots.B:
                _name.text = _playerZori.GetDicMoves[E_Slots.B].GetName;
                break;
            case E_Slots.C:
                _name.text = _playerZori.GetDicMoves[E_Slots.C].GetName;
                break;
            case E_Slots.D:
                _name.text = _playerZori.GetDicMoves[E_Slots.D].GetName;
                break;
            default:
                break;
        }
    }

    public void OnPress()
    {
        PlayerManager.Instance.GetPlayer.SetMove = _activeSlot;
    }
}
