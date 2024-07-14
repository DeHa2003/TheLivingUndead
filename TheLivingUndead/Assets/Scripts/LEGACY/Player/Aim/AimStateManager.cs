using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AimStateManager : MonoBehaviour
{
    public MultiAimConstraint aimConstraintRHand;
    public TwoBoneIKConstraint twoBoneIKConstraintLHand;

    public AimIdleState idleState = new AimIdleState();
    public AimState aimState = new AimState();
    private AimBaseState currentState;

    [SerializeField] private float mouseSense = 1;
    private float xAxis, yAxis;
    [SerializeField] private Transform followPos;

    [SerializeField] private Transform aimPos;
    [SerializeField] private float aimSmoothSpeed;
    [SerializeField] private LayerMask aimMask;

    public Animator Animator { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        Animator = GetComponent<Animator>();
        SwitchState(idleState);
    }

    public void SwitchState(AimBaseState aimBaseState)
    {
        currentState = aimBaseState;
        currentState?.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        xAxis += Input.GetAxisRaw("Mouse X") * mouseSense;
        yAxis += Input.GetAxisRaw("Mouse Y") * mouseSense;
        yAxis = Mathf.Clamp(yAxis, -80, 80);

        Vector2 cscreenCentre = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(cscreenCentre);

        if(Physics.Raycast(ray, out RaycastHit hit, aimMask))
        {
            aimPos.position = Vector3.Lerp(aimPos.position, hit.point, aimSmoothSpeed * Time.deltaTime);
        }

        currentState?.UpdateState(this);
    }

    private void LateUpdate()
    {
        followPos.localEulerAngles = new Vector3(yAxis, followPos.localEulerAngles.y, followPos.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z);
    }
}
