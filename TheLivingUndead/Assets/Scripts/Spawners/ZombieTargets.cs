using System.Collections.Generic;
using UnityEngine;

public class ZombieTargets : MonoBehaviour, IZombieTargetsWriter, IZombieTargetsReader
{
    [SerializeField] private List<ITarget> zombieTargets = new List<ITarget>();

    public IEnumerable<ITarget> Targets()
    {
        return zombieTargets.AsReadOnly();
    }

    public void AddTarget(ITarget target)
    {
        zombieTargets.Add(target);
    }

    public void RemoveTarget(ITarget target)
    {
        zombieTargets.Remove(target);
    }

    public ITarget GetNearestTarget(Vector3 zombiePosition)
    {
        if (zombieTargets.Count == 0) return null;

        var distance = Mathf.Infinity;

        ITarget currentTarget = null;

        foreach (ITarget player in zombieTargets)
        {
            float distance_ = Vector3.Distance(zombiePosition, player.Transform.position);

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
    void AddTarget(ITarget target);
    void RemoveTarget(ITarget target);
}

public interface IZombieTargetsReader
{
    IEnumerable<ITarget> Targets();
    public ITarget GetNearestTarget(Vector3 zombiePosition);
}
