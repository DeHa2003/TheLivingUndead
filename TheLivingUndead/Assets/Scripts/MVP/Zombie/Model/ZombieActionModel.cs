using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieActionModel : MonoBehaviour
{
    public Action OnStartAttack;
    public Action OnAttack;
    public Action OnEndAttack;
    public Action OnDie;

    public void StartAttack()
    {
        OnStartAttack?.Invoke();
    }

    public void Attack()
    {
        OnAttack?.Invoke();
    }

    public void EndAttack()
    {
        OnEndAttack?.Invoke();
    }

    public void Die()
    {
        OnDie?.Invoke();
    }
}
