using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieView : MonoBehaviour
{
    public Transform ZombieTransform { get { return moveView.ZombieTransform; } }

    [SerializeField] private ZombieMoveView moveView;
    [SerializeField] private ZombieHealthView healthView;
    [SerializeField] private ZombieAnimationView animationView;
    [SerializeField] private ZombieRagdollView ragdollView;

    [SerializeField] private AnimSignalsListener animSignalsListener;
    [SerializeField] private ColliderSignalsListener colliderSignalsListener;

    public void Initialize()
    {
        colliderSignalsListener.Initialize();

        healthView.Initialize();
        ragdollView.Initialize();
    }

    public void Destroy()
    {
        ragdollView.ActivateRagdoll();

        moveView.Destroy();
        healthView.Destroy();
        animationView.Destroy();
        ragdollView.Destroy();

        Destroy(this);
    }

    #region Move

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

    #endregion

    #region Animation

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

    public void Fall()
    {
        animationView.ActivateAnimator(false);
        ragdollView.ActivateRagdoll();
    }

    public void StartRise()
    {
        ragdollView.DeactivateRagdoll();
        animationView.ActivateAnimator(true);
        animationView.Rise();
    }

    #endregion

    #region Health

    public void ChangeHealth(float health)
    {
        healthView.ChangeHealth(health);
    }

    #endregion



    #region Reverse

    public event Action<float> OnTakeDamageEvent
    {
        add { colliderSignalsListener.OnTakeDamage += value; }
        remove { colliderSignalsListener.OnTakeDamage -= value; }
    }

    public event Action OnAttackEvent
    {
        add { animSignalsListener.OnAttackEvent += value; }
        remove { animSignalsListener.OnAttackEvent -= value; }
    }

    public event Action OnRiseEvent
    {
        add { animSignalsListener.OnRiseUpEvent += value; }
        remove { animSignalsListener.OnRiseUpEvent -= value; }
    }

    public event Action OnFootstepEvent
    {
        add { animSignalsListener.OnFootstepEvent += value; }
        remove { animSignalsListener.OnFootstepEvent -= value; }
    }

    #endregion
}
