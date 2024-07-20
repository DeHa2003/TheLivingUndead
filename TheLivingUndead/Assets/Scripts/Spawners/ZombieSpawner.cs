using System.Collections.Generic;
using System;
using UnityEngine;
using Zenject;

public class ZombieSpawner : ITickable, IDisposable
{
    private ZombiePrefabs zombiePrefabs;
    private ZombieTargets zombieTargets;
    private ZombieSpawnPoints zombieSpawnPoints;
    private NavMeshPointGenerator pointGenerator;

    private List<ZombiePresenter> zombies = new List<ZombiePresenter>();

    public ZombieSpawner(ZombiePrefabs zombiePrefabs, ZombieTargets zombieTargets, ZombieSpawnPoints zombieSpawnPoints, NavMeshPointGenerator pointGenerator)
    {
        this.zombiePrefabs = zombiePrefabs;
        this.zombieTargets = zombieTargets;
        this.zombieSpawnPoints = zombieSpawnPoints;
        this.pointGenerator = pointGenerator;
    }

    public void SpawnRandomZombieInPosition(Transform transform)
    {
        ZombieModel zombieModel = new ZombieModel(new ZombieMoveModel(), new ZombieActionModel());
        SpawnZombieInPoint(transform, zombiePrefabs.GetRandomPrefab(), zombieModel, new ZombieMachine(zombieTargets, zombieModel, pointGenerator));
    }

    public void SpawnRandomZombieInRandomPosition()
    {
        ZombieModel zombieModel = new ZombieModel(new ZombieMoveModel(), new ZombieActionModel());
        SpawnZombieInPoint(zombieSpawnPoints.GetRandomPoint(), zombiePrefabs.GetRandomPrefab(), zombieModel, new ZombieMachine(zombieTargets, zombieModel, pointGenerator));
    }

    private void SpawnZombieInPoint(Transform transform, ZombieView prefab, ZombieModel zombieModel, ZombieMachine zombieMachine)
    {
        ZombieView zombieView = UnityEngine.Object.Instantiate(prefab, transform.position, Quaternion.identity);
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

    public void Dispose()
    {
        for (int i = 0; i < zombies.Count; i++)
        {
            zombies[i].Destroy();
        }
    }
}
