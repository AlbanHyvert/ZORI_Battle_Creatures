using ZORI_Battle_Creatures.Assets.Scripts.Utilities;
using ZORI_Battle_Creatures.Assets.Scripts.Bestarium;
using ZORI_Battle_Creatures.Assets.Scripts.UI;
using ZORI_Battle_Creatures.Assets.Scripts.DataHolders;
using ZORI_Battle_Creatures.Assets.Scripts.Enumerators;
using System.Collections;
using UnityEngine;

namespace ZORI_Battle_Creatures.Assets.Scripts.BattleSystems.States
{
    public class ResolveTurn : State
    {
        private bool _playerTurnDone = false;
        private bool _ennemyTurnDone = false;

        private e_ActionSlots _ennemyAttack = e_ActionSlots.A;

        private int _damageDone = 0;

        public ResolveTurn(BattleSystem battleSystem) : base(battleSystem)
        {
            
        }

        public override IEnumerator Start()
        {
            Debug.Log("Start Execute");

            yield return BattleSystem.StartCoroutine(ExecuteAction(BattleSystem.GetPlayerAttack));

            yield break;
        }

        public override IEnumerator ExecuteAction(e_ActionSlots moves)
        {
            BattleSystem.GetPlayerUiAction.SetActive(false);
            
            int playerSpeed = BattleSystem.GetZoriPlayer.GetData.stats.speed;
            int ennemySpeed = BattleSystem.GetZoriEnnemy.GetData.stats.speed;

            _damageDone = 0;

            _ennemyAttack = BattleSystem.GetEnnemyAttack;

            MonoBehaviour behaviour  = new MonoBehaviour();

            if(playerSpeed >= ennemySpeed)
            {
                yield return BattleSystem.StartCoroutine(PlayerTurn());
            }
            else if(playerSpeed < ennemySpeed)
            {
                yield return BattleSystem.StartCoroutine(EnnemyTurn());
            }

            yield break;
        }

        private IEnumerator PlayerTurn()
        {
            ZoriController zoriEnnemy = BattleSystem.GetZoriEnnemy;
            ZoriController zoriPlayer = BattleSystem.GetZoriPlayer;
            BattleUI battleUI = BattleSystem.GetPlayerUI;
            d_CapacityStats action = zoriPlayer.GetZoriMoves[BattleSystem.GetPlayerAttack];

            battleUI.GetDescription.text = zoriPlayer.GetData.nickName + " use " + action.GetName;

            yield return new WaitForSecondsRealtime(2);

            switch(CheckTarget(zoriPlayer, true))
            {
                case e_BattleTarget.ENNEMY:
                    DamageType(zoriPlayer, zoriEnnemy, true);
                    battleUI.GetDescription.text = string.Empty;
                    CheckDamage(zoriEnnemy, true);
                break;

                case e_BattleTarget.SELF:
                    HealType(zoriPlayer, action);
                    battleUI.GetDescription.text = string.Empty;
                    CheckDamage(zoriPlayer, true);
                break;
            }

            yield return new WaitForSecondsRealtime((float)action.GetVisualEffectDuration);

            battleUI.GetDescription.text = string.Empty;

            _damageDone = 0;

            _playerTurnDone = true;

            if(BattleSystem.GetZoriEnnemy.GetCurrentHealth <= 0)
            {
                BattleSystem.SetState(new Won(BattleSystem));
            }
            else
            {
                if(_ennemyTurnDone == false)
                {
                    yield return BattleSystem.StartCoroutine(EnnemyTurn());  
                }
                else
                {
                    _playerTurnDone = false;
                    _ennemyTurnDone = false;
                    BattleSystem.SetState(new ChooseAction(BattleSystem));
                }
                
            }

            yield break;
        }

        private IEnumerator EnnemyTurn()
        {
            ZoriController zoriEnnemy = BattleSystem.GetZoriEnnemy;
            ZoriController zoriPlayer = BattleSystem.GetZoriPlayer;
            BattleUI battleUI = BattleSystem.GetEnnemyUI;
            d_CapacityStats action = zoriEnnemy.GetZoriMoves[BattleSystem.GetPlayerAttack];

            battleUI.GetDescription.text = zoriEnnemy.GetData.nickName + " use " + action.GetName;

            yield return new WaitForSecondsRealtime(2);

            switch(CheckTarget(zoriPlayer, false))
            {
                case e_BattleTarget.ENNEMY:
                    DamageType(zoriPlayer, zoriEnnemy, false);
                    battleUI.GetDescription.text = string.Empty;
                    CheckDamage(zoriPlayer, false);
                break;

                case e_BattleTarget.SELF:
                    HealType(zoriEnnemy, action);
                    battleUI.GetDescription.text = string.Empty;
                    CheckDamage(zoriEnnemy, false);
                break;
            }

            yield return new WaitForSeconds((float)zoriEnnemy.GetZoriMoves[_ennemyAttack].GetVisualEffectDuration);

            battleUI.GetDescription.text = string.Empty;

            _ennemyTurnDone = true;

            if(zoriPlayer.GetCurrentHealth <= 0)
            {
                BattleSystem.SetState(new Lost(BattleSystem));
            }
            else
            {
                if(_playerTurnDone == false)
                {
                    yield return BattleSystem.StartCoroutine(PlayerTurn());
                }
                else
                {
                    _playerTurnDone = false;
                    _ennemyTurnDone = false;
                    BattleSystem.SetState(new ChooseAction(BattleSystem));
                }
            }

            yield break;
        }

        private void DamageType(ZoriController zoriPlayer, ZoriController zoriEnnemy, bool isPlayer)
        {
            if(isPlayer == true)
            {
                _damageDone = BattleUtilities.CheckDamage(zoriPlayer, BattleSystem.GetPlayerAttack, zoriEnnemy);

                zoriEnnemy.TakeDamage(_damageDone);
            }
            else
            {
                _damageDone = BattleUtilities.CheckDamage(zoriEnnemy, _ennemyAttack, zoriPlayer);

                zoriPlayer.TakeDamage(_damageDone);
            }
        }

        private void HealType(ZoriController zori, d_CapacityStats action)
        {
            _damageDone = BattleUtilities.CalculateHealValue(zori, BattleSystem.GetPlayerAttack);

            zori.Heal(_damageDone);

            //BattleSystem.SetState(new ChooseAction(BattleSystem));
        }

        private e_BattleTarget CheckTarget(ZoriController zori, bool isPlayer)
        {
            e_BattleTarget target;

            if(isPlayer == false)
            {
                target = zori.GetZoriMoves[_ennemyAttack].GetTarget;
            }
            else
            {
                target = zori.GetZoriMoves[BattleSystem.GetPlayerAttack].GetTarget;
            }

            return target;
        }

        private void CheckDamage(ZoriController receiver, bool isPlayer)
        {
            BattleUI battleUI;

            if(isPlayer == true)
            {
                battleUI = BattleSystem.GetPlayerUI;
            }
            else
            {
                battleUI = BattleSystem.GetEnnemyUI;
            }

            int oneFifth = receiver.GetData.stats.maxHp / 5;
            int oneThird = receiver.GetData.stats.maxHp / 3;
            int half = receiver.GetData.stats.maxHp / 2;

            if(_damageDone < oneFifth)
            {
                battleUI.GetDescription.text = "this was not effective.";
                return;
            }
            else if(_damageDone >= oneFifth && _damageDone < oneThird)
            {
                battleUI.GetDescription.text = "this was effective.";
                return;
            }
            else if(_damageDone >= oneThird && _damageDone < half)
            {
                battleUI.GetDescription.text = "this was very effective!";
                return;
            }
            else if(_damageDone >= half && _damageDone < receiver.GetData.stats.maxHp)
            {
                battleUI.GetDescription.text = "this was a critical damage!";
                return;
            }
            else if(_damageDone >= receiver.GetData.stats.maxHp)
            {
                battleUI.GetDescription.text = "this was a ONE HIT KO!";
                return;
            }
        }
    }
}