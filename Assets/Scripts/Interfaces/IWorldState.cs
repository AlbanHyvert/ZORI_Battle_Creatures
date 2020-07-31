using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWorldState
{
    void Init(IAController controller);
    void Enter();
    void Tick();
    void Exit();
}