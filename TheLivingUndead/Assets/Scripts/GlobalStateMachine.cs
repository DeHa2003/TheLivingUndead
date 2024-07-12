using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStateMachine : MonoBehaviour
{
    private Dictionary<Type, IGlobalState> states = new Dictionary<Type, IGlobalState>();

    private IGlobalState currentState;

    private void Start()
    {
        SetState(GetGlobalState<GlobalDefaultState>());
    }

    public IGlobalState GetGlobalState<T>() where T : IGlobalState
    {
        return states[typeof(T)];
    }

    public void SetState(IGlobalState state)
    {
        if(currentState == state) return;

        currentState?.ExitState();
        currentState = state;
        currentState.EnterState();
    }

    private void Update()
    {
        currentState?.UpdateState();
    }
}

public interface IGlobalState
{
    void EnterState();
    void ExitState();
    void UpdateState();
}
