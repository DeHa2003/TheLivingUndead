using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BodyPartConfig", menuName = "Body/BodyPart/BodyPartConfig")]
public class BodyPartConfig : ScriptableObject
{
    [SerializeField] private BodyPart bodyPart;
    [SerializeField][Range(0, 1)] private float damageMultiplayer;
    [SerializeField][Range(0, 100)] private float criticalHitChance;
    [SerializeField][Range(0, 100)] private float fallChance;

    public BodyPart BodyPart => bodyPart;
    public float DamageMultiplayer => damageMultiplayer;
    public float CriticalHitChance => criticalHitChance;
    public float FallChance => fallChance;
}

public enum BodyPart
{
    LeftUpperLeg, 
    RightUpperLeg, 
    LeftLowerLeg, 
    RightLowerLeg, 

    LeftUpperArm,
    RightUpperArm,
    LeftLowerArm,
    RightLowerArm,

    Head, Chest, Pelvis
}
