using UnityEngine;

public class ChangingHolderUI : MonoBehaviour
{
    [SerializeField] private ChangingUI[] _changingsUI = null;
    [Space]
    [SerializeField] private BattleFlowManager _battleManager = null;

    private ZoriController m_changingHolder = null;

    public ChangingUI[] CapacitiesUI { get => _changingsUI; }

    private void OnEnable()
    {
        if (!_battleManager)
            return;

        m_changingHolder = _battleManager.ZoriPlayer;

        if (_changingsUI.Length < 1)
            return;

        for (int i = 0; i < _changingsUI.Length; i++)
        {
            switch (i)
            {
                case 0:
                    _changingsUI[i].Init(m_changingHolder, _battleManager);
                    break;
                case 1:
                    _changingsUI[i].Init(m_changingHolder, _battleManager);
                    break;
                case 2:
                    _changingsUI[i].Init(m_changingHolder, _battleManager);
                    break;
                case 3:
                    _changingsUI[i].Init(m_changingHolder, _battleManager);
                    break;
                case 4:
                    _changingsUI[i].Init(m_changingHolder, _battleManager);
                    break;
                case 5:
                    _changingsUI[i].Init(m_changingHolder, _battleManager);
                    break;
                default:
                    break;
            }
        }
    }
}
