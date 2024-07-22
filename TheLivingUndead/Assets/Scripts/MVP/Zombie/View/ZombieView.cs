using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieView : MonoBehaviour
{
    public event Action OnAttack { 
        add { animationView.OnAnimationAttackEvent += value; } 
        remove { animationView.OnAnimationAttackEvent -= value; } }

    [SerializeField] private ZombieMoveView moveView;
    [SerializeField] private ZombieAnimationView animationView;
    public Transform ZombieTransform { get { return moveView.ZombieTransform; } }

    public void MoveTo(Vector3 vector)
    {
        moveView.MoveTo(vector);
    }

    public void RotateTo(Vector3 vector)
    {
        moveView.RotateTo(vector);
    }

    public void SetMoveSpeed(float speed)
    {
        moveView.SetMoveSpeed(speed);
    }

    public void SetMoveType(ZombieMoveType moveType)
    {
        animationView.SetMoveType(moveType);
    }

    public void StartAttack()
    {
        animationView.StartAttack();
    }

    public void EndAttack()
    {
        animationView.EndAttack();
    }
}
