using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private void OnDisable()
    {
        PlayerController.Instance.InputActions.UI.Disable();
        PlayerController.Instance.InputActions.FPSController.Enable();
    }
    
    private void OnEnable()
    {
        PlayerController.Instance.InputActions.FPSController.Disable();
        PlayerController.Instance.InputActions.UI.Enable();
    }

    private void Update()
    {
        if (PlayerController.Instance.InputActions.UI.PauseMenu.WasPressedThisFrame())
        {
            gameObject.SetActive(false);
        }
    }
}
