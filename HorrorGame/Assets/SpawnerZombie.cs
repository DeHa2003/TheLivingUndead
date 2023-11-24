using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class SpawnerZombie : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform center;
    public GameObject[] players;
    public GameObject[] zombiesTypes;
    public int maxCount;
    public int nowCount = 0;

    private Vector3 posSpawn;
    private void Start()
    {
        SpawnZombies();
    }

    private void SpawnZombies()
    {
        for (int i = 0; i < Random.Range(20, 40); i++)
        {
            if (RandomPoint(new Vector3(150, 30, 150), 200, out Vector3 point))
            {
                Instantiate(zombiesTypes[Random.Range(0, zombiesTypes.Length)], point, Quaternion.identity);
            }

            if (nowCount == maxCount)
            {
                Destroy(GetComponent<SpawnerZombie>());
                break;
            }
        }
        Invoke(nameof(SpawnZombies), Random.Range(5, 20));

    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for(int i = 0; i < 20; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, 1f, NavMesh.AllAreas))
            {
                nowCount++;
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}
