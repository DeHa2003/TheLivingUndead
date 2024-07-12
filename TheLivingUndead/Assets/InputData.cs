using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputData : MonoBehaviour
{

    public float VerticalAxis { get; private set; }
    public float HorizontalAxis { get; private set; }
    public float MouseX { get; private set; }
    public float MouseY { get; private set; }


    public event Action<float> GetVerticalAxis;
    public event Action<float> GetHorizontalAxis;

    public event Action<float> GetMouseX;
    public event Action<float> GetMouseY;

    public event Action<float, float> OnMove;
    public event Action<float, float> OnRotate;

    public event Action OnCrouch;
    public event Action OnJump;

    //-----------------------------//

    public event Action OnStartAim;
    public event Action OnEndAim;
    public event Action OnStartFire;
    public event Action OnEndFire;
    public event Action<float> OnMouseScroll;

    void Update()
    {
        VerticalAxis = Input.GetAxis("Vertical");
        HorizontalAxis = Input.GetAxis("Horizontal");

        MouseX = Input.GetAxisRaw("Mouse X");
        MouseY = Input.GetAxisRaw("Mouse Y");

        GetVerticalAxis?.Invoke(VerticalAxis);
        GetHorizontalAxis?.Invoke(HorizontalAxis);

        GetMouseX?.Invoke(MouseX);
        GetMouseY?.Invoke(MouseY);

        if(VerticalAxis != 0 || HorizontalAxis != 0) OnMove?.Invoke(HorizontalAxis, VerticalAxis);

        if (MouseX != 0 || MouseY != 0) OnRotate?.Invoke(MouseX, MouseY);

        if (Input.GetKeyDown(KeyCode.LeftAlt)) OnCrouch?.Invoke();

        if (Input.GetMouseButtonDown(1)) OnStartAim?.Invoke();
        if (Input.GetMouseButtonUp(1)) OnEndAim?.Invoke();
        if (Input.GetMouseButtonDown(0)) OnStartFire?.Invoke();
        if (Input.GetMouseButtonUp(0)) OnEndFire?.Invoke();

        OnMouseScroll?.Invoke(Input.GetAxis("Mouse ScrollWheel"));
    }
}
