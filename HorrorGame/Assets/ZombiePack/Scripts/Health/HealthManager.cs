using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int health;
    public Slider healthSlider;
    public void GetDamage(int damage)
    {
        if(damage > 0)
        {
            health -= damage;
            healthSlider.value = health;
        }
    }
}
