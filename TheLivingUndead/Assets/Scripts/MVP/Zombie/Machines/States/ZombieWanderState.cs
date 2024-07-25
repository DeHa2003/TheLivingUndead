using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWanderState : IZombieState
{
    private IZombieStateSwitcher stateSwitcher;
    private ZombieMoveModel zombieMoveModel;
    private IZombieTargetsReader zombieTargets;

    private NavMeshPointGenerator pointGenerator;

    private ITarget currentTarget;
    private Vector3 randomPos;

    private IEnumerator wander;
    private IEnumerator findTarget;

    public ZombieWanderState(IZombieStateSwitcher stateSwitcher, ZombieMoveModel zombieMoveModel, IZombieTargetsReader zombieTargets, NavMeshPointGenerator pointGenerator)
    {
        this.stateSwitcher = stateSwitcher;
        this.zombieMoveModel = zombieMoveModel;
        this.zombieTargets = zombieTargets;
        this.pointGenerator = pointGenerator;
    }

    public void EnterState()
    {
        Debug.Log("Активация состояния - WANDER");
        ActivateFindTarget();
        ActivateWander();

        zombieMoveModel.SetMoveType(ZombieMoveType.Walk);
        zombieMoveModel.SetMoveSpeed(0.2f);
    }

    public void ExitState()
    {
        Debug.Log("Деактивация состояния - WANDER");
        DeactivateFindTarget();
        DeactivateWander();
    }

    public void UpdateState()
    {
        zombieMoveModel.MoveTo(randomPos);
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

    private void ActivateWander()
    {
        Coroutines.StartCoroutine_(wander = Wander_Coroutine());
    }

    private void DeactivateWander()
    {
        if(wander != null)
        Coroutines.StopCoroutine_(wander);
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

                if (distance <= 30)
                    ActivatePursueState();
            }

            yield return new WaitForSeconds(0.3f);
        }
    }

    private IEnumerator Wander_Coroutine()
    {
        randomPos = pointGenerator.GetRandomPointInRadius(zombieMoveModel.Transform.position, 40);

        while (true)
        {
            float distance = Vector3.Distance(randomPos, zombieMoveModel.Transform.position);

            if(distance < 2)
            {
                bool should = Random.value > 0.3f;

                if (should)
                {
                    Debug.Log("Выбор пал на переход в IDLE");
                    ActivateIdleState();
                }
                else
                {
                    Debug.Log("Выбор рандомной точки");
                    randomPos = pointGenerator.GetRandomPointInRadius(zombieMoveModel.Transform.position, 40);
                }
            }

            yield return new WaitForSeconds(0.3f);
        }
    }

    private void ActivateIdleState()
    {
        stateSwitcher.SetZombieState(stateSwitcher.GetZombieState<ZombieIdleState>());
    }

    private void ActivatePursueState()
    {
        stateSwitcher.SetZombieState(stateSwitcher.GetZombieState<ZombiePursueState>());
    }
}
