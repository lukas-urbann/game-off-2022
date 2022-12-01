using UnityEngine;

public class PlayBall : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    public void PlayCrashSound()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
