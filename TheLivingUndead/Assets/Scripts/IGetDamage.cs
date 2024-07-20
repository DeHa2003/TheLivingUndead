using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGetDamage
{
    void TakeDamage(float damage);
}

public interface ITarget : IGetDamage
{
    Transform Transform { get; }
}
