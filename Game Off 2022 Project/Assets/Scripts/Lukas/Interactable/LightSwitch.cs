using System;
using System.Collections;
using System.Collections.Generic;
using Singletons;
using UnityEngine;

namespace Lukas.Interactable
{
    public class LightSwitch : InteractableObject
    {
        [SerializeField] private Light light;
        [SerializeField] private bool isOn = false;
        public AudioClip lightSwitch;

        protected override void PrivateInteraction()
        {
            SwitchLights();
        }

        private void SwitchLights()
        {
            SFXController.Instance.PlaySoundEffect(lightSwitch);
            isOn = !isOn;
            light.enabled = isOn;
        }
    }
}
