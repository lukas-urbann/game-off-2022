using System;
using System.Collections;
using System.Collections.Generic;
using Singletons;
using TMPro;
using UnityEngine;
using static Subtitles;

namespace Lukas.Story
{
    public class Dialogue : MonoBehaviour
    {
        private int index = 0;
        [SerializeField] private List<AudioClip> audioLogs;
        [SerializeField] private List<string> subtitles;
        private List<float> timeSeparation = new List<float>();

        private void GenerateAutomaticDisplayTime()
        {
            timeSeparation.Capacity = audioLogs.Count;

            foreach (AudioClip audioLog in audioLogs)
                timeSeparation.Add(audioLog.length);
        }

        private void Start()
        {
            GenerateAutomaticDisplayTime();
        }

        public void BeginDialogue()
        {
            DisplayDialogue();
        }

        private IEnumerator DialogueAdvance(float seconds)
        {
            index++;
            yield return new WaitForSeconds(seconds);
            DisplayDialogue();
        }

        private IEnumerator HideSubtitles(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            SubtitlesInstance.text = "";
            
            if ((index) == audioLogs.Count)
                this.enabled = false;
        }

        private void DisplayDialogue()
        {
            if ((index) == audioLogs.Count)
            {
                StartCoroutine(HideSubtitles(1));
                return;
            }
            
            SubtitlesInstance.text = subtitles[index];
            SFXController.Instance.PlaySoundEffect(audioLogs[index]);
            StartCoroutine(DialogueAdvance(timeSeparation[index]));
        }
    }
}
