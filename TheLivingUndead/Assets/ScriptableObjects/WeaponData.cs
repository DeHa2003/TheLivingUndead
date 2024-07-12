using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public GameObject weaponPrefab;
    public WeaponType weaponType;
    public Vector3 weaponPosition;
    public Vector3 weaponRotation;

    public float weaponSpeedShoot;
    public float weaponMaxBullets;
    public float weaponCurrentBullet;
    public float weaponDamage;
    public float weaponTimeReload;
}
