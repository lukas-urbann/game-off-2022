using UnityEngine;
using UnityEngine.Video;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    #region Variables
    [Header("Input system")]                                                         
    [SerializeField] private Crosshair crosshair;
    private InputSystemFirstPersonControls inputActions;
    public InputSystemFirstPersonControls InputActions { get => inputActions; }   

    [Header("Player")]                           
    public float gravity = -9.81f;
    private CharacterController controller; 

    [Header("Camera")]                                       
    [SerializeField] public float lookSensitivity = 1.0f;   
    [SerializeField] private float movementSpeed = 2.0f;
    private Camera cam;
    private float xRotation = 0f;

    [Header("Movement")]
    [SerializeField] float maxStamina = 10f;
    private float currentStamina = 0f;
    private bool isExhausted = false;
    [SerializeField] private float sprintMultiplier = 2f;
    [SerializeField] private float jumpMultiplier = 2f;
    private bool grounded;  
    private Vector3 velocity;                      
    private WalkingState currentWalkingState = WalkingState.standing;

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
    private List<AudioSource> sources = new List<AudioSource>();
    VideoPlayer videoPlayer;    //smazat

    [Header("Audio sources")]
    [SerializeField] private AudioSource walkSound;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioClip walking;
    [SerializeField] private AudioClip running;
    [SerializeField] private AudioClip exhausted;

    [Header("PostFX")]
    [SerializeField] private PostProcessVolume postFx;
    private Vignette vignette;
    #endregion


    #region Unity Functions
    private void Awake()
    {
        cam = Camera.main;
        inputActions = new InputSystemFirstPersonControls();
    }

    private void Start()
    {
        postFx.profile.TryGetSettings(out vignette);

        videoPlayer = GameObject.Find("Pause menu video player").GetComponent<VideoPlayer>();    //smazat
        videoPlayer.Pause();    //smazat

        if (postFx == null)
        {
            postFx = GetComponent<PostProcessVolume>(); 
            Debug.LogWarning("postFx is not referenced");
        }
        if (menuObj == null)
        {
            menuObj = GameObject.Find("PauseUI");
            Debug.LogWarning("menuObj is not referenced");
        }
        if (walkSound == null || jumpSound == null)
        {
            AudioSource[] sources = Camera.main.GetComponents<AudioSource>();
            walkSound = sources[0];
            jumpSound = sources[1];
            Debug.LogWarning("walkSound/jumpSound is not referenced");
        }
        if (crosshair == null)
        {
            crosshair = Camera.main.GetComponent<Crosshair>();
            Debug.LogWarning("crosshair is not referenced");
        }
        
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
        if (DoPause())
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
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
        DoInteract();
        DoPostFX();
    }  
    
    private void OnDisable()
    {
        inputActions.Disable();
    }
    #endregion


    #region DoXXX
    private bool DoPause()
    {
        if (inputActions.FPSController.Pause.WasPressedThisFrame())
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
        if (grounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        Vector2 movement = GetPlayerMovement();
        Vector3 move = transform.right * movement.x + transform.forward * movement.y;

        if (movement.magnitude > 0) //if player has made an input
        {
            if (inputActions.FPSController.Sprint.ReadValue<float>() > 0f && !isExhausted)   //Sprinting
            {
                currentStamina += Time.deltaTime;
                SetWalkingState(WalkingState.running);
                controller.Move(move * movementSpeed * Time.deltaTime * sprintMultiplier);
            }
            else   //Walking
            {
                SetWalkingState(WalkingState.walking);
                controller.Move(move * movementSpeed * Time.deltaTime);
            }
        }
        else if (currentWalkingState != WalkingState.exhausted)
        {
            SetWalkingState(WalkingState.standing);
            currentStamina -= Time.deltaTime;
            if (currentStamina <= 0f)
            {
                currentStamina = 0f;
            }
        }


        if (inputActions.FPSController.Jump.WasPressedThisFrame() && grounded ) //Jumping
        {
            velocity.y += Mathf.Sqrt(jumpMultiplier * -1f * gravity);
            jumpSound.Play();
        }

        if (currentStamina >= maxStamina || isExhausted)   //stamina logic
        {
            if (currentStamina <= 0f)
            {
                isExhausted = false;
                currentStamina = 0f;
                SetWalkingState(WalkingState.standing);
            }
            else
            {
                isExhausted = true;                           
                currentStamina -= Time.deltaTime;
                SetWalkingState(WalkingState.exhausted);
            }
        }
        
        velocity.y += gravity * Time.deltaTime; //applying gravity
        controller.Move(velocity * Time.deltaTime);
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
            //controller.height = crouchHeight;
            controller.height = Mathf.Lerp(controller.height, crouchHeight, zoomSpeed * Time.deltaTime);
        }
        else
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), 2.0f, -1))
            {
                //controller.height = crouchHeight;
                controller.height = Mathf.Lerp(controller.height, crouchHeight, zoomSpeed * Time.deltaTime);
            }
            else
            {
                //controller.height = initHeight;
                controller.height = Mathf.Lerp(controller.height, initHeight, zoomSpeed * Time.deltaTime);
            }
        }
    }

    private void DoInteract()
    {
        if (inputActions.FPSController.Interact.WasPressedThisFrame() && crosshair.C_State == Crosshair.CrosshairState.interactable)
        {
            crosshair.Interactable().Interact();
        }
    }
    
    private void DoPostFX()
    {
        vignette.intensity.value = MapToRange(0f, maxStamina, 0f, 1f, currentStamina);
    }
    #endregion

           
    #region GetXXX
    /// <summary>
    /// Retuns movement input since last frame
    /// </summary>
    /// <returns></returns>
    public Vector2 GetPlayerMovement()
    {
        return inputActions.FPSController.Move.ReadValue<Vector2>();
    }

    /// <summary>
    /// Returns mouse movement since last frame
    /// </summary>
    /// <returns></returns>
    public Vector2 GetPlayerLook()
    {
        return inputActions.FPSController.Look.ReadValue<Vector2>();
    }
    #endregion


    private void UpdateZoom()
    {
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFOV, zoomSpeed * Time.deltaTime);
    }

    public void SetBaseFOV(float fov)
    {
        baseFOV = fov;
    }

    /// <summary>
    /// Pauses game
    /// </summary>
    private void PauseGame()
    {
        AudioSource[] temp = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioSource in temp)
        {
            if (audioSource.isPlaying)
            {
                sources.Add(audioSource);
            }
        }
        foreach (AudioSource audioSource in sources)
        {
            audioSource.Stop();
        }

        isPaused = true;
        menuObj.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        videoPlayer.Play();    //smazat
    }

    /// <summary>
    /// Resumes game
    /// </summary>
    public void ResumeGame()
    {
        foreach (AudioSource audioSource in sources)
        {
            audioSource.UnPause();
        }
        sources.Clear();

        isPaused = false;
        menuObj.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        videoPlayer.Pause();    //smazat
    }


    private void SetWalkingState(WalkingState walkingState)
    {
        if (walkingState != currentWalkingState)
        {
            switch (walkingState)
            {
                case WalkingState.standing:
                    walkSound.Stop();
                    walkSound.clip = null;
                    break;
                case WalkingState.walking:
                    walkSound.clip = walking;
                    walkSound.Play();
                    break;
                case WalkingState.running:
                    walkSound.clip = running;
                    walkSound.Play();
                    break;
                case WalkingState.exhausted:
                    walkSound.clip = exhausted;
                    walkSound.Play();
                    break;
                default:
                    Debug.LogError("Unknown WalkingState: " + walkingState);
                    break;
            }
            currentWalkingState = walkingState;
        }
        
    }

    private enum WalkingState
    {
        standing,
        walking,
        running,
        exhausted
    }

    /// <summary>
    /// Remaps value within range
    /// </summary>
    /// <param name="originalStart">Start of original range</param>
    /// <param name="originalEnd">End of original range</param>
    /// <param name="newStart">Start of new range</param>
    /// <param name="newEnd">End of new range</param>
    /// <param name="value">Value to be remapped</param>
    /// <returns></returns>
    public static float MapToRange(float originalStart, float originalEnd, float newStart, float newEnd, float value)
    {
        double scale = (double)(newEnd - newStart) / (originalEnd - originalStart);
        return (float)(newStart + ((value - originalStart) * scale));
    }
}
