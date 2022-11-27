using System;
using System.Collections;
using System.Collections.Generic;
using Singletons;
using UnityEngine;

namespace Lukas.Triggers
{
    public class Jumpscare : TriggerZone, ITriggerZone
    {
        public GameObject jumpscare;
        public AudioClip scare;

        private void Start()
        {
            jumpscare.SetActive(false);
        }

        public override void PrivateInteractionEnter()
        {
            StartCoroutine(Appear());
            SFXController.Instance.PlaySoundEffect(scare);
        }

        private IEnumerator Appear()
        {
            jumpscare.SetActive(true);
            yield return new WaitForSeconds(0.15f);
            jumpscare.SetActive(false);
        }
    }
}

