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
        zombieModel.HealthModel.OnDie += ActivateDieState;

        ActivateViewSignals();
        ActivateMoveEvents();
        ActivateHealthEvents();
        ActivateOthersActionEvents();
    }

    private void DeactivateEvents()
    {
        zombieModel.HealthModel.OnDie -= ActivateDieState;

        DeactivateViewSignals();
        DeactivateMoveEvents();
        DeactivateHealthEvents();
        DeactivateOthersActionEvents();
    }

    #region ViewSignals

    public void ActivateViewSignals()
    {
        zombieView.OnAttackEvent += zombieModel.ActionModel.Attack;
        zombieView.OnFootstepEvent += zombieModel.ActionModel.Footstep;
        zombieView.OnRiseUpEndEvent += zombieModel.ActionModel.EndRise;
        zombieView.OnTakeDamageEvent += zombieModel.HealthModel.TakeDamage;
        zombieView.OnChanceFall += ActivateKnockedDownState;
    }

    public void DeactivateViewSignals()
    {
        zombieView.OnAttackEvent -= zombieModel.ActionModel.Attack;
        zombieView.OnFootstepEvent -= zombieModel.ActionModel.Footstep;
        zombieView.OnRiseUpEndEvent -= zombieModel.ActionModel.EndRise;
        zombieView.OnTakeDamageEvent -= zombieModel.HealthModel.TakeDamage;
        zombieView.OnChanceFall += ActivateKnockedDownState;
    }

    #endregion

    #region Move

    private void ActivateMoveEvents()
    {
        zombieModel.MoveModel.OnMoveTo += zombieView.MoveTo;
        zombieModel.MoveModel.OnRotateTo += zombieView.RotateTo;
        zombieModel.MoveModel.OnSetMoveSpeed += zombieView.SetMoveSpeed;
        zombieModel.MoveModel.OnMoveType += zombieView.SetMoveType;
    }

    private void DeactivateMoveEvents()
    {
        zombieModel.MoveModel.OnMoveTo -= zombieView.MoveTo;
        zombieModel.MoveModel.OnRotateTo -= zombieView.RotateTo;
        zombieModel.MoveModel.OnSetMoveSpeed -= zombieView.SetMoveSpeed;
        zombieModel.MoveModel.OnMoveType -= zombieView.SetMoveType;
    }

    #endregion

    #region Health

    private void ActivateHealthEvents()
    {
        zombieModel.HealthModel.OnChangedHealth += zombieView.ChangeHealth;
    }

    private void DeactivateHealthEvents()
    {
        zombieModel.HealthModel.OnChangedHealth -= zombieView.ChangeHealth;
    }

    #endregion

    #region OthersActions

    private void ActivateOthersActionEvents()
    {
        zombieModel.ActionModel.OnStartAttack += zombieView.StartAttack;
        zombieModel.ActionModel.OnEndAttack += zombieView.EndAttack;
        zombieModel.ActionModel.OnFall += zombieView.Fall;
        zombieModel.ActionModel.OnStartRise += zombieView.StartRise;

        zombieModel.ActionModel.OnEndRise += ActivateIdleState;
    }

    private void DeactivateOthersActionEvents()
    {
        zombieModel.ActionModel.OnStartAttack -= zombieView.StartAttack;
        zombieModel.ActionModel.OnEndAttack -= zombieView.EndAttack;
        zombieModel.ActionModel.OnFall -= zombieView.Fall;
        zombieModel.ActionModel.OnStartRise -= zombieView.StartRise;

        zombieModel.ActionModel.OnEndRise -= ActivateIdleState;
    }

    #endregion

    public void Update()
    {
        zombieMachine.UpdateState();
    }

    private void ActivateKnockedDownState(float chance)
    {
        float random = Random.Range(0, 100);

        Debug.Log("Шанс активации падения - " + chance);

        if(random < chance)
        {
            zombieMachine.SetZombieState(zombieMachine.GetZombieState<ZombieKnockedDownState>());
        }
    }


    private void ActivateIdleState()
    {
        zombieMachine.SetZombieState(zombieMachine.GetZombieState<ZombiePursueState>());
    }

    private void ActivateDieState()
    {
        zombieMachine.SetZombieState(zombieMachine.GetZombieState<ZombieDieState>());
        zombieView.Destroy();
        DeactivateEvents();
    }
}
