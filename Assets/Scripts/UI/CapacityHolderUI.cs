using UnityEngine;

public class CapacityHolderUI : MonoBehaviour
{
    [SerializeField] private CapacityUI[] _capacitiesUI = null;
    [Space]
    [SerializeField] private BattleFlowManager _battleManager = null;

    private CapacityHolder m_capacityHolder = null;

    public CapacityUI[] CapacitiesUI { get => _capacitiesUI; }

    private void OnEnable()
    {
        if (!_battleManager)
            return;

        m_capacityHolder = _battleManager.ZoriPlayer.Zori.CapacityHolder;

        if (_capacitiesUI.Length < 1)
            return;

        for (int i = 0; i < _capacitiesUI.Length; i++)
        {
            switch (i)
            {
                case 0:
                    _capacitiesUI[i].Init(m_capacityHolder.GetCapacityA(), _battleManager);
                    break;
                case 1:
                    _capacitiesUI[i].Init(m_capacityHolder.GetCapacityB(), _battleManager);
                    break;
                case 2:
                    _capacitiesUI[i].Init(m_capacityHolder.GetCapacityC(), _battleManager);
                    break;
                case 3:
                    _capacitiesUI[i].Init(m_capacityHolder.GetCapacityD(), _battleManager);
                    break;
                default:
                    break;
            }
        }
    }
}
