using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWalkState : IMoveState
{
    private PlayerMoveModel moveModel;
    private InputData inputData;
    private PlayerMoveStateMachine moveMachine;

    public MoveWalkState(PlayerMoveModel moveModel, InputData inputData, PlayerMoveStateMachine playerMoveMachine)
    {
        this.moveModel = moveModel;
        this.inputData = inputData;
        this.moveMachine = playerMoveMachine;
    }

    public void EnterState()
    {
        //Debug.Log("Активация состояния - WALK");

        inputData.OnMove += moveModel.SetMove;
        inputData.OnRotate += moveModel.SetRotate;
        inputData.OnJump += moveModel.SetJump;

        inputData.OnCrouch += ActivateCrouchState;
        inputData.OnStartRun += ActivateRunState;

        moveModel.SetMoveType(PlayerMoveType.Walk);
        moveModel.SetMoveSpeed(1.6f);
        moveModel.SetRotateSpeed(1f);
    }

    public void ExitState()
    {
        inputData.OnMove -= moveModel.SetMove;
        inputData.OnRotate -= moveModel.SetRotate;
        inputData.OnJump -= moveModel.SetJump;

        inputData.OnCrouch -= ActivateCrouchState;
        inputData.OnStartRun -= ActivateRunState;

        //Debug.Log("Деактивация состояния - WALK");
    }

    private void ActivateCrouchState()
    {
        moveMachine.SetMoveState(moveMachine.GetMoveState<MoveCrouchState>());
    }

    private void ActivateRunState()
    {
        moveMachine.SetMoveState(moveMachine.GetMoveState<MoveRunState>());
    }
}
