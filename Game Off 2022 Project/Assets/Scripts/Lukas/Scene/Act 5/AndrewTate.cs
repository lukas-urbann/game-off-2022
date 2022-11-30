using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lukas.Scene.Act5
{
    public class AndrewTate : MonoBehaviour
    {
        private bool talking;
        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void SwitchTalkingState()
        {
            talking = !talking;
            
            if(talking)
                anim.StartPlayback();
            else
                anim.StopPlayback();
        }
    }
}
