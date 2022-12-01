using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lukas.Scene.Act5
{
    public class AndrewTate : MonoBehaviour
    {
        //dont care quality code or solid principles, gotta speedrun
        private bool talking;
        private Animator anim;
        public Animator pillsAnim;
        public GameObject secretEnding;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void TriggerAndrew()
        {
            StartCoroutine(pills());
            SwitchTalkingState();
        }

        private void SwitchTalkingState()
        {
            talking = !talking;

            if (talking)
                anim.Play("TateSpeak");
            else
                anim.Play("TateIdle");
        }

        private IEnumerator pills()
        {
            yield return new WaitForSeconds(70);
            pillsAnim.Play("PillsFly");
            SwitchTalkingState();
            StartCoroutine(SecretEnding());
        }

        private IEnumerator SecretEnding()
        {
            yield return new WaitForSeconds(500);
            secretEnding.SetActive(true);
            StartCoroutine(Prank());
        }

        private IEnumerator Prank()
        {
            yield return new WaitForSeconds(10);
            Application.Quit(69);
        }
    }
}
