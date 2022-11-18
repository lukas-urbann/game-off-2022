using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]                           
public class PlayerPrefsReset : MonoBehaviour
{                               
    [MenuItem("PlayerPrefs/Delete all playerprefs")]
    static void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayeerPrefs deleted");
    }
}
