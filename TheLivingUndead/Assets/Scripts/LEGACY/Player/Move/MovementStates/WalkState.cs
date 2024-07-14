using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : MovementBaseState
{
    public override void EnterState(MovementStateManager movementStateManager)
    {
        movementStateManager.animator.SetBool("Walking", true);
    }

    public override void UpdateState(MovementStateManager movementStateManager)
    {
        if (movementStateManager.Dir.magnitude < 0.1f)
            ExitState(movementStateManager, movementStateManager.idleState);
    }

    void ExitState(MovementStateManager movementStateManager, MovementBaseState movementBaseState)
    {
        movementStateManager.animator.SetBool("Walking", false);
        movementStateManager.SwitchState(movementBaseState);
    }
}
