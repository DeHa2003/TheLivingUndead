using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieActionModel : MonoBehaviour
{
    public event Action OnStartAttack;
    public event Action OnEndAttack;
    public event Action OnAttack;
    public event Action OnDie;

    public event Action OnFootstep;

    public event Action OnFall;
    public event Action OnStartRise;
    public event Action OnEndRise;

    public void StartAttack()
    {
        OnStartAttack?.Invoke();
    }

    public void EndAttack()
    {
        OnEndAttack?.Invoke();
    }

    public void Footstep()
    {
        OnFootstep?.Invoke();
    }

    public void Attack()
    {
        OnAttack?.Invoke();
    }

    public void Fall()
    {
        OnFall?.Invoke();
    }

    public void StartRise()
    {
        OnStartRise?.Invoke();
    }

    public void EndRise()
    {
        OnEndRise?.Invoke();
    }

    public void Die()
    {
        OnDie?.Invoke();
    }
}
