using Scenes;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PriVlezeniMePosliNaDalsiLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("EventSystem").GetComponent<LoadingScreen>().StartLoading(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
