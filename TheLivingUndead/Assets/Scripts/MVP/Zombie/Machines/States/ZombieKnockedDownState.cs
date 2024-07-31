using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieKnockedDownState : IZombieState
{
    private ZombieActionModel zombieActionModel;
    private ZombieMoveModel moveModel;

    public ZombieKnockedDownState(ZombieActionModel zombieActionModel, ZombieMoveModel moveModel)
    {
        this.zombieActionModel = zombieActionModel;
        this.moveModel = moveModel;
    }

    public void EnterState()
    {
        Debug.Log("Активация состояния - KNOCKED DOWN");

        moveModel.SetMoveSpeed(0);
        zombieActionModel.Fall();
        ActivateStartRise();
    }

    public void ExitState()
    {
        Debug.Log("Деактивация состояния - KNOCKED DOWN");
    }

    public void UpdateState()
    {

    }

    private void ActivateStartRise()
    {
        Coroutines.StartCoroutine_(TimeToStartRise_Coroutine(5));
    }

    private IEnumerator TimeToStartRise_Coroutine(float time)
    {
        yield return new WaitForSeconds(time);
        zombieActionModel.StartRise();
    }

}
