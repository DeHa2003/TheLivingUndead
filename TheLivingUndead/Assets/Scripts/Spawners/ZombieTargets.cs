using System.Collections.Generic;
using UnityEngine;

public class ZombieTargets : MonoBehaviour, IZombieTargetsWriter, IZombieTargetsReader
{
    [SerializeField] private List<Transform> zombieTargets = new List<Transform>();

    public IEnumerable<Transform> Targets()
    {
        return zombieTargets.AsReadOnly();
    }

    public void AddTarget(Transform target)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveTarget(Transform target)
    {
        throw new System.NotImplementedException();
    }

    public Transform GetNearestTarget(Vector3 zombiePosition)
    {
        if (zombieTargets.Count == 0) return null;

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

public interface IZombieTargetsWriter
{
    void AddTarget(Transform target);
    void RemoveTarget(Transform target);
}

public interface IZombieTargetsReader
{
    IEnumerable<Transform> Targets();
    public Transform GetNearestTarget(Vector3 zombiePosition);
}
