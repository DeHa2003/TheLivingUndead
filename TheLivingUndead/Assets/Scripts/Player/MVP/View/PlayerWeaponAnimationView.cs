using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponAnimationView : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private int currentIndex = -1;

    public void SetWeaponType(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.None:
                break;

            case WeaponType.Pistol:
                //animator.SetLayerWeight(2, 0);
                //animator.SetLayerWeight(1, 1);
                StartCoroutine(ActivateLayer(1));
                break;

            case WeaponType.Rifle:
                break;

            case WeaponType.Automat:
                //animator.SetLayerWeight(1, 0);
                //animator.SetLayerWeight(2, 1);
                StartCoroutine(ActivateLayer(2));
                break;
        }
    }


    private IEnumerator ActivateLayer(int layer)
    {
        float elapsedTime = 0f;

        while(elapsedTime < 0.1)
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

    //public void Aim()
    //{

    //}

    //public void Fire()
    //{

    //}

    //public void Reload()
    //{

    //}
}
