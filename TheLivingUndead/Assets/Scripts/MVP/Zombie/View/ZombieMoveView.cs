using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMoveView : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform zombieTransform;

    public Transform ZombieTransform => zombieTransform;

    public void MoveTo(Vector3 vector)
    {
        agent.SetDestination(vector);
    }

    public void RotateTo(Vector3 vector)
    {

    }

    public void SetMoveSpeed(float speed)
    {
        agent.speed = speed;
    }

    public void Destroy()
    {
        Destroy(agent);
        Destroy(gameObject);
    }
}
