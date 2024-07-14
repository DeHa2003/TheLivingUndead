using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsConstraints : MonoBehaviour
{
    [SerializeField] private List<WeaponAnimationsConstraints> _constraints = new List<WeaponAnimationsConstraints>();

    private WeaponAnimationsConstraints currentWeaponConstraints;
    private bool isAiming = false;

    public void ActivateWeaponConstraints(WeaponAnimationsConstraints weaponAnimationsConstraints)
    {
        if(currentWeaponConstraints != null)
            isAiming = currentWeaponConstraints.isAiming;

        currentWeaponConstraints?.Deactivate();

        currentWeaponConstraints = weaponAnimationsConstraints;
        currentWeaponConstraints.Activate();
        if(isAiming == true )
           currentWeaponConstraints.StartAim();
    }
    public WeaponAnimationsConstraints GetWeaponsConstraints(WeaponType type)
    {
        foreach(var constraint in _constraints)
        {
            if(constraint.weaponType == type)
            {
                return constraint;
            }
        }

        return null;
    }
}
