using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePresenter
{
    private ZombieModel zombieModel;
    private ZombieView zombieView;

    private ZombieMachine zombieMachine;
    public ZombiePresenter(ZombieModel zombieModel, ZombieView zombieView, ZombieMachine zombieMachine)
    {
        this.zombieModel = zombieModel;
        this.zombieView = zombieView;
        this.zombieMachine = zombieMachine;

        this.zombieModel.MoveModel.SetTransform(zombieView.ZombieTransform);
        this.zombieMachine.Initialize();
        this.zombieView.Initialize();

        ActivateEvents();
    }

    private void ActivateEvents()
    {
        zombieModel.HealthModel.OnDie += Die;

        ActivateMoveEvents();
        ActivateHealthEvents();
        ActivateOthersActionEvents();
    }

    private void DeactivateEvents()
    {
        zombieModel.HealthModel.OnDie -= Die;

        DeactivateMoveEvents();
        DeactivateHealthEvents();
        DeactivateOthersActionEvents();
    }

    private void ActivateMoveEvents()
    {
        zombieModel.MoveModel.OnMoveTo += zombieView.MoveTo;
        zombieModel.MoveModel.OnRotateTo += zombieView.RotateTo;
        zombieModel.MoveModel.OnSetMoveSpeed += zombieView.SetMoveSpeed;
        zombieModel.MoveModel.OnMoveType += zombieView.SetMoveType;
    }

    private void ActivateHealthEvents()
    {
        zombieView.OnTakeDamageEvent += zombieModel.HealthModel.TakeDamage;

        zombieModel.HealthModel.OnChangedHealth += zombieView.ChangeHealth;
    }

    private void ActivateOthersActionEvents()
    {
        zombieView.OnAttackEvent += zombieModel.ActionModel.Attack;
        zombieView.OnRiseEvent += RiseUp;

        zombieModel.ActionModel.OnStartAttack += zombieView.StartAttack;
        zombieModel.ActionModel.OnEndAttack += zombieView.EndAttack;
        zombieModel.ActionModel.OnFall += zombieView.Fall;
        zombieModel.ActionModel.OnStartRise += zombieView.StartRise;
    }


    private void DeactivateMoveEvents()
    {
        zombieModel.MoveModel.OnMoveTo -= zombieView.MoveTo;
        zombieModel.MoveModel.OnRotateTo -= zombieView.RotateTo;
        zombieModel.MoveModel.OnSetMoveSpeed -= zombieView.SetMoveSpeed;
        zombieModel.MoveModel.OnMoveType -= zombieView.SetMoveType;
    }

    private void DeactivateHealthEvents()
    {
        zombieView.OnTakeDamageEvent -= zombieModel.HealthModel.TakeDamage;
        zombieModel.HealthModel.OnChangedHealth -= zombieView.ChangeHealth;
    }

    private void DeactivateOthersActionEvents()
    {
        zombieView.OnAttackEvent -= zombieModel.ActionModel.Attack;
        zombieView.OnRiseEvent -= RiseUp;


        zombieModel.ActionModel.OnStartAttack -= zombieView.StartAttack;
        zombieModel.ActionModel.OnEndAttack -= zombieView.EndAttack;
        zombieModel.ActionModel.OnFall -= zombieView.Fall;
        zombieModel.ActionModel.OnStartRise -= zombieView.StartRise;
    }

    public void Update()
    {
        zombieMachine.UpdateState();
    }


    private void RiseUp()
    {
        zombieMachine.SetZombieState(zombieMachine.GetZombieState<ZombieIdleState>());
    }

    private void Die()
    {
        zombieMachine.SetZombieState(zombieMachine.GetZombieState<ZombieDieState>());
        zombieView.Destroy();
        DeactivateEvents();
    }
}
