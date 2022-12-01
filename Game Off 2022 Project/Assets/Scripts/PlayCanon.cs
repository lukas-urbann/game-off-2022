using UnityEngine;

public class PlayCanon : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shoot;
    [SerializeField] private AudioClip launch;

    public void PlayLaunchSound()
    {
        audioSource.clip = launch;
        audioSource.Play();
    }
    public void PlayShootSound()
    {
        audioSource.clip = shoot;
        audioSource.Play();
    }
}
