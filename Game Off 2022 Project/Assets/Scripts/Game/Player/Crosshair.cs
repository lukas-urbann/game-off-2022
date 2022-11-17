using UnityEngine;
using UnityEngine.UI;
using cakeslice;

public class Crosshair : MonoBehaviour
{
    [Header("Cursor")]
    [SerializeField] private Image crosshair;

    [Header("Sprites")]
    [SerializeField] private Sprite c_normal;
    [SerializeField] private Sprite c_interactable;

    [Header("Variables")]                           
    public cakeslice.Outline temp_outline;
    [SerializeField] private float reach = 5f;
    private CrosshairState c_state = CrosshairState.normal;
    private CrosshairState C_State { get => c_state; }

    private void Start()
    {
        if (crosshair == null)
        {
            Debug.LogWarning("Crosshair is not referenced");
            crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
        }    
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, reach))
        {
            try
            {
                if (hit.transform.gameObject.CompareTag("Object"))
                {
                    UpdateUI(true, hit.transform.GetComponent<cakeslice.Outline>());
                }
                else
                {
                    UpdateUI(false, hit.transform.GetComponent<cakeslice.Outline>());
                }
            }
            catch (System.Exception)
            {
            }

        }
        else
        {
            UpdateUI(false);
        }
    }

    /// <summary>
    /// Updates crosshair, if needed
    /// </summary>
    /// <param name="interactable">Is interactable item in reach?</param>
    private void UpdateUI(bool interactable, cakeslice.Outline outline)
    {
        if (outline != null)
        {
            temp_outline = outline;
        }
        if (interactable)
        {
            if (c_state != CrosshairState.interactable)
            {
                temp_outline.eraseRenderer = false;
                c_state = CrosshairState.interactable;
                crosshair.sprite = c_interactable;
            }
        }
        else
        {
            if (c_state != CrosshairState.normal)
            {
                temp_outline.eraseRenderer = true;
                c_state = CrosshairState.normal;
                crosshair.sprite = c_normal;
            }
        }
    }
    /// <summary>
    /// Updates crosshair, if needed
    /// </summary>
    private void UpdateUI(bool interactable)
    {
        if (interactable)
        {
            if (c_state != CrosshairState.interactable)
            {
                c_state = CrosshairState.interactable;
                crosshair.sprite = c_interactable;
            }
        }
        else
        {
            if (c_state != CrosshairState.normal)
            {
                c_state = CrosshairState.normal;
                crosshair.sprite = c_normal;
                temp_outline.eraseRenderer = true;
            }
        }
    }

    private enum CrosshairState
    {
        normal,
        interactable
    }
}
