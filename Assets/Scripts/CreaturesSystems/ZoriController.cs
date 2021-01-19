using UnityEngine;

[RequireComponent(typeof(Zori), typeof(AudioSource))]
public class ZoriController : MonoBehaviour
{
    [SerializeField] private bool m_ownedByPlayer = false;
    [SerializeField] private bool m_isInBattle = false;

    private Zori m_zori = null;
    private AudioSource m_audioSource = null;

    public Zori Zori { get => m_zori; }
    private bool OwnedByPlayer { get => m_ownedByPlayer; set => m_ownedByPlayer = value; }

    private void Start()
    {
        m_zori = GetComponent<Zori>();
        m_audioSource = GetComponent<AudioSource>();

        if(m_isInBattle)
        {
            if(m_ownedByPlayer == true)
            {
                BattleFlowManager.Instance.SetZoriPlayer(this);
            }
            else
            {
                BattleFlowManager.Instance.SetZoriEnnemi(this);
            }

            return;
        }

    }
}