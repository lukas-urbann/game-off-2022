using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]                           
public class PlayerPrefsDebug : MonoBehaviour
{                               
    [MenuItem("PlayerPrefs/Delete all playerprefs")]
    static void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayeerPrefs deleted");
    }

    [MenuItem("PlayerPrefs/Give radio and fleshlight")]
    static void GiveRadioAndFlashlight()
    {
        PlayerPrefs.SetInt("Radios", 1);
        PlayerPrefs.SetInt("Baterkos", 1);
        Debug.Log("Radio and flashlight given");
    }
}
