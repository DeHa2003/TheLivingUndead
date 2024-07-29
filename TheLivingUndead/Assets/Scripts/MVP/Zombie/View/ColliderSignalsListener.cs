using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSignalsListener : MonoBehaviour
{
    public event Action<float> OnTakeDamage;
    public event Action<Vector3, Vector3> OnTakeDirection;
    public event Action<float> OnTakeChanceFall;

    [SerializeField] private BodyPartCollider[] bodyPartColliders;

    public void Initialize()
    {
        for (int i = 0; i < bodyPartColliders.Length; i++)
        {
            bodyPartColliders[i].Initialize(this);
        }
    }

    public void TakeDamage(float damage)
    {
        OnTakeDamage?.Invoke(damage);
    }

    public void TakeDirection(Vector3 point, Vector3 vector)
    {
        OnTakeDirection?.Invoke(point, vector);
    }

    public void TakeChanceFall(float chance)
    {
        OnTakeChanceFall?.Invoke(chance);
    }
}
