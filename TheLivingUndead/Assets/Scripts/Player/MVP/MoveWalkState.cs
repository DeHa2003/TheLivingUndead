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
        Debug.Log("Активация состояния - WALK");

        inputData.OnMove += moveModel.SetMove;
        inputData.OnRotate += moveModel.SetRotate;
        inputData.OnJump += moveModel.SetJump;

        inputData.OnCrouch += ActivateCrouchState;

        moveModel.SetMoveType(MoveType.Walk);
        moveModel.SetMoveSpeed(1.6f);
        moveModel.SetRotateSpeed(1f);
    }

    public void ExitState()
    {
        inputData.OnMove -= moveModel.SetMove;
        inputData.OnRotate -= moveModel.SetRotate;
        inputData.OnJump -= moveModel.SetJump;

        inputData.OnCrouch -= ActivateCrouchState;

        Debug.Log("Деактивация состояния - WALK");
    }

    private void ActivateCrouchState()
    {
        moveMachine.SetMoveState(moveMachine.GetMoveState<MoveCrouchState>());
    }
}
