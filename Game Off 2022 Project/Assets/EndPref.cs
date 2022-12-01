using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPref : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("GameIsFinshed", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
