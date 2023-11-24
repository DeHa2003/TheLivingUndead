using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZombi : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            var health = other.GetComponent<HealthPlayer>();
            health.GetDamage(Random.Range(2, 10));
            health.AttackZombi();
        }
    }
}
