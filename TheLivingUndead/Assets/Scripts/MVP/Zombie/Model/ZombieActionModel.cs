using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieActionModel : MonoBehaviour
{
    public Action OnAttack;
    public Action OnDie;

    public void Attack()
    {
        OnAttack?.Invoke();
    }

    public void Die()
    {
        OnDie?.Invoke();
    }
}
