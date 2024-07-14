using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RifleWeaponsConstraints : WeaponAnimationsConstraints
{
    [SerializeField] private TwoBoneIKConstraint leftHandConstraint;
    [SerializeField] private MultiAimConstraint rightHandConstraint;
    public override void StartAim()
    {
        isAiming = true;

        leftHandConstraint.weight = 1;
        rightHandConstraint.weight = 1;
    }

    public override void EndAim()
    {
        isAiming = false;

        leftHandConstraint.weight = 0;
        rightHandConstraint.weight = 0;
    }

    public override void Fire()
    {

    }

    public override void StartReload()
    {

        leftHandConstraint.weight = 0;
        rightHandConstraint.weight = 0;
    }

    public override void EndReload()
    {
        if (isAiming)
        {
            leftHandConstraint.weight = 1;
            rightHandConstraint.weight = 1;
        }
    }

    public override void Activate()
    {
        
    }

    public override void Deactivate()
    {
        EndAim();
    }


}
