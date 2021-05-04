using UnityEngine;

public class BeastBonusEffects : MonoBehaviour
{
    public float speedBonus { get; private set; }
    public float atkBonus { get; private set; }
    public float defBonus { get; private set; }
    public float speAtkBonus { get; private set; }
    public float speDefBonus { get; private set; }

    public void Reset()
    {
        SetAtkBonus = 1;
        SetDefBonus = 1;
        SetSpeAtkBonus = 1;
        SetSpeDefBonus = 1;
        SetSpeedBonus = 1;
    }

    public float SetSpeedBonus
    {
        set
        {
            if (value < 1)
                speedBonus = 1;
            else
                speedBonus = value;
        }
    }

    public float SetAtkBonus
    {
        set
        {
            if (value < 1)
                atkBonus = 1;
            else
                atkBonus = value;
        }
    }

    public float SetDefBonus
    {
        set
        {
            if (value < 1)
                defBonus = 1;
            else
                defBonus = value;
        }
    }

    public float SetSpeAtkBonus
    {
        set
        {
            if (value < 1)
                speAtkBonus = 1;
            else
                speAtkBonus = value;
        }
    }

    public float SetSpeDefBonus
    {
        set
        {
            if (value < 1)
                speDefBonus = 1;
            else
                speDefBonus = value;
        }
    }
}