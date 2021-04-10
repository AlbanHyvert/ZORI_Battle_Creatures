using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangingUI : MonoBehaviour
{
    [SerializeField] private Button _button = null;
    [Space]
    [SerializeField] private TextMeshProUGUI _textName = null;
    [SerializeField] private TextMeshProUGUI _textLevel = null;
    [SerializeField] private TextMeshProUGUI _textType = null;

    private ZoriController m_zori = null;
    private BattleFlowManager m_battleManager = null;

    public void Init(ZoriController zori, BattleFlowManager battleManager)
    {
        m_zori = zori;
        m_battleManager = battleManager;

        _textName.text = m_zori.name;

        //m_zori.onUse += UpdateQuantity;
    }

    public void OnButtonPress()
    {
        // Changing method
        //m_capacity.UseCapacity();
        m_battleManager.SetZoriPlayer(m_zori);
        //m_battleManager.SetPlayerCapacity(m_capacity);
    }


    private void OnDestroy()
    {
        if (!m_zori)
            return;
    }
}