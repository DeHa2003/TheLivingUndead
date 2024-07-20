using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimationView : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private const string ATTACK = "Attack";

    private const string WALK = "Walking";
    private const string RUN = "Running";
    private List<string> moveParams = new List<string> { WALK, RUN };

    public void SetMoveType(ZombieMoveType zombieMoveType)
    {
        switch (zombieMoveType)
        {
            case ZombieMoveType.Walk:
                SetMovementState(WALK);
                break;
            case ZombieMoveType.Run:
                SetMovementState(RUN);
                break;
        }
    }

    public void Attack()
    {
        
    }

    private void SetMovementState(string name)
    {
        foreach (var param in moveParams)
        {
            animator.SetBool(param, param == name);
        }
    }
}
