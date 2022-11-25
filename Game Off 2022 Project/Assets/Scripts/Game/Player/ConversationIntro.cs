using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ConversationIntro : MonoBehaviour
{
    [SerializeField] private protected AudioSource audioSource;
    [SerializeField] private protected List<AudioClip> dabings;
    [SerializeField] private protected List<string> subtitles;
    [SerializeField] private protected TMP_Text subtitle;
    private protected int currentVoiceLine = 0;

    private void Start()
    {
        StartCoroutine(PlayVoiceLines());    
    }

    private IEnumerator PlayVoiceLines()
    {
        PlayNextVoiceLine();    //waking up

        yield return new WaitForSecondsRealtime(6.5f);

        subtitle.text = "";

        yield return new WaitForSecondsRealtime(13f);

        PlayNextVoiceLine();    //door knock      

        yield return new WaitForSecondsRealtime(2f);

        PlayNextVoiceLine();    //door open

        yield return new WaitForSecondsRealtime(1.4f);

        PlayNextVoiceLine();     //mum   

        yield return new WaitForSecondsRealtime(3.8f);

        PlayNextVoiceLine();     //breaks things

        yield return new WaitForSecondsRealtime(1f);

        PlayNextVoiceLine();     //door shut

        yield return new WaitForSecondsRealtime(2f);

        audioSource.clip = null;
        subtitle.text = "";
    }

    private void PlayNextVoiceLine()
    {
        audioSource.clip = dabings.ElementAt(currentVoiceLine);
        subtitle.text = subtitles.ElementAt(currentVoiceLine);
        audioSource.Play();
        currentVoiceLine++;
    }
}
