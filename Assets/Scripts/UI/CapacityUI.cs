using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CapacityUI : MonoBehaviour
{
    [SerializeField] private Button _button = null;
    [Space]
    [SerializeField] private TextMeshProUGUI _textName = null;
    [SerializeField] private TextMeshProUGUI _textQuantity = null;
    [SerializeField] private TextMeshProUGUI _textType = null;

    private Capacity m_capacity = null;
    private BattleFlowManager m_battleManager = null;
    private GameObject m_menu = null;

    public void Init(Capacity capacity, BattleFlowManager battleManager)
    {
        m_capacity = capacity;
        m_battleManager = battleManager;

        if(m_capacity.CurrentUse <= 0)
        {
            _button.enabled = false;

            gameObject.SetActive(false);

            return;
        }

        _textName.text = m_capacity.Name;
        _textQuantity.text = m_capacity.CurrentUse.ToString() + "/" + m_capacity.MaxUse.ToString();
        _textType.text = m_capacity.Type.ToString();

        m_capacity.onUse += UpdateQuantity;
    }

    public void OnButtonPress()
    {
        m_capacity.UseCapacity();
        m_battleManager.SetPlayerCapacity(m_capacity);
        this.transform.parent.gameObject.SetActive(false);
        Debug.Log("test");
    }

    private void UpdateQuantity(int value)
    {
        _textQuantity.text = value + "/" + m_capacity.MaxUse.ToString();
    }

    private void OnDestroy()
    {
        if (!m_capacity)
            return;

        m_capacity.onUse -= UpdateQuantity;
    }
}