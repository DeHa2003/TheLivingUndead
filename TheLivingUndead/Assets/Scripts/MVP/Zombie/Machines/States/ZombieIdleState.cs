using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdleState : IZombieState
{
    private IZombieStateSwitcher stateSwitcher;
    private ZombieMoveModel zombieMoveModel;
    private IZombieTargetsReader zombieTargets;
    private ITarget currentTarget;

    private IEnumerator findTarget;
    private IEnumerator activateWander;

    public ZombieIdleState(IZombieStateSwitcher stateSwitcher, ZombieMoveModel zombieModel, IZombieTargetsReader zombieTargets)
    {
        this.stateSwitcher = stateSwitcher;
        this.zombieMoveModel = zombieModel;
        this.zombieTargets = zombieTargets;
    }

    public void EnterState()
    {
        Debug.Log("Активация состояния - IDLE");
        ActivateFindTarget();
        ActivateCoroutineToWander();

        zombieMoveModel.SetMoveSpeed(0);
    }

    public void ExitState()
    {
        Debug.Log("Деактивация состояния - IDLE");
        DeactivateFindTarget();
        DeactivateCoroutineToWander();
    }

    public void UpdateState()
    {

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

    private void ActivateCoroutineToWander()
    {
        float random = Random.Range(2, 10);
        Coroutines.StartCoroutine_(activateWander = ActivateWander(random));
    }

    private void DeactivateCoroutineToWander()
    {
        if(activateWander != null)
        Coroutines.StopCoroutine_(activateWander);
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

    private IEnumerator ActivateWander(float time)
    {
        yield return new WaitForSeconds(time);
        ActivateWanderState();

    }

    private void ActivateWanderState()
    {
        stateSwitcher.SetZombieState(stateSwitcher.GetZombieState<ZombieWanderState>());
    }

    private void ActivatePursueState()
    {
        stateSwitcher.SetZombieState(stateSwitcher.GetZombieState<ZombiePursueState>());
    }
}
