using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoneWeaponState : IWeaponState
{

    public WeaponData weapon;
    private PlayerWeaponModel playerWeaponModel;
    private InputData inputData;

    public PlayerNoneWeaponState(PlayerWeaponModel playerModel, InputData inputData)
    {
        this.playerWeaponModel = playerModel;
        this.inputData = inputData;
    }

    public void EnterState()
    {

    }

    public void ExitState()
    {

    }

    public void UpdateState()
    {
        //if (Input.GetMouseButtonDown(1))
        //{
        //    pistol.ActivateAim();
        //    isActive = true;
        //}

        //if (Input.GetMouseButtonUp(1))
        //{
        //    pistol.DeactivateShoot();
        //    pistol.DeactivateAim();
        //    isActive = false;
        //}

        //if (isActive)
        //{
        //    if (Input.GetMouseButtonDown(0)) ;
        //    pistol.ActivateShoot();

        //    if (Input.GetMouseButtonUp(0)) ;
        //    pistol.DeactivateShoot();
        //}
    }

    public void SetWeapon(WeaponData weapon)
    {

    }

    public bool IsAiming()
    {
        return false;
    }
}
