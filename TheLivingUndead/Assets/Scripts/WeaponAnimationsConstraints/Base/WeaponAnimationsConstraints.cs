using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponAnimationsConstraints : MonoBehaviour
{
    public WeaponType weaponType;
    public bool isAiming;
    public bool isReload;

    public virtual void Activate() { }
    public virtual void Deactivate() { }

    public virtual void StartAim() { }
    public virtual void EndAim() { }
    public abstract void Fire();
    public virtual void StartReload() { }
    public virtual void EndReload() { }
}
