using System.Collections;
using UnityEngine;

public class ZombiePursueState : IZombieState
{
    private IZombieStateSwitcher stateSwitcher;
    private ZombieMoveModel zombieMoveModel;
    private IZombieTargetsReader zombieTargets;
    private ITarget currentTarget;

    private IEnumerator findTarget;

    public ZombiePursueState(IZombieStateSwitcher stateSwitcher, ZombieMoveModel zombieMoveModel, IZombieTargetsReader zombieTargets)
    {
        this.stateSwitcher = stateSwitcher;
        this.zombieTargets = zombieTargets;
        this.zombieMoveModel = zombieMoveModel;
    }

    public void EnterState()
    {
        Debug.Log("Активация состояния - PURSUE");
        ActivateFindTarget();

        zombieMoveModel.SetMoveType(ZombieMoveType.Run);
        zombieMoveModel.SetMoveSpeed(3f);
    }

    public void ExitState()
    {
        Debug.Log("Деактивация состояния - PURSUE");
        DeactivateFindTarget();
    }

    public void UpdateState()
    {
        zombieMoveModel.MoveTo(currentTarget.Transform.position);
    }

    public void ActivateFindTarget()
    {
        Coroutines.StartCoroutine_(findTarget = FindTarget_Coroutine());
    }

    public void DeactivateFindTarget()
    {
        if(findTarget != null)
        Coroutines.StopCoroutine_(findTarget);
    }

    private IEnumerator FindTarget_Coroutine()
    {
        while (true)
        {
            var zombiePosition = zombieMoveModel.Transform.position;

            currentTarget = zombieTargets.GetNearestTarget(zombiePosition);

            if(currentTarget != null)
            {
                var distance = Vector3.Distance(zombiePosition, currentTarget.Transform.position);
                //Debug.Log(distance);

                if (distance > 30)
                    ActivateIdleState();

                if (distance < 1.5f)
                    ActivateAttack();
            }

            yield return new WaitForSeconds(0.3f);
        }
    }

    private void ActivateIdleState()
    {
        stateSwitcher.SetZombieState(stateSwitcher.GetZombieState<ZombieIdleState>());
    }

    private void ActivateAttack()
    {
        stateSwitcher.SetZombieState(stateSwitcher.GetZombieState<ZombieAttackState>());
    }
}
