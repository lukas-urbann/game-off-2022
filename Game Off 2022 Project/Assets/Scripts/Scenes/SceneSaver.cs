using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSaver : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("currentLevel", SceneManager.GetActiveScene().buildIndex);
    }
}
