using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class InputSystemFirstPersonCharacter : MonoBehaviour
{
    [Header("Input system")]
    [SerializeField] private InputSystemFirstPersonControls inputActions;

    private CharacterController controller;
    private Rigidbody rb;

    [Header("Camera")]
    [SerializeField] private Camera cam;
    [SerializeField] private float movementSpeed = 2.0f;
    [SerializeField] public float lookSensitivity = 1.0f;
    
    private float xRotation = 0f;

    [Header("Movement")]
    public float gravity = -9.81f;
    [SerializeField] private float sprintMultiplier = 2f;
    [SerializeField] private float jumpMultiplier = 2f;
    private bool grounded;  
    private Vector3 velocity;

    [Header("FOV")]
    public float zoomFOV = 35.0f;
    public float zoomSpeed = 9f;
    private float targetFOV;
    private float baseFOV;

    [Header("Crouch")]
    [SerializeField] private float crouchHeight;
    private float initHeight;

    [Header("Pause")]
    [SerializeField] private GameObject menuObj;
    private bool isPaused = false;

    private void Awake()
    {
        inputActions = new InputSystemFirstPersonControls();
    }

    private void Start()
    {
        if (menuObj == null)
        {
            menuObj = GameObject.Find("PauseUI");
        }
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        initHeight = controller.height;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SetBaseFOV(cam.fieldOfView);
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void Update()
    {
        if (!DoPause())
        {
            if (isPaused)
            {
                menuObj.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                menuObj.SetActive(true);
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
        if (isPaused)
        {
            return;
        }
        DoMovement();
        DoLooking();
        DoZoom();
        DoCrouch();
    }

    private bool DoPause()
    {
        if (inputActions.FPSController.Jump.IsPressed())
        {
            return true;
        }
        return false;
    }

    private void DoLooking()
    {
        Vector2 looking = GetPlayerLook();
        float lookX = looking.x * lookSensitivity * Time.deltaTime;
        float lookY = looking.y * lookSensitivity * Time.deltaTime;

        xRotation -= lookY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        transform.Rotate(Vector3.up * lookX);
    }

    private void DoMovement()
    {
        grounded = controller.isGrounded;
        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector2 movement = GetPlayerMovement();
        Vector3 move = transform.right * movement.x + transform.forward * movement.y;
        if (inputActions.FPSController.Sprint.ReadValue<float>() > 0)
        {
            controller.Move(move * movementSpeed * Time.deltaTime * sprintMultiplier);
        }
        else
        {
            controller.Move(move * movementSpeed * Time.deltaTime);
        }

        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); 
        if (inputActions.FPSController.Jump.IsPressed() && grounded)
        {
            controller.Move(Vector3.up * jumpMultiplier * Time.deltaTime);
            //rb.AddForce(Vector3.up * jumpMultiplier, ForceMode.Impulse);
        }
    }

    private void DoZoom()
    {
        if (inputActions.FPSController.Zoom.ReadValue<float>() > 0)
        {
            targetFOV = zoomFOV;
        }
        else
        {
            targetFOV = baseFOV;
        }
        UpdateZoom();
    }

    private void DoCrouch()
    {
        if (inputActions.FPSController.Crouch.ReadValue<float>() > 0)
        {
            controller.height = crouchHeight;
        }
        else
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), 2.0f, -1))
            {
                controller.height = crouchHeight;
            }
            else
            {
                controller.height = initHeight;
            }
        }
    }

    private void UpdateZoom()
    {
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFOV, zoomSpeed * Time.deltaTime);
    }

    public void SetBaseFOV(float fov)
    {
        baseFOV = fov;
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return inputActions.FPSController.Move.ReadValue<Vector2>();
    }

    public Vector2 GetPlayerLook()
    {
        return inputActions.FPSController.Look.ReadValue<Vector2>();
    }
}
