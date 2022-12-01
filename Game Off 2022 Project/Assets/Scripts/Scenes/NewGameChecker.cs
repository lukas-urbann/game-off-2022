using UnityEngine;
using UnityEngine.UI;

public class NewGameChecker : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt("currentLevel", 0) == 0)
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
