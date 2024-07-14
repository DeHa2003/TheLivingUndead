using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackState : MonoBehaviour, IZombieState
{
    private IZombieStateSwitcher stateSwitcher;
    private ZombieMoveModel zombieMoveModel;
    private ZombieTargets zombieTargets;
    private Transform currentTarget;

    private IEnumerator findTarget;

    public ZombieAttackState(IZombieStateSwitcher stateSwitcher, ZombieMoveModel zombieModel, ZombieTargets zombieTargets)
    {
        this.stateSwitcher = stateSwitcher;
        this.zombieMoveModel = zombieModel;
        this.zombieTargets = zombieTargets;
    }

    public void EnterState()
    {
        Debug.Log("Активация состояния - ATTACK");
        ActivateFindTarget();
    }

    public void ExitState()
    {
        Debug.Log("Деактивация состояния - ATTACK");
        DeactivateFindTarget();
    }

    public void UpdateState()
    {

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

            if (distance >= 2)
                ActivatePursueState();

            yield return new WaitForSeconds(1);
        }
    }

    private void ActivatePursueState()
    {
        stateSwitcher.SetZombieState(stateSwitcher.GetZombieState<ZombiePursueState>());
    }
}
