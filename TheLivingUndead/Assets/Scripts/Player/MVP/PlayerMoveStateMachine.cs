using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveStateMachine
{
    private Dictionary<Type, IMoveState> moveStates = new Dictionary<Type, IMoveState>();

    private PlayerMoveModel moveModel;
    private InputData inputData;
    private IMoveState currentMoveState;

    public PlayerMoveStateMachine(PlayerMoveModel moveModel, InputData inputData)
    {
        this.moveModel = moveModel;
        this.inputData = inputData;
    }

    public void Initialize()
    {
        moveStates[typeof(MoveWalkState)] = new MoveWalkState(moveModel, inputData, this);
        moveStates[typeof(MoveCrouchState)] = new MoveCrouchState(moveModel, inputData, this);

        SetMoveState(GetMoveState<MoveCrouchState>());
    }

    public void SetMoveState(IMoveState moveState)
    {
        currentMoveState?.ExitState();

        currentMoveState = moveState;
        currentMoveState.EnterState();
    }

    public IMoveState GetMoveState<T>() where T : IMoveState
    {
        return moveStates[typeof(T)];
    }
}
