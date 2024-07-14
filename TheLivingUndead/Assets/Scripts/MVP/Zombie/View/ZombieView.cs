using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieView : MonoBehaviour
{
    [SerializeField] private ZombieMoveView moveView;
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

    public void Attack()
    {

    }
}
