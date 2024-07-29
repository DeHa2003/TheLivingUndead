using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealthView : MonoBehaviour
{
    [SerializeField] private ZombieHealthBarView healthBar;

    public void Initialize()
    {
        healthBar.Initialize();
    }
    public void ChangeHealth(float health)
    {
        healthBar.SetHealth(health);
    }

    public void Destroy()
    {
        healthBar.Destroy();
        Destroy(gameObject);
    }
}
