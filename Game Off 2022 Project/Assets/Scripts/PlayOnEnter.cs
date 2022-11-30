using UnityEngine;

public class PlayOnEnter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {                            
            AudioSource a = GetComponent<AudioSource>();
            if (!a.isPlaying)
            {
                a.Play();
            }
        }
    }
}
