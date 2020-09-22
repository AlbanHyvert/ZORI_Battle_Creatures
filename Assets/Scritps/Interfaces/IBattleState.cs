using UnityEngine;

public interface IBattleState
{
    void Init(IAController controller);

    void Enter();
    void Tick();
    void Exit();
}