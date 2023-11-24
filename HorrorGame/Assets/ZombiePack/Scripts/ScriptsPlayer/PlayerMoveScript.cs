using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveScript : MonoBehaviour
{
    public float speedH = 2f;
    public float speedV = 2f;
    private float a;
    private float b;
    [Header("Character move")]
    private Vector3 moveDirection;
    public CharacterController character;
    public float speed;
    public float gravity;
    public float jumpSpeed;

    private bool isVisibleCursor = false;
    void Update()
    {
        MoveCharacter();
        RotatePlayer();
    }

    private void MoveCharacter()
    {
        if (character.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection) * speed;
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        character.Move(moveDirection * Time.deltaTime);
    }
    private void RotatePlayer()
    {
        a += speedH * Input.GetAxis("Mouse X");
        b -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(b, a, 0);

        if (Input.GetKeyDown(KeyCode.Q) && isVisibleCursor == false)
        {
            isVisibleCursor = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if(Input.GetKeyDown(KeyCode.Q) && isVisibleCursor == true)
        {
            isVisibleCursor = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }
}
