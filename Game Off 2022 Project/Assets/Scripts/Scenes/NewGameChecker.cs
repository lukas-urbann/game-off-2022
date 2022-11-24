using UnityEngine;
using UnityEngine.UI;

public class NewGameChecker : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetInt("currentLevel") != 0)
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
