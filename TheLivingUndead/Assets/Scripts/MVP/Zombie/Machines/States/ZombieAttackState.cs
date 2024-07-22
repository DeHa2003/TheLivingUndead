using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackState : IZombieState
{
    private IZombieStateSwitcher stateSwitcher;
    private ZombieMoveModel zombieMoveModel;
    private ZombieActionModel zombieActionModel;
    private IZombieTargetsReader zombieTargets;
    private ITarget currentTarget;

    private IEnumerator findTarget;
    private IEnumerator activateAttack;
    private bool isAttack;
    public ZombieAttackState(IZombieStateSwitcher stateSwitcher, ZombieMoveModel zombieModel, ZombieActionModel zombieActionModel, IZombieTargetsReader zombieTargets)
    {
        this.stateSwitcher = stateSwitcher;
        this.zombieMoveModel = zombieModel;
        this.zombieTargets = zombieTargets;
        this.zombieActionModel = zombieActionModel;
    }

    public void EnterState()
    {
        Debug.Log("Активация состояния - ATTACK");
        ActivateFindTarget();
        zombieActionModel.OnAttack += Attack;
        zombieActionModel.StartAttack();
    }

    public void ExitState()
    {
        Debug.Log("Деактивация состояния - ATTACK");
        DeactivateFindTarget();
        zombieActionModel.OnAttack -= Attack;
        zombieActionModel.EndAttack();
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

                if (distance >= 1.5f)
                    ActivatePursueState();
            }

            yield return new WaitForSeconds(1);
        }
    }

    private void Attack()
    {
        Debug.Log("Получение урона");
        currentTarget.TakeDamage(10);
    }

    private void ActivatePursueState()
    {
        stateSwitcher.SetZombieState(stateSwitcher.GetZombieState<ZombiePursueState>());
    }
}
