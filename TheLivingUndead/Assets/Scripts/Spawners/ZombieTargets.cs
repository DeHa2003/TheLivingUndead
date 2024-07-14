using System.Collections.Generic;
using UnityEngine;

public class ZombieTargets : MonoBehaviour
{
    [SerializeField] private List<Transform> zombieTargets = new List<Transform>();

    public Transform GetNearestTarget(Vector3 zombiePosition)
    {
        var distance = Mathf.Infinity;

        Transform currentTarget = null;

        foreach (Transform player in zombieTargets)
        {
            float distance_ = Vector3.Distance(zombiePosition, player.position);

            if (distance_ < distance)
            {
                distance = distance_;
                currentTarget = player;
            }
        }

        return currentTarget;
    }
}
