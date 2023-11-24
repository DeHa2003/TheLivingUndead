using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthZombi : HealthManager
{
    private void Start()
    {
        healthSlider.maxValue = health;
    }
}
