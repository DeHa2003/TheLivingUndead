using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMachine : IZombieStateSwitcher
{
    private Dictionary<Type, IZombieState> states = new Dictionary<Type, IZombieState>();

    private IZombieState currentZombieState;

    private ZombieModel zombieModel;
    private IZombieTargetsReader zombieTargets;
    private NavMeshPointGenerator pointGenerator;

    public ZombieMachine(IZombieTargetsReader zombieTargets, ZombieModel zombieModel, NavMeshPointGenerator pointGenerator)
    {
        this.zombieTargets = zombieTargets;
        this.zombieModel = zombieModel;
        this.pointGenerator = pointGenerator;
    }

    public void Initialize()
    {
        InitializeStates();
    }

    public void InitializeStates() 
    {
        states[typeof(ZombieIdleState)] = new ZombieIdleState(this, zombieModel.MoveModel, zombieTargets);
        states[typeof(ZombieWanderState)] = new ZombieWanderState(this, zombieModel.MoveModel, zombieTargets, pointGenerator);
        states[typeof(ZombiePursueState)] = new ZombiePursueState(this, zombieModel.MoveModel, zombieTargets);
        states[typeof(ZombieAttackState)] = new ZombieAttackState(this, zombieModel.MoveModel, zombieModel.ActionModel, zombieTargets);
        states[typeof(ZombieDieState)] = new ZombieDieState();

        SetZombieState(GetZombieState<ZombieIdleState>());
    }

    public void SetZombieState(IZombieState zombieState)
    {
        //if (currentZombieState == zombieState) return;
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
