using UnityEngine;

public class CapacityHolder : MonoBehaviour
{
    [SerializeField] private Capacity m_capacityA = null;
    [SerializeField] private Capacity m_capacityB = null;
    [SerializeField] private Capacity m_capacityC = null;
    [SerializeField] private Capacity m_capacityD = null;

    public Capacity GetCapacityA()
        => m_capacityA;

    public Capacity GetCapacityB()
        => m_capacityB;

    public Capacity GetCapacityC()
        => m_capacityC;

    public Capacity GetCapacityD()
        => m_capacityD;

    public int GetCapacitySize { get; private set; }

    public void Init()
    {
        GetCapacitySize = 0;
        
        if(m_capacityA != null)
        {
            m_capacityA.Init();
            GetCapacitySize++;
        }
        if (m_capacityB != null)
        {
            m_capacityB.Init();
            GetCapacitySize++;
        }
        if (m_capacityC != null)
        {
            m_capacityC.Init();
            GetCapacitySize++;
        }
        if (m_capacityD != null)
        {
            m_capacityD.Init();
            GetCapacitySize++;
        }
    }

    public void SetNewCapacity(int position = 0, Capacity capacity = null)
    {
        switch (position)
        {
            case 0:
                m_capacityA = capacity;
                break;
            case 1:
                m_capacityB = capacity;
                break;
            case 2:
                m_capacityC = capacity;
                break;
            case 3:
                m_capacityD = capacity;
                break;
            default:
                Debug.Log("Missing capacity reference.");
                break;
        }
    }
}