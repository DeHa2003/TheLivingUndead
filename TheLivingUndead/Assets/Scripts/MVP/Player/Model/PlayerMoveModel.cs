using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;

public class PlayerMoveModel : MonoBehaviour
{
    public event Action<PlayerMoveType> OnMoveType;
    public event Action<float, float> OnMove;
    public event Action<float, float> OnRotate;

    public event Action<float> OnSpeedRotate;
    public event Action<float> OnSpeedMove;
    public event Action OnJump;

    public void SetMoveType(PlayerMoveType moveType) => OnMoveType?.Invoke(moveType);
    public void SetMove(float inputX, float inputZ) => OnMove?.Invoke(inputX, inputZ);

    public void SetRotate(float mouseX, float mouseY) => OnRotate?.Invoke(mouseX, mouseY);

    public void SetJump() => OnJump?.Invoke();


    #region Speeds
    public void SetMoveSpeed(float speed) => OnSpeedMove?.Invoke(speed);

    public void SetRotateSpeed(float speed) => OnSpeedRotate?.Invoke(speed);
    #endregion
}
