using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCrouchState : IMoveState
{
    private PlayerMoveModel moveModel;
    private InputData inputData;
    private PlayerMoveStateMachine moveMachine;

    public MoveCrouchState(PlayerMoveModel moveModel, InputData inputData, PlayerMoveStateMachine playerMoveMachine)
    {
        this.moveModel = moveModel;
        this.inputData = inputData;
        this.moveMachine = playerMoveMachine;
    }

    public void EnterState()
    {
        Debug.Log("Активация состояния - CROUCH");

        inputData.OnMove += moveModel.SetMove;
        inputData.OnRotate += moveModel.SetRotate;
        inputData.OnJump += moveModel.SetJump;

        inputData.OnCrouch += ActivateWalkState;

        moveModel.SetMoveType(MoveType.Crouch);
        moveModel.SetMoveSpeed(1f);
        moveModel.SetRotateSpeed(1f);
    }

    public void ExitState()
    {
        inputData.OnMove -= moveModel.SetMove;
        inputData.OnRotate -= moveModel.SetRotate;
        inputData.OnJump -= moveModel.SetJump;

        inputData.OnCrouch -= ActivateWalkState;

        Debug.Log("Деактивация состояния - CROUCH");
    }

    private void ActivateWalkState()
    {
        moveMachine.SetMoveState(moveMachine.GetMoveState<MoveWalkState>());
    }
}
