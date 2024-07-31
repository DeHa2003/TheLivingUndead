using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    [SerializeField] private InputData inputData;
    [SerializeField] private PlayerView playerViewPrefab;
    [SerializeField] private WeaponInventory weaponInventory;

    [Inject] private IZombieTargetsWriter zombieTargets;
    [Inject] private ZombieSpawner zombieSpawner;

    private PlayerPresenter playerPresenter;
    private void Start()
    {
        var playerView = Instantiate(playerViewPrefab, Vector3.zero, Quaternion.identity);

        var playerMoveModel = new PlayerMoveModel();
        var playerWeaponModel = new PlayerWeaponModel();
        var playerModel = new PlayerModel(playerMoveModel, playerWeaponModel);

        playerPresenter = new PlayerPresenter(
            playerModel,
            playerView,
            new PlayerMoveStateMachine(playerMoveModel, inputData),
            new PlayerWeaponStateMachine(playerWeaponModel, weaponInventory, inputData));
        playerPresenter.Initialize();

        zombieTargets.AddTarget(playerView);

        zombieSpawner.SpawnRandomZombieInRandomPosition();
        //zombieSpawner.SpawnRandomZombieInRandomPosition();
    }

    private void OnDestroy()
    {
        //zombieSpawner.Destroy();
    }
}
