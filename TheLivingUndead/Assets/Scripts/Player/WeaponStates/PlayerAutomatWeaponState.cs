using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutomatWeaponState : IWeaponState
{
    private PlayerWeaponModel playerWeaponModel;
    private WeaponData weaponData;
    private InputData inputData;

    private bool isAiming = true;
    private bool isReload = false;
    private bool isShooting = false;

    private IEnumerator activeFire;
    private IEnumerator activeReload;

    public PlayerAutomatWeaponState(PlayerWeaponModel playerWeaponModel, InputData inputData)
    {
        this.playerWeaponModel = playerWeaponModel;
        this.inputData = inputData;
    }

    public void EnterState()
    {
        playerWeaponModel.SetWeaponData(weaponData);

        inputData.OnStartAim += StartAim;
        inputData.OnEndAim += EndAim;
        inputData.OnStartFire += StartFire;
        inputData.OnEndFire += EndFire;
    }

    public void ExitState()
    {
        if (isReload)
        {
            EndReload();
        }

        inputData.OnStartAim -= StartAim;
        inputData.OnEndAim -= EndAim;
        inputData.OnStartFire -= StartFire;
        inputData.OnEndFire -= EndFire;
    }

    private void StartAim()
    {
        if (isReload) return;
        isAiming = true;
        playerWeaponModel.StartAim();
    }

    private void EndAim()
    {
        isAiming = false;
        playerWeaponModel.EndAim();
    }

    private void StartFire()
    {
        isShooting = true;
        playerWeaponModel.StartFire();

        if (activeFire != null)
            Coroutines.StopCoroutine_(activeFire);

        Coroutines.StartCoroutine_(activeFire = ShootingCoroutine());
    }

    private void Fire()
    {
        Debug.Log("Выстрел");
        playerWeaponModel.Fire();
    }

    private void EndFire()
    {
        isShooting = false;
        playerWeaponModel.EndFire();

        if (activeFire != null)
            Coroutines.StopCoroutine_(activeFire);
    }

    private void StartReload()
    {
        isReload = true;
        playerWeaponModel.StartReload();

        if (activeReload != null)
            Coroutines.StopCoroutine_(activeReload);

        Coroutines.StartCoroutine_(activeReload = ReloadCoroutine());
    }

    private void EndReload()
    {
        isReload = false;
        playerWeaponModel.EndReload();

        if (activeReload != null)
            Coroutines.StopCoroutine_(activeReload);
    }

    public void SetWeapon(WeaponData weaponData)
    {
        this.weaponData = weaponData;
    }

    protected IEnumerator ShootingCoroutine()
    {
        while (true)
        {
            if (!isReload && isAiming)
            {
                if (weaponData.weaponCurrentBullet <= 0)
                {
                    StartReload();
                    yield return null;
                }
                else
                {
                    weaponData.weaponCurrentBullet -= 1;
                    Fire();
                }
            }

            yield return new WaitForSeconds(weaponData.weaponSpeedShoot);
        }
    }

    protected IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(weaponData.weaponTimeReload);
        weaponData.weaponCurrentBullet = weaponData.weaponMaxBullets;
        EndReload();
    }
}
