using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Subtitles : MonoBehaviour
{
    public static TMP_Text SubtitlesInstance;

    private void Awake()
    {
        if(SubtitlesInstance == null)
            SubtitlesInstance = this.GetComponent<TMP_Text>();
    }
}
