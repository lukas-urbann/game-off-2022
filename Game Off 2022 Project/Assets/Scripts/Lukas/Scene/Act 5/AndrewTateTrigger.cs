using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lukas.Scene.Act5
{
    public class AndrewTateTrigger : MonoBehaviour
    {
        public AndrewTate lmao;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                lmao.TriggerAndrew();
                gameObject.SetActive(false);
            }
        }
    }
}