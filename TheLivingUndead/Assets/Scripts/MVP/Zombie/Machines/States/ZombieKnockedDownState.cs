using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieKnockedDownState : IZombieState
{
    private ZombieActionModel zombieActionModel;
    private IZombieStateSwitcher stateSwitcher;

    public ZombieKnockedDownState(IZombieStateSwitcher stateSwitcher, ZombieActionModel zombieActionModel)
    {
        this.stateSwitcher = stateSwitcher;
        this.zombieActionModel = zombieActionModel;
    }

    public void EnterState()
    {
        zombieActionModel.Fall();
        ActivateStartRise();
    }

    public void ExitState()
    {
        
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
