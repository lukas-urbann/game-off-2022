using UnityEngine;

public class Headbob : MonoBehaviour
{
    [SerializeField, Range(0f, 0.1f)] private float amplitude = 0.015f;
    [SerializeField, Range(0f, 30f)] private float hz = 10f;

    [SerializeField] private Transform cam;
    [SerializeField] private Transform cameraHolder;

    private float toggleSpeed = 0.3f;
    private Vector3 startPos;
    private CharacterController controller;
    private PlayerController playerController;

    private void Awake()
    {
        if (cam == null)
        {
            cam = Camera.main.transform;
            Debug.LogWarning("cam is not referenced");
        }
        controller = GetComponent<CharacterController>();
        playerController = GetComponent<PlayerController>();
        startPos = cam.localPosition;
    }

    private void Update()
    {
        CheckMotion();
        ResetPosition();
        cam.LookAt(FocusTarget());
    }


    private void CheckMotion()
    {
        Vector2 temp = playerController.GetPlayerMovement();
        float speed = new Vector3(temp.x, 0, temp.y).magnitude;

        if (speed < toggleSpeed || !controller.isGrounded) return;

        PlayMotion(FootStepMotion());
    }

    private void PlayMotion(Vector3 motion)
    {
        cam.localPosition += motion;
    }

    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * hz) * amplitude ;
        pos.x += Mathf.Cos(Time.time * hz / 2) * amplitude * 2;
        if (playerController.InputActions.FPSController.Sprint.WasPressedThisFrame())
        {
            pos.y *= 2f;
            pos.x *= 2f;
        }
        return pos;
    }

    private void ResetPosition()
    {
        if (cam.localPosition != startPos)
        {
            cam.localPosition = Vector3.Lerp(cam.localPosition, startPos, 1 * Time.deltaTime);
        }
    }

    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + cameraHolder.localPosition.y, transform.position.z);
        pos += cameraHolder.forward * 15f;
        return pos;
    }
}
