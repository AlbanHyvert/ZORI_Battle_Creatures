using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] private BattleData _data = null;

    public BattleData Data { get => _data; }

    private Techniques _currentTechniqueA = null;
    private Techniques _currentTechniqueB = null;

    private void Start()
    {
        BattleManager.Instance.SetBattleSystem(this);
    }

    public Techniques GetTechniqueA()
        => _currentTechniqueA;

    public Techniques GetTechniqueB()
        => _currentTechniqueB;

    public void SetTechniqueA(Techniques techniques)
        => _currentTechniqueA = techniques;

    public void SetTechniqueB(Techniques techniques)
        => _currentTechniqueB = techniques;
}