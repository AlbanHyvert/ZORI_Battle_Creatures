using UnityEngine;

public class ActionState : IBattleState
{
    private IAController _self = null;
    private IAController _ennemy = null;
    private PlayerController _player = null;
    private float _time = 0;
    private float _timeBeforeNextState = 1;
    private bool _isInit = false;
    private bool _hasChoosenAtt = false;

    void IBattleState.Enter()
    {
        if (_self.GetHealth.CurrentHealth <= 0)
        {
            _self.GetHealth.CurrentHealth = 0;
            BattleManager.Instance.EndBattle();
        }

        if (_isInit == false)
        {
            _ennemy = FindEnnemy();
            _player = _self.GetPlayer;
        }

        if (_ennemy.GetHealth.CurrentHealth <= 0)
        {
            BattleManager.Instance.EndBattle();
        }

        if(_player != null)
        {
            _player.ChoosenAttack += ChooseAttack;
            
            BattleManager.Instance.GetActionUI.SetActive(true);
        }
        else
        {
            int rdm = Random.Range(0, 3);

            switch (rdm)
            {
                case 0:
                    ChooseAttack(E_Slots.A);
                    break;
                case 1:
                    ChooseAttack(E_Slots.B);
                    break;
                case 2:
                    ChooseAttack(E_Slots.C);
                    break;
                case 3:
                    ChooseAttack(E_Slots.D);
                    break;
            }
        }

        _isInit = true;
    }

    private IAController FindEnnemy()
    {
        IAController ennemy = null;

        for (int i = 0; i < BattleManager.Instance.GetZoriList.Count; i++)
        {
            if(_self != BattleManager.Instance.GetZoriList[i])
            {
                ennemy = BattleManager.Instance.GetZoriList[i];
            }
        }

        return ennemy;
    }

    void IBattleState.Exit()
    {
        _time = 0;
    }

    void IBattleState.Init(IAController controller)
    {
        _self = controller;
    }

    void IBattleState.Tick()
    {
        if(_hasChoosenAtt == true)
        {
            _time += 1f * Time.deltaTime;
        }

        if(_time > _timeBeforeNextState)
        {
            _self.ChangeBattleState(E_BattleState.RESULTTURN);
        }
    }

    private void ChooseAttack(E_Slots e_moves)
    {
        if (_player != null)
        {
            BattleManager.Instance.GetActionUI.SetActive(false);
            _player.ChoosenAttack -= ChooseAttack;
        }

        _self.SetDescText = _self.GetStats.GetName + " " + "use" + " " + _self.GetDicMoves[e_moves].GetName;

        _hasChoosenAtt = true;

        BattleManager.Instance.SetBattleData(_self, e_moves, _ennemy);
    }
}