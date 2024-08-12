using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponState
{
    public bool IsAiming();
    public void EnterState();
    public void ExitState();
    public void SetWeapon(WeaponData weapon);
}
