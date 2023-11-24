using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombi : MonoBehaviour
{
    public List<Transform> posSpawn = new();
    public List<GameObject> spawnZombies = new();
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(spawnZombies[Random.Range(0, spawnZombies.Count)], posSpawn[Random.Range(0, posSpawn.Count)].position, Quaternion.identity);
            Instantiate(spawnZombies[Random.Range(0, spawnZombies.Count)], posSpawn[Random.Range(0, posSpawn.Count)].position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
