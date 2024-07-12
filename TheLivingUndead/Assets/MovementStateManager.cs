using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    public Vector3 Dir { get; private set; }

    public float moveSpeed;
    [SerializeField] private float gravitateForce;
    [SerializeField] private LayerMask groundMask;
    private float hzInput, vInput;
    private CharacterController characterController;
    public Animator animator { get; private set; }


    MovementBaseState currentState;

    public IdleState idleState = new IdleState();
    public WalkState walkState = new WalkState();

    public void SwitchState(MovementBaseState movementBaseState)
    {
        currentState = movementBaseState;
        currentState?.EnterState(this);
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        SwitchState(idleState);
    }
    private void Update()
    {
        GetDirectionAndMove();

        animator.SetFloat("hzInput", hzInput);
        animator.SetFloat("vInput", vInput);

        currentState?.UpdateState(this);
    }

    private void GetDirectionAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        Dir = transform.forward * vInput + transform.right * hzInput;

        if(Mathf.Abs(Dir.magnitude) >= 0.3f)
           characterController.Move(moveSpeed  * Time.deltaTime * Dir.normalized);

        characterController.Move(Vector3.down);
    }
}
