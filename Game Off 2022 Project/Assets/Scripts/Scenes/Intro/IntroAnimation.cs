using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes.Intro
{
    public class IntroAnimation : MonoBehaviour
    {
        [SerializeField] private int animatorIndex = 0;
        [SerializeField] private Animator[] anims;

        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void OnEnable()
        {
            foreach (Animator anim in anims)
                anim.enabled = false;
        }

        public void TriggerNextAnimator()
        {
            anims[animatorIndex].enabled = true;
            animatorIndex++;
        }
    }
}
