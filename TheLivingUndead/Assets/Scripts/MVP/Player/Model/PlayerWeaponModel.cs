using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponModel
{
    public event Action<WeaponData> OnSetWeaponData;

    public event Action OnStartAim;
    public event Action OnEndAim;
    public event Action OnStartFire;
    public event Action OnFire;
    public event Action OnEndFire;
    public event Action OnStartReload;
    public event Action OnEndReload;

    public event Action<float, float> OnSetZoom;

    //private WeaponData currentWeaponData;

    //private bool isAiming = false;
    //private bool isShooting = false;
    //private bool isReload = false;
    //private float currentBullet;

    //private IEnumerator activeFire;
    //private IEnumerator activeReload;

    //public void StartAim()
    //{
    //    Debug.Log("Старт прицела");
    //    isAiming = true;
    //    OnStartAim?.Invoke();
    //}

    //public void EndAim()
    //{
    //    Debug.Log("Конец прицела");
    //    isAiming = false;
    //    OnEndAim?.Invoke();
    //}

    //public void StartFire()
    //{
    //    isShooting = true;
    //    OnStartFire?.Invoke();

    //    if (activeFire != null)
    //        Coroutines.StopCoroutine_(activeFire);

    //    Coroutines.StartCoroutine_(activeFire = ShootingCoroutine());

    //}

    //public void EndFire()
    //{
    //    isShooting = false;
    //    OnEndFire?.Invoke();

    //    if (activeFire != null)
    //        Coroutines.StopCoroutine_(activeFire);
    //}

    //public void StartReload()
    //{
    //    Debug.Log("Старт перезарядки");
    //    isReload = true;
    //    OnStartReload?.Invoke();

    //    if (activeReload != null)
    //        Coroutines.StopCoroutine_(activeReload);

    //    Coroutines.StartCoroutine_(activeReload = ReloadCoroutine());
    //}

    //public void EndReload()
    //{
    //    Debug.Log("Конец перезарядки");
    //    isReload = false;
    //    OnEndReload?.Invoke();

    //    if (activeReload != null)
    //        Coroutines.StopCoroutine_(activeReload);
    //}

    public void StartAim()
    {
        OnStartAim?.Invoke();
    }

    public void EndAim()
    {
        OnEndAim?.Invoke();
    }

    public void StartFire()
    {
        OnStartFire?.Invoke();
    }

    public void Fire()
    {
        OnFire?.Invoke();
    }

    public void EndFire()
    {
        OnEndFire?.Invoke();
    }

    public void StartReload()
    {
        OnStartReload?.Invoke();
    }

    public void EndReload()
    {
        OnEndReload?.Invoke();
    }

    public void SetWeaponData(WeaponData weaponData)
    {
        //currentWeaponData = weaponData;
        //OnSetWeaponData?.Invoke(currentWeaponData);

        OnSetWeaponData?.Invoke(weaponData);
    }

    public void SetZoom(float FOV, float duration)
    {
        OnSetZoom?.Invoke(FOV, duration);
    }

    //protected IEnumerator ShootingCoroutine()
    //{
    //    while (true)
    //    {
    //        if(!isReload && isAiming)
    //        {
    //            currentWeaponData.weapomCurrentBullet -= 1;

    //            Debug.Log("Выстрел");
    //            OnFire?.Invoke();

    //            //weaponBullet.Recoil();

    //            if (currentWeaponData.weapomCurrentBullet <= 0)
    //            {
    //                StartReload();
    //            }
    //        }

    //        yield return new WaitForSeconds(currentWeaponData.weaponSpeedShoot);
    //    }
    //}

    //protected IEnumerator ReloadCoroutine()
    //{
    //    yield return new WaitForSeconds(currentWeaponData.weaponTimeReload);
    //    currentWeaponData.weapomCurrentBullet = currentWeaponData.weaponMaxBullets;
    //    EndReload();
    //}
}
