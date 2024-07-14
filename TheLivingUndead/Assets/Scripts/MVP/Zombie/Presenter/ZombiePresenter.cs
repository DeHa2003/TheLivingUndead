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

        ActivateEvents();
    }

    private void ActivateEvents()
    {
        zombieModel.MoveModel.OnMoveTo += zombieView.MoveTo;
        zombieModel.MoveModel.OnRotateTo += zombieView.RotateTo;
        zombieModel.MoveModel.OnSetMoveSpeed += zombieView.SetMoveSpeed;
    }

    private void DeactivateEvents()
    {
        zombieModel.MoveModel.OnMoveTo -= zombieView.MoveTo;
        zombieModel.MoveModel.OnRotateTo -= zombieView.RotateTo;
        zombieModel.MoveModel.OnSetMoveSpeed -= zombieView.SetMoveSpeed;
    }

    public void Update()
    {
        zombieMachine.UpdateState();
    }
}
