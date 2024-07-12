using System.Collections;
using UnityEngine;

public class AimState : AimBaseState
{

    public override void EnterState(AimStateManager aimStateManager)
    {
        aimStateManager.Animator.SetBool("Aiming", true);
        aimStateManager.StartCoroutine(SmoothVal(0, 1, 0.3f, aimStateManager));
    }

    public override void UpdateState(AimStateManager aimStateManager)
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ExitState(aimStateManager, aimStateManager.idleState);
        }
    }

    private void ExitState(AimStateManager aimStateManager, AimBaseState state)
    {
        aimStateManager.Animator.SetBool("Aiming", false);
        aimStateManager.SwitchState(state);

        aimStateManager.StartCoroutine(SmoothVal(1, 0, 0.3f, aimStateManager));
    }

    private IEnumerator SmoothVal(float from, float to, float duration, AimStateManager aimStateManager)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float currentWeight = Mathf.Lerp(from, to, elapsed / duration);
            aimStateManager.aimConstraintRHand.weight = currentWeight;
            aimStateManager.twoBoneIKConstraintLHand.weight = currentWeight;
            elapsed += Time.deltaTime;
            yield return null;
        }

        aimStateManager.aimConstraintRHand.weight = to;
        aimStateManager.twoBoneIKConstraintLHand.weight = to;
    }
}
