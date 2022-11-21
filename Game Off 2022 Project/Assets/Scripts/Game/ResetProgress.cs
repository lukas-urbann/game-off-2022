using UnityEngine;

public class ResetProgress : MonoBehaviour
{
    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayeerPrefs deleted");
    }
}
