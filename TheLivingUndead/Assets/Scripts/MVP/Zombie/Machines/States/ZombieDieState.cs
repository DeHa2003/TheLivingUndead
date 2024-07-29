using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDieState : IZombieState
{
    private ZombieMoveModel zombieMoveModel;

    public ZombieDieState(ZombieMoveModel zombieMoveModel)
    {
        this.zombieMoveModel = zombieMoveModel;
    }

    public void EnterState()
    {
        zombieMoveModel.SetMoveSpeed(0);
    }

    public void ExitState()
    {

    }

    public void UpdateState()
    {

    }
}
