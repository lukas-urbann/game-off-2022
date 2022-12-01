using UnityEngine;
using UnityEngine.UI;

public class GameIsFinishedChecker : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt("GameIsFinshed", 0) == 0)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GameObject.Find("extra text").SetActive(false);
        }
    }
}
