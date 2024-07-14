using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ZombieSpawner : ITickable
{
    private ZombiePrefabs zombiePrefabs;
    private ZombieTargets zombieTargets;
    private ZombieSpawnPoints zombieSpawnPoints;

    private List<ZombiePresenter> zombies = new List<ZombiePresenter>();

    public ZombieSpawner(ZombiePrefabs zombiePrefabs, ZombieTargets zombieTargets, ZombieSpawnPoints zombieSpawnPoints)
    {
        this.zombiePrefabs = zombiePrefabs;
        this.zombieTargets = zombieTargets;
        this.zombieSpawnPoints = zombieSpawnPoints;
    }

    public void SpawnRandomZombieInPosition(Transform transform)
    {
        ZombieModel zombieModel = new ZombieModel(new ZombieMoveModel(), new ZombieActionModel());
        SpawnZombieInPoint(transform, zombiePrefabs.GetRandomPrefab(), zombieModel, new ZombieMachine(zombieTargets, zombieModel));
    }

    public void SpawnRandomZombieInRandomPosition()
    {
        ZombieModel zombieModel = new ZombieModel(new ZombieMoveModel(), new ZombieActionModel());
        SpawnZombieInPoint(zombieSpawnPoints.GetRandomPoint(), zombiePrefabs.GetRandomPrefab(), zombieModel, new ZombieMachine(zombieTargets, zombieModel));
    }

    private void SpawnZombieInPoint(Transform transform, ZombieView prefab, ZombieModel zombieModel, ZombieMachine zombieMachine)
    {
        ZombieView zombieView = Object.Instantiate(prefab, transform.position, Quaternion.identity);
        ZombiePresenter zombie = new ZombiePresenter(zombieModel, zombieView, zombieMachine);

        zombies.Add(zombie);
    }

    public void Tick()
    {
        for(int i = 0; i < zombies.Count; i++)
        {
            zombies[i].Update();
        }
    }
}
