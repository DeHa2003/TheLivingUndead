using System.Collections.Generic;
using UnityEngine;

public class ZombiePrefabs : MonoBehaviour
{
    [SerializeField] private List<ZombieView> zombiePrefabs = new List<ZombieView>();

    public ZombieView GetRandomPrefab()
    {
        int randomNumber = Random.Range(0, zombiePrefabs.Count);
        return zombiePrefabs[randomNumber];
    }
}
