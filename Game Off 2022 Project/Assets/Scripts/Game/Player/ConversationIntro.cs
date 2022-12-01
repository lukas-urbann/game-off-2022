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

    private void Update()
    {
        //z nìjakého dùvodu se furt zobrazuje ten kurzor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private IEnumerator PlayVoiceLines()
    {
        PlayNextVoiceLine();    //waking up

        yield return new WaitForSecondsRealtime(6.5f);

        PlayNextVoiceLine();    //i really should study instead of sleeping

        yield return new WaitForSecondsRealtime(3f);

        subtitle.text = "";

        yield return new WaitForSecondsRealtime(10f);

        PlayNextVoiceLine();    //door knock      

        yield return new WaitForSecondsRealtime(2f);

        PlayNextVoiceLine();    //door open

        yield return new WaitForSecondsRealtime(1.05f);

        PlayNextVoiceLine();     //mum   

        yield return new WaitForSecondsRealtime(3.8f);

        PlayNextVoiceLine();     //breaks things

        yield return new WaitForSecondsRealtime(1f);

        PlayNextVoiceLine();     //door shut

        yield return new WaitForSecondsRealtime(2f);

        PlayNextVoiceLine();     //i will lay down for a bit 

        yield return new WaitForSecondsRealtime(2f);

        audioSource.clip = null;                                    
        subtitle.text = "";
    }

    private void PlayNextVoiceLine()
    {
        //audioSource.clip = dabings.ElementAt(currentVoiceLine);
        subtitle.text = subtitles.ElementAt(currentVoiceLine);
        audioSource.PlayOneShot(dabings.ElementAt(currentVoiceLine));
        currentVoiceLine++;
    }
}
