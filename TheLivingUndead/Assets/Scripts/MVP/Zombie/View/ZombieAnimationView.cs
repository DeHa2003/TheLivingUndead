using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ZombieAnimationView : MonoBehaviour
{
    [SerializeField] private RigBuilder rigBuilder;
    [SerializeField] private Animator animator;

    private const string ATTACK = "Attack";

    private const string WALK = "Walking";
    private const string RUN = "Running";
    private const string RISE = "Rise";
    private List<string> moveParams = new List<string> { WALK, RUN, RISE };

    private string currentAnim;

    public void SetMoveType(ZombieMoveType zombieMoveType)
    {
        switch (zombieMoveType)
        {
            case ZombieMoveType.Walk:
                SetMovementState(currentAnim = WALK);
                break;
            case ZombieMoveType.Run:
                SetMovementState(currentAnim = RUN);
                break;
        }
    }

    public void StartAttack()
    {
        animator.SetLayerWeight(1, 1);
        animator.SetBool(ATTACK, true);
    }

    public void EndAttack()
    {
        animator.SetBool(ATTACK, false);
        animator.SetLayerWeight(1, 0);
    }

    public void Destroy()
    {
        Destroy(rigBuilder);
        Destroy(animator);
        Destroy(gameObject);
    }

    public void Rise()
    {
        animator.SetTrigger(RISE);
    }

    public void ActivateAnimator(bool activate)
    {
        if (activate == false) animator.SetBool(currentAnim, false);
        animator.enabled = activate;
    }

    private void SetMovementState(string name)
    {
        foreach (var param in moveParams)
        {
            animator.SetBool(param, param == name);
        }
    }
}
