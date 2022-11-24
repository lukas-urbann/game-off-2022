using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen = false;
    [SerializeField, Tooltip("Determines whether the door is locked or can be opened")] private bool isLocked = false;
    [SerializeField, Tooltip("Determines whether the door opens in or out")] private bool inwards = false;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip unlocked;
    [SerializeField] private AudioClip locked;

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            Debug.LogWarning("audioSource is not referenced");
        }
    }

    /// <summary>
    /// Opens/closes door
    /// </summary>
    public void Rotate()
    {
        if (isLocked)
        {
            audioSource.clip = locked;
        }
        else
        {
            audioSource.clip = unlocked;
            if (isOpen)
            {
                isOpen = false;
                if (inwards)
                {
                    gameObject.transform.Rotate(0f, 0f, 90f, Space.Self);
                }
                else
                {
                    gameObject.transform.Rotate(0f, 0f, -90f, Space.Self);
                }
            }
            else
            {
                isOpen = true;
                if (inwards)
                {
                    gameObject.transform.Rotate(0f, 0f, -90f, Space.Self);
                }
                else
                {
                    gameObject.transform.Rotate(0f, 0f, 90f, Space.Self);
                }
            }
        }
        audioSource.Play();
    }
}