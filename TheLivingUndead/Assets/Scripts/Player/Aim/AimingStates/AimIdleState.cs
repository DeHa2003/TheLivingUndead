using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimIdleState : AimBaseState
{
    public override void EnterState(AimStateManager aimStateManager)
    {

    }

    public override void UpdateState(AimStateManager aimStateManager)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            aimStateManager.SwitchState(aimStateManager.aimState);
        }
    }
}
