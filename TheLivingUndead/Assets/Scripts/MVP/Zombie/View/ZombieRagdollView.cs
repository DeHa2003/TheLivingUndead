using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZombieRagdollView : MonoBehaviour
{
    [SerializeField] private Transform mainTransformBones;

    private Rigidbody[] rigidbodies;

    public void Initialize()
    {
        rigidbodies = mainTransformBones.GetComponentsInChildren<Rigidbody>();

        DeactivateRagdoll();
    }

    public void ActivateRagdoll()
    {
        for (int i = 0; i < rigidbodies.Length; i++)
        {
            rigidbodies[i].useGravity = true;
            rigidbodies[i].isKinematic = false;
        }
    }

    public void DeactivateRagdoll()
    {
        for (int i = 0; i < rigidbodies.Length; i++)
        {
            rigidbodies[i].useGravity = false;
            rigidbodies[i].isKinematic = true;
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
