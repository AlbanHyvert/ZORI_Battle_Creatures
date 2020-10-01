using ZORI_Battle_Creatures.Assets.Scripts.BattleSystems.States;
using ZORI_Battle_Creatures.Assets.Scripts.Enumerators;
using ZORI_Battle_Creatures.Assets.Scripts.Bestarium;
using ZORI_Battle_Creatures.Assets.Scripts.Managers;
using ZORI_Battle_Creatures.Assets.Scripts.UI;
using UnityEngine;

namespace ZORI_Battle_Creatures.Assets.Scripts.BattleSystems
{
    public class BattleSystem : StateMachine
    {
        [SerializeField] private Transform _zoriPlayerPos = null;
        [SerializeField] private Transform _zoriEnnemyPos = null;
        [Space]
        [SerializeField] private BattleUI _playerUI = null;
        [SerializeField] private BattleUI _ennemyUI = null;
        [Space]
        [SerializeField] private ButtonUi[] _buttons = null;
        [Space]
        [SerializeField] private GameObject _playerUiAction = null;
        
        private ZoriController _zoriPlayer = null;
        private ZoriController _zoriEnnemy = null;
        private bool _matchFinish = false;
        private e_ActionSlots _choosenAttack = e_ActionSlots.A;
        private e_ActionSlots _ennemyAttack = e_ActionSlots.A;

        #region Properties
        public ZoriController GetZoriPlayer {get{return _zoriPlayer;}}
        public ZoriController GetZoriEnnemy {get{return _zoriEnnemy;}}
        public e_ActionSlots GetPlayerAttack {get{return _choosenAttack;}}
        public e_ActionSlots SetPlayerAttack {set{_choosenAttack = value;}}
        public e_ActionSlots GetEnnemyAttack {get{return _ennemyAttack;}}
        public e_ActionSlots SetEnnemyAttack {set{_ennemyAttack = value;}}
        public BattleUI GetPlayerUI {get{return _playerUI;}}
        public BattleUI GetEnnemyUI {get{return _ennemyUI;}}
        public GameObject GetPlayerUiAction {get{return _playerUiAction;}}
        public bool SetMatchFinish
        {
            set
            {
                _matchFinish = value;

                if(value == true)
                {
                    _playerUiAction.SetActive(false);
                    StopAllCoroutines();
                }
            }
        }
#endregion

        private void Start()
        {
            _matchFinish = false;

            if(BattleManager.Instance != null)
            {
                _zoriPlayer = Instantiate(BattleManager.Instance.GetZoriPlayer, _zoriPlayerPos.position, _zoriPlayerPos.rotation);
                _zoriEnnemy = Instantiate(BattleManager.Instance.GetZoriEnnemy, _zoriEnnemyPos.position, _zoriEnnemyPos.rotation);
            }
            else
            {
                return;
            }

            _playerUI.Init(_zoriPlayer);
            _ennemyUI.Init(_zoriEnnemy);

            for (int i = 0; i < _zoriPlayer.GetZoriMoves.Count; i++)
            {
                e_ActionSlots action = e_ActionSlots.A;

                switch(i)
                {
                    case 0:
                    action = e_ActionSlots.A;
                    break;
                    case 1:
                    action = e_ActionSlots.B;
                    break;
                    case 2:
                    action = e_ActionSlots.C;
                    break;
                    case 3:
                    action = e_ActionSlots.D;
                    break;
                }

                _buttons[i].GetData.attackName.text = _zoriPlayer.GetZoriMoves[action].name;
            }

            for (int i = 0; i < _buttons.Length; i++)
            {
                e_ActionSlots action = e_ActionSlots.A;

                switch (i)
                {
                    case 0:
                        action = e_ActionSlots.A;
                    break;

                    case 1:
                        action = e_ActionSlots.B;
                    break;

                    case 2:
                        action = e_ActionSlots.C;
                    break;

                    case 3:
                        action = e_ActionSlots.D;
                    break;
                }
            
                _buttons[i].GetData.attackStamina.text = "PP: " + _zoriPlayer.GetZoriMoves[action].GetStamina + '/' + _zoriPlayer.GetZoriMoves[action].GetStaminaQuantity;
            }

            _playerUiAction.SetActive(false);

            SetState(new BeginBattle(this));
        }

        public void OnClickSlotA()
        {
            _choosenAttack = e_ActionSlots.A;

            int staminaUsed = _zoriPlayer.GetZoriMoves[_choosenAttack].GetStaminaUsed;

            _zoriPlayer.GetZoriMoves[_choosenAttack].RemoveStamina(staminaUsed);

            int stamina = _zoriPlayer.GetZoriMoves[_choosenAttack].GetStamina;

            _buttons[0].GetData.attackStamina.text = "PP: " + stamina + '/' + _zoriPlayer.GetZoriMoves[_choosenAttack].GetStaminaQuantity;

            if(stamina <= 0)
            {
                _buttons[0].GetData.background.color = new Color32(183, 183, 183, 255);
                _buttons[0].GetData.self.enabled = false;
            }

            StartCoroutine(State.ChooseAttack());
        }

        public void OnClickSlotB()
        {
            _choosenAttack = e_ActionSlots.B;

            int staminaUsed = _zoriPlayer.GetZoriMoves[_choosenAttack].GetStaminaUsed;

            _zoriPlayer.GetZoriMoves[_choosenAttack].RemoveStamina(staminaUsed);

            int stamina = _zoriPlayer.GetZoriMoves[_choosenAttack].GetStamina;

            _buttons[1].GetData.attackStamina.text = "PP: " + stamina + '/' + _zoriPlayer.GetZoriMoves[_choosenAttack].GetStaminaQuantity;

            if(stamina <= 0)
            {
                _buttons[1].GetData.background.color = new Color32(183, 183, 183, 255);
                _buttons[1].GetData.self.enabled = false;
            }

            StartCoroutine(State.ChooseAttack());
        }

        public void OnClickSlotC()
        {
            _choosenAttack = e_ActionSlots.C;

            int staminaUsed = _zoriPlayer.GetZoriMoves[_choosenAttack].GetStaminaUsed;

            _zoriPlayer.GetZoriMoves[_choosenAttack].RemoveStamina(staminaUsed);

            int stamina = _zoriPlayer.GetZoriMoves[_choosenAttack].GetStamina;

            _buttons[2].GetData.attackStamina.text = "PP: " + stamina + '/' + _zoriPlayer.GetZoriMoves[_choosenAttack].GetStaminaQuantity;

            if(stamina <= 0)
            {
                _buttons[2].GetData.background.color = new Color32(183, 183, 183, 255);
                _buttons[2].GetData.self.enabled = false;
            }

            StartCoroutine(State.ChooseAttack());
        }

        public void OnClickSlotD()
        {
            _choosenAttack = e_ActionSlots.D;

            int staminaUsed = _zoriPlayer.GetZoriMoves[_choosenAttack].GetStaminaUsed;

            _zoriPlayer.GetZoriMoves[_choosenAttack].RemoveStamina(staminaUsed);

            int stamina = _zoriPlayer.GetZoriMoves[_choosenAttack].GetStamina;

            _buttons[3].GetData.attackStamina.text = "PP: " + stamina + '/' + _zoriPlayer.GetZoriMoves[_choosenAttack].GetStaminaQuantity;

            if(stamina <= 0)
            {
                _buttons[3].GetData.background.color = new Color32(183, 183, 183, 255);
                _buttons[3].GetData.self.enabled = false;
            }

            StartCoroutine(State.ChooseAttack());
        }
    }
}