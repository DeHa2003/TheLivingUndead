using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdleState : IZombieState
{

    private IZombieStateSwitcher stateSwitcher;
    private ZombieTargets zombieTargets;
    private ZombieMoveModel zombieMoveModel;
    private NavMeshPointGenerator pointGenerator;

    private Vector3 randomPoint;

    private IEnumerator findTarget;
    private IEnumerator findRandomMoveTarget;

    public ZombieIdleState(IZombieStateSwitcher zombieStateSwitcher, ZombieMoveModel zombieMoveModel, ZombieTargets zombieTargets)
    {
        this.stateSwitcher = zombieStateSwitcher;
        this.zombieMoveModel = zombieMoveModel;
        this.zombieTargets = zombieTargets;
    }

    public void EnterState()
    {
        Debug.Log("Активация состояния - IDLE");
        ActivateFindTarget();
        ActivateFindRandomMovePoint();
    }

    public void ExitState()
    {
        Debug.Log("Деактивация состояния - IDLE");
        DeactivateFindTarget();
        DeactivateFindRandomMovePoint();
    }

    public void UpdateState()
    {
        zombieMoveModel.MoveTo(randomPoint);
    }

    private void ActivateFindTarget()
    {
        if (findTarget != null)
            Coroutines.StopCoroutine_(findTarget);

        Coroutines.StartCoroutine_(findTarget = FindTarget_Coroutine());
    }

    private void DeactivateFindTarget()
    {
        if(findTarget != null)
           Coroutines.StopCoroutine_(findTarget);
    }

    private void ActivateFindRandomMovePoint()
    {
        if (findRandomMoveTarget != null)
            Coroutines.StopCoroutine_(findRandomMoveTarget);

        Coroutines.StartCoroutine_(findRandomMoveTarget = FindRandonPoint_Coroutine());
    }

    private void DeactivateFindRandomMovePoint()
    {
        if (findRandomMoveTarget != null)
            Coroutines.StopCoroutine_(findRandomMoveTarget);
    }

    private IEnumerator FindTarget_Coroutine()
    {
        while (true)
        {
            var zombiePosition = zombieMoveModel.Transform.position;
            var currentTarget = zombieTargets.GetNearestTarget(zombiePosition);

            if (currentTarget != null)
            {
                var distance = Vector3.Distance(zombiePosition, currentTarget.position);

                if (distance < 100)
                    ActivatePursueState();
            }

            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator FindRandonPoint_Coroutine()
    {
        var distance = Vector3.Distance(zombieMoveModel.Transform.position, randomPoint);

        if(distance < 3)
        {
            randomPoint = pointGenerator.GetRandomPointInRadius(zombieMoveModel.Transform.position, 30);
        }

        yield return new WaitForSeconds(2);
    }

    private void ActivatePursueState()
    {
        stateSwitcher.SetZombieState(stateSwitcher.GetZombieState<ZombiePursueState>());
    }
}
