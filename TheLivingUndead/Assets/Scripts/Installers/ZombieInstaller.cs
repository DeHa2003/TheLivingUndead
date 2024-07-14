using UnityEngine;
using Zenject;

public class ZombieInstaller : MonoInstaller
{
    //[SerializeField] private ZombieProperties zombieProperties;
    [SerializeField] private ZombieTargets zombieTargets;
    [SerializeField] private ZombieSpawnPoints zombieSpawnPoints;
    [SerializeField] private ZombiePrefabs zombiePrefabs;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<ZombieSpawner>().
            AsSingle().
            WithArguments(zombiePrefabs, zombieTargets, zombieSpawnPoints);

        Container.Bind<ZombieTargets>().
            FromInstance(zombieTargets).
            AsSingle();

        Container.Bind<ZombieSpawnPoints>().
            FromInstance(zombieSpawnPoints).
            AsSingle();

        Container.Bind<ZombiePrefabs>().
            FromInstance(zombiePrefabs).
            AsSingle();

        //Container.BindInterfacesAndSelfTo<ZombieMove_Property>().
        //    FromInstance(zombieProperties.moveProperty).
        //    AsSingle();
    }
}