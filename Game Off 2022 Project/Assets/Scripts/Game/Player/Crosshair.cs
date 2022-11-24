using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Crosshair : MonoBehaviour
{
    [Header("Cursor")]
    [SerializeField] private Image crosshair;

    [Header("Item description")]
    [SerializeField] private TMP_Text itemDescription;

    [Header("Sprites")]
    [SerializeField] private Sprite c_normal;
    [SerializeField] private Sprite c_interactable;

    [Header("Variables")]                           
    private cakeslice.Outline temp_outline;
    [SerializeField] private float reach = 2f;
    private CrosshairState c_state = CrosshairState.normal;
    public CrosshairState C_State { get => c_state; }

    private void Start()
    {
        if (crosshair == null)
        {
            Debug.LogWarning("crosshair is not referenced");
            crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
        }
        if (itemDescription == null)
        {
            Debug.LogWarning("itemDescription is not referenced");
            itemDescription = GameObject.Find("Item description").GetComponent<TMP_Text>();
        }
    }

    private void Update()
    { //Nemělo by to být ve fixed updatu ??
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
            catch
            {
                Debug.LogError("Interatcable object does not have outline script!");
            }

            try
            {
                itemDescription.text = hit.transform.GetComponent<Description>().description;
            }
            catch
            {
                itemDescription.text = "";
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
                itemDescription.text = "";
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
                temp_outline = null;
                itemDescription.text = "";
            }
        }
    }

    public Interactable Interactable()
    {
        return temp_outline.GetComponent<Interactable>();
    }

    public enum CrosshairState
    {
        normal,
        interactable
    }
}
