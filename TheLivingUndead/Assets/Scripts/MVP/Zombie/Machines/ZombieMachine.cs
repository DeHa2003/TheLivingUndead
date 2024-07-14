using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieMachine : IZombieStateSwitcher
{
    private Dictionary<Type, IZombieState> states = new Dictionary<Type, IZombieState>();

    private IZombieState currentZombieState;

    private ZombieModel zombieModel;
    private ZombieTargets zombieTargets;
    private Transform currentTarget;
    private IEnumerator findTarget;

    public ZombieMachine(ZombieTargets zombieTargets, ZombieModel zombieModel)
    {
        this.zombieTargets = zombieTargets;
        this.zombieModel = zombieModel;
    }

    public void Initialize()
    {
        InitializeStates();
    }

    public void InitializeStates()
    {
        states[typeof(ZombieIdleState)] = new ZombieIdleState(this, zombieModel.MoveModel, zombieTargets);
        states[typeof(ZombiePursueState)] = new ZombiePursueState(this, zombieModel.MoveModel, zombieTargets);
        states[typeof(ZombieAttackState)] = new ZombieAttackState(this, zombieModel.MoveModel, zombieTargets);
        states[typeof(ZombieDieState)] = new ZombieDieState();

        SetZombieState(GetZombieState<ZombieIdleState>());
    }

    public void SetZombieState(IZombieState zombieState)
    {
        if(currentZombieState == zombieState) return;

        currentZombieState?.ExitState();

        currentZombieState = zombieState;
        currentZombieState.EnterState();
    }

    public void UpdateState()
    {
        currentZombieState?.UpdateState();
    }

    public IZombieState GetZombieState<T>() where T : IZombieState
    {
        return states[typeof(T)];
    }
}

public interface IZombieStateSwitcher
{
    void SetZombieState(IZombieState zombieState);
    IZombieState GetZombieState<T>() where T : IZombieState;
}
