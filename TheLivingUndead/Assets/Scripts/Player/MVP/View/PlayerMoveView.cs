using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveView : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform followTransform;
    [SerializeField] private Transform aimTransform;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private LayerMask mask;

    [SerializeField] private float speedMove;
    [SerializeField] private float speedRotate;

    private Vector3 direction;

    private float xAxis;
    private float yAxis;

    public void Move(float inputX, float inputZ)
    {
        direction = playerTransform.forward * inputZ + playerTransform.right * inputX;

        if (Mathf.Abs(direction.magnitude) >= 0.3f)
            characterController.Move(speedMove * Time.deltaTime * direction.normalized);

        characterController.Move(Vector3.down);
    }

    public void Rotate(float mouseX, float MouseY)
    {
        //xAxis += Input.GetAxisRaw("Mouse X") * speedRotate;
        //yAxis += Input.GetAxisRaw("Mouse Y") * speedRotate;

        xAxis += mouseX * speedRotate;
        yAxis += MouseY * speedRotate;

        yAxis = Mathf.Clamp(yAxis, -80, 80);
    }

    private void Update()
    {
        followTransform.localEulerAngles = new Vector3(yAxis, followTransform.localEulerAngles.y, followTransform.localEulerAngles.z);
        playerTransform.eulerAngles = new Vector3(playerTransform.eulerAngles.x, xAxis, playerTransform.eulerAngles.z);


        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        if (Physics.Raycast(ray, out RaycastHit hit, 2000, mask))
        {
            aimTransform.position = Vector3.Lerp(aimTransform.position, hit.point, 20 * Time.deltaTime);
        }
    }

    public void SetMoveSpeed(float speedMove)
    {
        this.speedMove = speedMove;
    }

    public void SetRotateSpeed(float speedRotate)
    {
        this.speedRotate = speedRotate;
    }
}
