using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealthModel
{
    public float Health { get; private set; }

    public event Action OnDie;
    public event Action<float> OnChangedHealth;

    public ZombieHealthModel(float health)
    {
        Health = health;
    }

    public void TakeDamage(float damage)
    {
        if(Health < damage)
        {
            OnChangedHealth?.Invoke(0);
            OnDie?.Invoke();
            return;
        }

        Health -= damage;
        OnChangedHealth?.Invoke(Health);
    }
}
