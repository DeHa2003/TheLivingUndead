using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnPoints : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

    public void AddPoint(Transform transform)
    {
        spawnPoints.Add(transform);
    }

    public void RemovePoint(Transform transform)
    {
        spawnPoints.Remove(transform);
    }

    public Transform GetRandomPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Count)];
    }
}
