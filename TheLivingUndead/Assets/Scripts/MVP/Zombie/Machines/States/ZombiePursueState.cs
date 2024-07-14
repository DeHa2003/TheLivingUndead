using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePursueState : IZombieState
{
    private IZombieStateSwitcher stateSwitcher;
    private ZombieMoveModel zombieMoveModel;
    private ZombieTargets zombieTargets;
    private Transform currentTarget;

    private IEnumerator findTarget;

    public ZombiePursueState(IZombieStateSwitcher stateSwitcher, ZombieMoveModel zombieMoveModel, ZombieTargets zombieTargets)
    {
        this.stateSwitcher = stateSwitcher;
        this.zombieTargets = zombieTargets;
        this.zombieMoveModel = zombieMoveModel;
    }

    public void EnterState()
    {
        Debug.Log("Активация состояния - PURSUE");
        ActivateFindTarget();
    }

    public void ExitState()
    {
        Debug.Log("Деактивация состояния - PURSUE");
        DeactivateFindTarget();
    }

    public void UpdateState()
    {
        zombieMoveModel.MoveTo(currentTarget.position);
    }

    public void ActivateFindTarget()
    {
        if (findTarget != null)
            Coroutines.StartCoroutine_(findTarget);

        Coroutines.StartCoroutine_(findTarget = FindTarget_Coroutine());
    }

    public void DeactivateFindTarget()
    {
        if (findTarget != null)
            Coroutines.StopCoroutine_(findTarget);
    }

    private IEnumerator FindTarget_Coroutine()
    {
        while (true)
        {

            var zombiePosition = zombieMoveModel.Transform.position;
            currentTarget = zombieTargets.GetNearestTarget(zombiePosition);

            var distance = Vector3.Distance(zombiePosition, currentTarget.position);

            if (distance >= 15)
                ActivateIdleState();

            if (distance < 2)
                ActivateAttack();

            yield return new WaitForSeconds(1);
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
