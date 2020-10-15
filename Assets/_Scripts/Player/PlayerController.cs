using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float sensitivity = 500f;
    [SerializeField] private float Gravity = -15;
    [SerializeField] private float walkSpeed = 6;
    [SerializeField] private float crouchSpeed = 2;
    [SerializeField] private float sprintSpeed = 2;
    [SerializeField] private KeyCode crouchKey;
    [SerializeField] private KeyCode sprintKey;
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.15f;

    public Camera PlayerCamera;
    public bool isSprinting;
    public bool isCrouching;
    public bool isStill;

    private float YVelocity;
    private CharacterController controller;
    private float currentSpeed;
    private float maxRot = 0f;
    private Vector2 currentDirection = Vector2.zero;
    private Vector2 currentDirectionVelocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MovementSpeedInput();
        MouseUpdate();
        MovementUpdate();

        
        currentSpeed = walkSpeed;
        
            
        
    }
    private void MovementUpdate()
    {
        Vector2 targetDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDirection.Normalize();

        currentDirection = Vector2.SmoothDamp(currentDirection, targetDirection, ref currentDirectionVelocity, moveSmoothTime);

        if (controller.isGrounded)
            YVelocity = 0f;
        YVelocity += Gravity * Time.deltaTime;
       
        Vector3 velocity = (transform.forward * currentDirection.y + transform.right * currentDirection.x) * currentSpeed + Vector3.up * YVelocity;
     
        controller.Move(velocity * Time.deltaTime);
    }
    private void MouseUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        maxRot -= mouseY;
        maxRot = Mathf.Clamp(maxRot, -90f, 90f);

        PlayerCamera.transform.localRotation = Quaternion.Euler(maxRot, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
    private void MovementSpeedInput()
    {
        if (Input.GetKey(crouchKey) && !isSprinting) 
        {
            currentSpeed = crouchSpeed;
            isCrouching = true;
        } else { isCrouching = false; }
        if (Input.GetKey(sprintKey) && !isCrouching && Input.GetKey(KeyCode.W))
        {
            currentSpeed = sprintSpeed;
            isSprinting = true;
        } else { isSprinting = false; }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            isStill = false;
        } else { isStill = true; }
    }
}
