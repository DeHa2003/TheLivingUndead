using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerAnimationView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private WeaponsConstraints weaponsConstraints;

    private const string AIM = "Aiming";
    private const string FIRE = "Fire";
    private const string RELOAD = "Reload";
    private const string WALK_PARAM = "Walking";
    private const string CROUCH_PARAM = "Crouching";
    private List<string> moveParams = new List<string> { WALK_PARAM, CROUCH_PARAM };
    private List<string> weapomParams = new List<string> { AIM, FIRE };

    private WeaponAnimationsConstraints currentWeaponsConstraints;

    private int currentIndex = -1;

    public void Move(float inputX, float inputZ)
    {
        animator.SetFloat("hzInput", inputX);
        animator.SetFloat("vInput", inputZ);
    }

    public void SetMoveType(MoveType moveType)
    {
        switch (moveType)
        {
            case MoveType.Walk:
                SetMovementState(WALK_PARAM);
                break;
            case MoveType.Crouch:
                SetMovementState(CROUCH_PARAM);
                break;
        }
    }

    public void SetWeaponType(WeaponType weaponType)
    {
        currentWeaponsConstraints = weaponsConstraints.GetWeaponsConstraints(weaponType);
        weaponsConstraints.ActivateWeaponConstraints(currentWeaponsConstraints);

        Debug.Log("Выбор аниации по типу оружия - " + weaponType);

        switch (weaponType)
        {
            case WeaponType.None:
                break;

            case WeaponType.Pistol:
                StartCoroutine(ActivateLayer(1));
                break;

            case WeaponType.Rifle:
                break;

            case WeaponType.Automat:
                StartCoroutine(ActivateLayer(2));
                break;
        }
    }


    private IEnumerator ActivateLayer(int layer)
    {
        float elapsedTime = 0f;

        while (elapsedTime < 0.1)
        {
            elapsedTime += Time.deltaTime;
            float blendFactor = elapsedTime / 0.1f;

            if (currentIndex != -1)
                animator.SetLayerWeight(currentIndex, Mathf.Lerp(1, 0, blendFactor));

            animator.SetLayerWeight(layer, Mathf.Lerp(0, 1, blendFactor));

            yield return null;
        }

        if (currentIndex != -1)
            animator.SetLayerWeight(currentIndex, 0);

        animator.SetLayerWeight(layer, 1);

        currentIndex = layer;
    }

    public void Fire()
    {
        //SetWeaponState(FIRE);
    }

    public void StartAim()
    {
        SetWeaponState(AIM);
        currentWeaponsConstraints.StartAim();
    }

    public void EndAim()
    {
        animator.SetBool(AIM, false);
        currentWeaponsConstraints.EndAim();
    }

    public void StartReload()
    {
        animator.SetBool(RELOAD, true);
        currentWeaponsConstraints.StartReload();
    }

    public void EndReload()
    {
        animator.SetBool(RELOAD, false);
        currentWeaponsConstraints.EndReload();
    }

    private void SetWeaponState(string name)
    {
        foreach (var param in weapomParams)
        {
            animator.SetBool(param, param == name);
        }
    }

    private void SetMovementState(string name)
    {
        foreach(var param in moveParams)
        {
            animator.SetBool(param, param == name);
        }
    }
}
