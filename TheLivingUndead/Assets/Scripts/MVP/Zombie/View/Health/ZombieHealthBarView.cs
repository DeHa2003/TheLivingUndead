using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealthBarView : MonoBehaviour
{
    [SerializeField] private Slider healthBar;

    public void Initialize()
    {

    }

    public void SetHealth(float health)
    {
        healthBar.value = health;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
