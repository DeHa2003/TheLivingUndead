using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponStateMachine : MonoBehaviour
{
    private Dictionary<Type, IWeaponState> weaponStates = new Dictionary<Type, IWeaponState>();


    private PlayerWeaponModel playerWeaponModel;
    private WeaponData currentWeaponData;
    private IWeaponState currentWeaponState;

    private int currentIndex;
    private WeaponInventory weaponInventory;
    private InputData inputData;

    public PlayerWeaponStateMachine(PlayerWeaponModel playerWeaponModel, WeaponInventory weaponInventory, InputData inputData)
    {
        this.playerWeaponModel = playerWeaponModel;
        this.inputData = inputData;
        this.weaponInventory = weaponInventory;
    }

    public void Initialize()
    {
        weaponStates[typeof(PlayerNoneWeaponState)] = new PlayerNoneWeaponState(playerWeaponModel, inputData);
        weaponStates[typeof(PlayerPistolWeaponState)] = new PlayerPistolWeaponState(playerWeaponModel, inputData);
        weaponStates[typeof(PlayerAutomatWeaponState)] = new PlayerAutomatWeaponState(playerWeaponModel, inputData);
        weaponStates[typeof(PlayerRifleWeaponState)] = new PlayerRifleWeaponState(playerWeaponModel, inputData);

        Activate();
    }

    public void SetWeaponData(WeaponData weaponData)
    {
        currentWeaponData = weaponData;

        switch (currentWeaponData.weaponType)
        {
            case WeaponType.None:
                SetState(GetWeaponState<PlayerNoneWeaponState>(), currentWeaponData);
                break;
            case WeaponType.Pistol:
                SetState(GetWeaponState<PlayerPistolWeaponState>(), currentWeaponData);
                break;
            case WeaponType.Rifle:
                SetState(GetWeaponState<PlayerRifleWeaponState>(), currentWeaponData);
                break;
            case WeaponType.Automat:
                SetState(GetWeaponState<PlayerAutomatWeaponState>(), currentWeaponData);
                break;
        }
    }

    private IWeaponState GetWeaponState<T>() where T : IWeaponState
    {
        return weaponStates[typeof(T)];
    }

    private void SetState(IWeaponState weaponState, WeaponData weaponData)
    {
        currentWeaponState?.ExitState();
        currentWeaponState = weaponState;
        currentWeaponState.SetWeapon(weaponData);
        currentWeaponState.EnterState();
    }

    private void ChooseState(float scrollWheel)
    {
        if (scrollWheel != 0)
        {
            currentIndex += scrollWheel > 0 ? 1 : -1;

            if (currentIndex < 0)
            {
                currentIndex = weaponInventory.weaponsData.Count - 1;
            }
            else if (currentIndex >= weaponInventory.weaponsData.Count)
            {
                currentIndex = 0;
            }

            Debug.Log("Ёкипирован - " + weaponInventory.weaponsData[currentIndex].weaponName);
            SetWeaponData(weaponInventory.weaponsData[currentIndex]);
        }
    }

    private void Activate()
    {
        inputData.OnMouseScroll += ChooseState;
    }

    private void Deactivate()
    {
        inputData.OnMouseScroll -= ChooseState;
    }
}
