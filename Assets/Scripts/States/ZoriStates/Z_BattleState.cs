using System.Collections.Generic;
using UnityEngine;

public class Z_BattleState : IZoriStates
{
    private IA_Zori _self = null;
    private Dictionary<E_CapacitySlot, ZoriMoves> _moves = null;
    private ZoriMoves[] _capacities = null;
    private BaseStats _attackStats = null;
    private BaseStats _defenseStats = null;
    private E_CapacitySlot _favAttack = E_CapacitySlot.SLOT_A;
    private PlayerController _player = null;
    private IA_Zori _target = null;

    void IZoriStates.Init(IA_Zori self)
    {
        _self = self;
        _moves = self.Moves;
        _capacities = self.Capacities;
        _attackStats = self.AttackStats;
        _defenseStats = self.DefenseStats;
        _favAttack = self.FavAttack;
        _player = PlayerManager.Instance.PlayerInstance;
    }

    void IZoriStates.Enter()
    {
        //FX Sound
        _player.IsInBattleMode = true;
        switch (_self.Status)
        {
            case E_ZoriWorldStatus.WILD:
                _self.transform.position = _player.BattleSettings.ZoriPosition[1].position;
                BattleManager.Instance.WildZori = _self;
                _target = BattleManager.Instance.PlayerZori;
                break;
            case E_ZoriWorldStatus.OWNED:
                _self.transform.position = _player.BattleSettings.ZoriPosition[0].position;
                BattleManager.Instance.WildZori = _self;
                _target = BattleManager.Instance.PlayerZori;
                break;
            default:
                break;
        }   
    }

    void IZoriStates.Exit()
    {

    }

    void IZoriStates.Tick()
    {
        if(_self.IsMyTurn == true)
        {
            int i = Random.Range(1, 100);

            if (i > 70)
            {
                _target.HPStats.Minimum =  _moves[_favAttack].Damage;
            }
            else if (i <= 70 && i > 50)
            {
                //_moves[E_CapacitySlot.SLOT_A].Damage;
            }
            else if (i <= 50 && i > 30)
            {
                //_move[E_CapacitySlot.SLOT_B].Damage;
            }
            else if (i <= 30 && i > 10)
            {
                //_moves[E_CapacitySlot.SLOT_C].Damage;
            }
            else if (i <= 10)
            {
                //_moves[E_CapacitySlot.SLOT_D].Damage;
            }

            _self.IsMyTurn = false;
        }
    }
}
