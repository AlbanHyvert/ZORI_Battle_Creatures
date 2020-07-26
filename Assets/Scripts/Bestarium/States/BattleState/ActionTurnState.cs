using UnityEngine;

public class ActionState : IBattleState
{
    private D_AttackSystem[] _moves = null;
    private IAController _self = null;
    private IAController _ennemy = null;
    private float _time = 0;
    private float _timeBeforeAttack = 0;
    private float _timeAfterAttack = 0;
    private bool _hasInit = false;
    private bool _fightOk = false;
    private bool _hasAlreadyAttack = false;
    private bool _hasShownText = false;
    private int _choosenIMove = 0;

    void IBattleState.Enter()
    {
        _time = 0;
        _timeBeforeAttack = 0;
        _timeAfterAttack = 0;
        _hasAlreadyAttack = false;

        _choosenIMove = Random.Range(0, 3);

        if (_hasInit == false)
        {
            if (_self.GetHasStartedTheBattle == false)
                _ennemy = BattleManager.Instance.GetZoriA;
            else
                _ennemy = BattleManager.Instance.GetZoriB;

            _hasInit = true;
        }

        if (BattleManager.Instance.GetZoriA != null && BattleManager.Instance.GetZoriB != null)
            _fightOk = true;
        else
        {
            _hasInit = false;
            _fightOk = false;
            _self.ChangeState(E_BattleState.ACTIONTURN);
        }

        //Anim
        //Sound
        //Visual Effect
    }

    void IBattleState.Exit()
    {
        _time = 0;
        _timeBeforeAttack = 0;
        _timeAfterAttack = 0;
        _hasAlreadyAttack = false;
        _hasShownText = false;

        _self.DescText = string.Empty;

        if (_ennemy != null)
            _ennemy.ChangeState(E_BattleState.ACTIONTURN);
        //Anim
        //Sound
        //Visual Effect
    }

    void IBattleState.Init(IAController controller)
    {
        _self = controller;
        _moves = controller.GetMoveList.ToArray();
    }

    void IBattleState.Tick()
    {
        if(_fightOk == true)
        {
            if(_self.GetPlayer == null)
            {
                _time += 0.1f + Time.deltaTime;

                if (_time > 1)
                {
                    _timeBeforeAttack += 0.1f + Time.deltaTime;

                    if(_hasShownText == false)
                    {
                        switch (_choosenIMove)
                        {
                            case 0:
                                _self.DescText = _self.name + " " + "use" + " " + _self.GetDicMoves[E_Slots.A].GetName;
                                break;
                            case 1:
                                _self.DescText = _self.name + " " + "use" + " " + _self.GetDicMoves[E_Slots.B].GetName;
                                break;
                            case 2:
                                _self.DescText = _self.name + " " + "use" + " " + _self.GetDicMoves[E_Slots.C].GetName;
                                break;
                            case 3:
                                _self.DescText = _self.name + " " + "use" + " " + _self.GetDicMoves[E_Slots.D].GetName;
                                break;
                            default:
                                break;
                        }
                        _hasShownText = true;
                    }
        
                    if(_timeBeforeAttack > 5)
                    {
                        _timeAfterAttack += 0.1f + Time.deltaTime;

                        if(_hasAlreadyAttack == false)
                        {
                            DealDamage(_choosenIMove);
                            _hasAlreadyAttack = true;
                        }
                    }

                    if(_timeAfterAttack > 2)
                        _self.ChangeState(E_BattleState.ENDTURN);
                }
            }
        }
    }

    public void DealDamage(int i_Move = 0, E_Slots e_Move = E_Slots.A)
    {
        if(_self.GetPlayer == null)
        {
            switch (i_Move)
            {
                case 0:
                    _ennemy.GetHealth.TakeDamage(BattleManager.Instance.BattleSettings.CalculateDamage(_self, E_Slots.A, _ennemy));
                    break;
                case 1:
                    _ennemy.GetHealth.TakeDamage(BattleManager.Instance.BattleSettings.CalculateDamage(_self, E_Slots.B, _ennemy));
                    break;
                case 2:
                    _ennemy.GetHealth.TakeDamage(BattleManager.Instance.BattleSettings.CalculateDamage(_self, E_Slots.C, _ennemy));
                    break;
                case 3:
                    _ennemy.GetHealth.TakeDamage(BattleManager.Instance.BattleSettings.CalculateDamage(_self, E_Slots.D, _ennemy));
                    break;
            }
        }
        else
        {
            _ennemy.GetHealth.TakeDamage(BattleManager.Instance.BattleSettings.CalculateDamage(_self, e_Move, _ennemy));
        }
    }
}