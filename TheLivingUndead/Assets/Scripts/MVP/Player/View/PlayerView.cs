using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour, ITarget
{
    [SerializeField] private PlayerCameraView cameraView;
    [SerializeField] private PlayerAnimationView animationView;
    [SerializeField] private PlayerMoveView moveView;
    [SerializeField] private PlayerWeaponView weaponView;

    public Transform Transform => moveView.PlayerTransform;

    public void Move(float inputX, float inputZ) 
    {
        moveView.Move(inputX, inputZ);
        animationView.Move(inputX, inputZ);
    }

    public void Rotate(float mouseX, float mouseZ) => moveView.Rotate(mouseX, mouseZ);

    public void SetMoveSpeed(float speed) => moveView.SetMoveSpeed(speed);

    public void SetRotateSpeed(float speed) => moveView.SetRotateSpeed(speed);

    public void SetMoveType(PlayerMoveType moveType) => animationView.SetMoveType(moveType);
    public void SetZoom(float FOV, float duration) => cameraView.SetZoom(FOV, duration);


    public void StartAim() 
    {
        weaponView.StartAim();
        animationView.StartAim();
    }

    public void EndAim()
    {
        animationView.EndAim();
        weaponView.EndAim();
    }

    public void StartFire()
    {

    }
    public void Fire()
    {
        weaponView.Fire();
        animationView.Fire();
    }

    public void EndFire()
    {

    }

    public void StartReload()
    {
        animationView.StartReload();
        weaponView.StartReload();
    }

    public void EndReload()
    {
        animationView.EndReload();
        weaponView.EndReload();
    }

    public void SetWeaponData(WeaponData weaponData)
    {
        weaponView.SetWeaponData(weaponData);
        animationView.SetWeaponType(weaponData.weaponType);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Нанесение урона цели");
    }
}
