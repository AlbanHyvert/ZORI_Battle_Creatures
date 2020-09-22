using UnityEngine;
using Utilities.Battle;

public class ResultTurnState : MonoBehaviour, IBattleState
{
    private IAController _self = null;
    private IAController _ennemy = null;
    private float _time = 0;
    private float _timeBeforeNextState = 1;
    private bool _isInit = false;
    private E_Slots _choosenMove = E_Slots.A;

    void IBattleState.Enter()
    {
        if (_isInit == false)
        {
            _ennemy = BattleManager.Instance.GetBattleData.receiver;
        }

        _choosenMove = BattleManager.Instance.GetBattleData.choosenAtt;

        _isInit = true;
    }

    void IBattleState.Exit()
    {
        _time = 0;
        _self.SetDescText = string.Empty;
    }

    void IBattleState.Init(IAController controller)
    {
        _self = controller;
    }

    void IBattleState.Tick()
    {
        _time += 1f * Time.deltaTime;

        if (_time > _timeBeforeNextState)
        {
            switch(_self.GetDicMoves[_choosenMove].GetTarget)
            {
                case E_Target.SELF:
                    _self.GetHealth.Heal(BattleUtilities.CalculateHealValue(_self, _choosenMove));
                break;
                case E_Target.ALLY:
                break;
                case E_Target.EVERYONE:
                break;
                case E_Target.ALLENNEMY:
                break;
                case E_Target.ENNEMY:
                    _ennemy.GetHealth.TakeDamage(BattleUtilities.CheckDamage(_self, _choosenMove, _ennemy));
                break;
            }
           
            _self.ChangeBattleState(E_BattleState.ENDTURN);
        }
    }
}
