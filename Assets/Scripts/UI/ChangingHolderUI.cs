using UnityEngine;
using UnityEngine.UI;

public class ChangingHolderUI : MonoBehaviour
{
    [SerializeField] private ChangingUI[] _changingsUI = null;
    [Space]
    [SerializeField] private BattleFlowManager _battleManager = null;
    [SerializeField] private ZoriController[] _listZori = null;

    private ZoriController m_changingHolder = null;

    public ChangingUI[] CapacitiesUI { get => _changingsUI; }

    private void OnEnable()
    {
        if (!_battleManager)
            return;

        m_changingHolder = _battleManager.ZoriPlayer;

        if (_listZori.Length < 2)
            return;

        for (int i = 0; i < _listZori.Length; i++)
        {
            _changingsUI[i].Init(_listZori[i], _battleManager);
            if (_listZori[i] == _battleManager.ZoriPlayer)
            {
                _changingsUI[i].transform.GetComponent<Image>().color = Color.green;
                _changingsUI[i].transform.GetComponent<Button>().interactable = false;
            }
            else
            {
                _changingsUI[i].transform.GetComponent<Image>().color = Color.white;
                _changingsUI[i].transform.GetComponent<Button>().interactable = true;
            }
        }
    }
}
