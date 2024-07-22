using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMoveView_LEGACY : MonoBehaviour
{
    public float turnSpeed = 10;
    public float turnSpeedMultiplier = 1;
    public Transform PlayerTransform { get { return playerTransform; } }

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

    private Vector3 targetDirection;

    public void Move(float inputX, float inputZ)
    {
        direction = playerTransform.forward * inputZ + playerTransform.right * inputX;

        if (Mathf.Abs(direction.magnitude) >= 0.3f)
            characterController.Move(speedMove * Time.deltaTime * direction.normalized);

        //characterController.Move(Vector3.down);

        var forward = Camera.main.transform.TransformDirection(Vector3.forward);
        forward.y = 0;

        //get the right-facing direction of the referenceTransform
        var right = Camera.main.transform.TransformDirection(Vector3.right);

        // determine the direction the player will face based on input and the referenceTransform's right and forward directions
        targetDirection = inputX * right + inputZ * forward;




        Vector3 lookDirection = targetDirection.normalized;
        Quaternion freeRotation = Quaternion.LookRotation(lookDirection, playerTransform.up);
        var diferenceRotation = freeRotation.eulerAngles.y - playerTransform.eulerAngles.y;
        var eulerY = playerTransform.eulerAngles.y;

        if (diferenceRotation < 0 || diferenceRotation > 0) eulerY = freeRotation.eulerAngles.y;
        var euler = new Vector3(0, eulerY, 0);

        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, Quaternion.Euler(euler), turnSpeed * turnSpeedMultiplier * Time.deltaTime);
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
        //followTransform.localEulerAngles = new Vector3(yAxis, followTransform.localEulerAngles.y, followTransform.localEulerAngles.z);
        //playerTransform.eulerAngles = new Vector3(playerTransform.eulerAngles.x, xAxis, playerTransform.eulerAngles.z);


        //Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        //Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        //if (Physics.Raycast(ray, out RaycastHit hit, 2000, mask))
        //{
        //    aimTransform.position = Vector3.Lerp(aimTransform.position, hit.point, 20 * Time.deltaTime);
        //}
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
