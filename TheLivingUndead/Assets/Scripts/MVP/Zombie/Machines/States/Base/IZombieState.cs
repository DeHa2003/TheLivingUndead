using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IZombieState
{
    void EnterState();
    void ExitState();
    void UpdateState();
}
