using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    public List<WeaponData> weaponsData;
    private int currentIndex = 0;

    public void AddData(WeaponData weaponData)
    {
        weaponsData.Add(weaponData);
    }

    //private void Update()
    //{
    //    float wheel = Input.GetAxis("Mouse ScrollWheel");

    //    if (wheel != 0)
    //    {
    //        currentIndex += wheel > 0 ? 1 : -1;

    //        if (currentIndex < 0)
    //        {
    //            currentIndex = weaponsData.Count - 1;
    //        }
    //        else if (currentIndex >= weaponsData.Count)
    //        {
    //            currentIndex = 0;
    //        }

    //        Debug.Log("Ёкипирован - " + weaponsData[currentIndex].weaponName);
    //        OnChangedWeapon?.Invoke(weaponsData[currentIndex]);
    //    }
    //}
}
