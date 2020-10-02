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
        private e_HealthStatus _oldPlayerStatus = e_HealthStatus.HEALTHY;
        private e_HealthStatus _oldEnnemyStatus = e_HealthStatus.HEALTHY;

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

            _zoriPlayer.UpdateStatus += UpdatePlayerStatus;
            _zoriEnnemy.UpdateStatus += UpdateEnnemyStatus;

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
    
        private void UpdatePlayerStatus(e_HealthStatus nextStatus)
        {
            switch (_oldPlayerStatus)
            {
                case e_HealthStatus.SLEEPING:
                    _playerUI.GetDescription.text = _zoriPlayer.GetData.nickName + " is waking up !";
                    _oldPlayerStatus = nextStatus;
                break;

                case e_HealthStatus.PARALAZED:
                    _playerUI.GetDescription.text = _zoriPlayer.GetData.nickName + " isn't paralysed anymore !";
                    _oldPlayerStatus = nextStatus;
                break;

                case e_HealthStatus.POISONING:
                    _playerUI.GetDescription.text = _zoriPlayer.GetData.nickName + " is not poisoned anymore !";
                    _oldPlayerStatus = nextStatus;
                break;

                case e_HealthStatus.BURNING:
                    _playerUI.GetDescription.text = _zoriPlayer.GetData.nickName + " is not burning anymore !";
                    _oldPlayerStatus = nextStatus;
                break;

                case e_HealthStatus.FREEZING:
                    _playerUI.GetDescription.text = _zoriPlayer.GetData.nickName + " is not frozen anymore !";
                    _oldPlayerStatus = nextStatus;
                break;

                case e_HealthStatus.HEALTHY:
                    switch (nextStatus)
                    {
                        case e_HealthStatus.SLEEPING:
                            _playerUI.GetDescription.text = _zoriPlayer.GetData.nickName + " is now sleeping !";
                            _oldPlayerStatus = nextStatus;
                        break;

                        case e_HealthStatus.PARALAZED:
                            _playerUI.GetDescription.text = _zoriPlayer.GetData.nickName + " is now paralysed !";
                            _oldPlayerStatus = nextStatus;
                        break;

                        case e_HealthStatus.POISONING:
                            _playerUI.GetDescription.text = _zoriPlayer.GetData.nickName + " is now poisoned !";
                            _oldPlayerStatus = nextStatus;
                        break;

                        case e_HealthStatus.BURNING:
                            _playerUI.GetDescription.text = _zoriPlayer.GetData.nickName + " is now burning !";
                            _oldPlayerStatus = nextStatus;
                        break;

                        case e_HealthStatus.FREEZING:
                            _playerUI.GetDescription.text = _zoriPlayer.GetData.nickName + " is now frozen anymore !";
                            _oldPlayerStatus = nextStatus;
                        break;
                    }
                break;
            }
        }

        private void UpdateEnnemyStatus(e_HealthStatus nextStatus)
        {
            switch (_oldPlayerStatus)
            {
                case e_HealthStatus.SLEEPING:
                    _ennemyUI.GetDescription.text = _zoriEnnemy.GetData.nickName + " is waking up !";
                    _oldEnnemyStatus = nextStatus;
                break;

                case e_HealthStatus.PARALAZED:
                    _ennemyUI.GetDescription.text = _zoriEnnemy.GetData.nickName + " isn't paralysed anymore !";
                    _oldEnnemyStatus = nextStatus;
                break;

                case e_HealthStatus.POISONING:
                    _ennemyUI.GetDescription.text = _zoriEnnemy.GetData.nickName + " is not poisoned anymore !";
                    _oldEnnemyStatus = nextStatus;
                break;

                case e_HealthStatus.BURNING:
                    _ennemyUI.GetDescription.text = _zoriEnnemy.GetData.nickName + " is not burning anymore !";
                    _oldEnnemyStatus = nextStatus;
                break;

                case e_HealthStatus.FREEZING:
                    _ennemyUI.GetDescription.text = _zoriEnnemy.GetData.nickName + " is not frozen anymore !";
                    _oldEnnemyStatus = nextStatus;
                break;

                case e_HealthStatus.HEALTHY:
                    switch (nextStatus)
                    {
                        case e_HealthStatus.SLEEPING:
                            _ennemyUI.GetDescription.text = _zoriEnnemy.GetData.nickName + " is now sleeping !";
                            _oldEnnemyStatus = nextStatus;
                        break;

                        case e_HealthStatus.PARALAZED:
                            _ennemyUI.GetDescription.text = _zoriEnnemy.GetData.nickName + " is now paralysed !";
                            _oldEnnemyStatus = nextStatus;
                        break;

                        case e_HealthStatus.POISONING:
                            _ennemyUI.GetDescription.text = _zoriEnnemy.GetData.nickName + " is now poisoned !";
                            _oldEnnemyStatus = nextStatus;
                        break;

                        case e_HealthStatus.BURNING:
                            _ennemyUI.GetDescription.text = _zoriEnnemy.GetData.nickName + " is now burning !";
                            _oldEnnemyStatus = nextStatus;
                        break;

                        case e_HealthStatus.FREEZING:
                            _ennemyUI.GetDescription.text = _zoriEnnemy.GetData.nickName + " is now frozen anymore !";
                            _oldEnnemyStatus = nextStatus;
                        break;
                    }
                break;
            }
        }
    }
}