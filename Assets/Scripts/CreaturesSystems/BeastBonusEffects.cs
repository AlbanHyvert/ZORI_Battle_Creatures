using UnityEngine;

public class BeastBonusEffects : MonoBehaviour
{

    [SerializeField]  private float m_speedBonus = 1f;
    [SerializeField] private float m_atkBonus = 1f;
    [SerializeField] private float m_defBonus = 1f;
    [SerializeField] private float m_speAtkBonus = 1f;
    [SerializeField] private float m_speDefBonus = 1f;

    public float speedBonus { get => m_speedBonus;private set => m_speedBonus = value; }
    public float atkBonus { get => m_atkBonus;private set => m_atkBonus = value; }
    public float defBonus { get => m_defBonus;private set => m_defBonus = value; }
    public float speAtkBonus { get => m_speAtkBonus; private set => m_speAtkBonus = value; }
    public float speDefBonus { get => m_speDefBonus; private set => m_speDefBonus = value; }

    public void Reset()
    {
        SetAtkBonus(1);
        SetDefBonus(1);
        SetSpeAtkBonus(1);
        SetSpeDefBonus(1);
        SetSpeedBonus(1);
    }

    public float SetSpeedBonus(float value)
    {
        if (value < 0)
            speedBonus = 0;
        else
            speedBonus = value;

        return speedBonus;
    }

    public float SetAtkBonus(float value)
    {
        if (value < 0)
            atkBonus = 0;
        else
            atkBonus = value;

        return atkBonus;
    }

    public float SetDefBonus(float value)
    {
        if (value < 0)
            defBonus = 0;
        else
            defBonus = value;

        return defBonus;
    }

    public float SetSpeAtkBonus(float value)
    {
        if (value < 0)
            speAtkBonus = 0;
        else
            speAtkBonus = value;

        return speAtkBonus;
    }

    public float SetSpeDefBonus(float value)
    {
        if (value < 0)
            speDefBonus = 0;
        else
            speDefBonus = value;

        return speDefBonus;
    }
}