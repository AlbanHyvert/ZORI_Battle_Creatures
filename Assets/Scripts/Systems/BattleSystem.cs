using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] private BattleData _data = null;

    public BattleData Data { get => _data; }

    private void Start()
    {
        BattleManager.Instance.SetBattleSystem(this);
    }
}