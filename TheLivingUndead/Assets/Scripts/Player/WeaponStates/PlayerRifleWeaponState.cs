using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRifleWeaponState : IWeaponState
{

    private PlayerWeaponModel playerWeaponModel;
    private InputData inputData;

    public PlayerRifleWeaponState(PlayerWeaponModel playerWeaponModel, InputData inputData)
    {
        this.playerWeaponModel = playerWeaponModel;
        this.inputData = inputData;
    }
    public void EnterState()
    {

    }

    public void ExitState()
    {

    }

    public void SetWeapon(WeaponData weapon)
    {

    }

    public void UpdateState()
    {

    }
}
