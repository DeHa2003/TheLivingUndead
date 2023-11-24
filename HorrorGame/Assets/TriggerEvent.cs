using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public bool first = false;
    public UnityEngine.Events.UnityEvent TriggerEvents;

    private void OnTriggerEnter(Collider other)
    {
        if (first)
        {
            if (other.CompareTag("Player"))
            {
                first = false;
                TriggerEvents.Invoke();
            }
        }
    }
}
