using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGetDamage
{
    void TakeDamage(float damage);
}

public interface IGetDirectionDamage : IGetDamage
{
    void TakeDamage(Vector3 point, Vector3 hitDirection, float damage);
}

public interface ITarget : IGetDamage
{
    Transform Transform { get; }
}
