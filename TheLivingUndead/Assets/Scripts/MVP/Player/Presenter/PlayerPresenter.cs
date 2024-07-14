using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPresenter
{
    private PlayerModel playerModel;
    private PlayerView playerView;

    private PlayerMoveStateMachine moveStateMachine;
    private PlayerWeaponStateMachine weaponStateMachine;

    public PlayerPresenter(
        PlayerModel playerModel, 
        PlayerView playerView, 
        PlayerMoveStateMachine moveStateMachine, 
        PlayerWeaponStateMachine weaponStateMachine)
    {

        Debug.Log("Игрок создан");
        this.playerModel = playerModel;
        this.playerView = playerView;
        this.weaponStateMachine = weaponStateMachine;
        this.moveStateMachine = moveStateMachine;

        ActivateEvents();
    }

    public void Initialize()
    {
        moveStateMachine.Initialize();
        weaponStateMachine.Initialize();
    }

    public void SetWeaponData(WeaponData weaponData)
    {
        weaponStateMachine.SetWeaponData(weaponData);
    }

    public void ActivateEvents()
    {
        playerModel.MoveModel.OnMove += playerView.Move;
        playerModel.MoveModel.OnRotate += playerView.Rotate;
        playerModel.MoveModel.OnSpeedMove += playerView.SetMoveSpeed;
        playerModel.MoveModel.OnSpeedRotate += playerView.SetRotateSpeed;
        playerModel.MoveModel.OnMoveType += playerView.SetMoveType;

        playerModel.WeaponModel.OnSetWeaponData += playerView.SetWeaponData;
        playerModel.WeaponModel.OnStartAim += playerView.StartAim;
        playerModel.WeaponModel.OnEndAim += playerView.EndAim;
        playerModel.WeaponModel.OnStartFire += playerView.StartFire;
        playerModel.WeaponModel.OnFire += playerView.Fire;
        playerModel.WeaponModel.OnEndFire += playerView.EndFire;
        playerModel.WeaponModel.OnStartReload += playerView.StartReload;
        playerModel.WeaponModel.OnEndReload += playerView.EndReload;
    }

    public void DeacrivateEvents()
    {
        playerModel.MoveModel.OnMove -= playerView.Move;
        playerModel.MoveModel.OnRotate -= playerView.Rotate;
        playerModel.MoveModel.OnSpeedMove -= playerView.SetMoveSpeed;
        playerModel.MoveModel.OnSpeedRotate -= playerView.SetRotateSpeed;
        playerModel.MoveModel.OnMoveType -= playerView.SetMoveType;

        playerModel.WeaponModel.OnSetWeaponData -= playerView.SetWeaponData;
        playerModel.WeaponModel.OnStartAim -= playerView.StartAim;
        playerModel.WeaponModel.OnEndAim -= playerView.EndAim;
        playerModel.WeaponModel.OnStartFire -= playerView.StartFire;
        playerModel.WeaponModel.OnFire -= playerView.Fire;
        playerModel.WeaponModel.OnEndFire -= playerView.EndFire;
        playerModel.WeaponModel.OnStartReload -= playerView.StartReload;
        playerModel.WeaponModel.OnEndReload -= playerView.EndReload;
    }
}
