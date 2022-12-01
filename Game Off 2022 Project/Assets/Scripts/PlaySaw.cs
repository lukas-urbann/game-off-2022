using UnityEngine;

public class PlaySaw : MonoBehaviour
{
    [SerializeField] private GameObject screen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            screen.SetActive(true);
        }
    }
}
