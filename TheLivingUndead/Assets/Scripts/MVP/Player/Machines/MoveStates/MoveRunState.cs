using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRunState : IMoveState
{
    private PlayerMoveModel moveModel;
    private InputData inputData;
    private PlayerMoveStateMachine moveMachine;

    public MoveRunState(PlayerMoveModel moveModel, InputData inputData, PlayerMoveStateMachine playerMoveMachine)
    {
        this.moveModel = moveModel;
        this.inputData = inputData;
        this.moveMachine = playerMoveMachine;
    }

    public void EnterState()
    {
        //Debug.Log("Активация состояния - RUN");

        inputData.OnMove += moveModel.SetMove;
        inputData.OnRotate += moveModel.SetRotate;
        inputData.OnJump += moveModel.SetJump;

        inputData.OnStopRun += ActivateWalkState;

        moveModel.SetMoveType(PlayerMoveType.Run);
        moveModel.SetMoveSpeed(3.2f);
        moveModel.SetRotateSpeed(1f);
    }

    public void ExitState()
    {
        inputData.OnMove -= moveModel.SetMove;
        inputData.OnRotate -= moveModel.SetRotate;
        inputData.OnJump -= moveModel.SetJump;

        inputData.OnStopRun -= ActivateWalkState;

        //Debug.Log("Деактивация состояния - RUN");
    }

    private void ActivateWalkState()
    {
        moveMachine.SetMoveState(moveMachine.GetMoveState<MoveWalkState>());
    }
}
