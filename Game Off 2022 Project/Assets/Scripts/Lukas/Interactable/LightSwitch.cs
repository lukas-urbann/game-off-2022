using Singletons;
using UnityEngine;

namespace Lukas.Interactable
{
    public class LightSwitch : InteractableObject, IInteractableObject
    {
        [SerializeField] private Light lightSource;
        [SerializeField] private bool isOn = false;
        public AudioClip lightSwitch;

        public override void PrivateInteraction()
        {
            SwitchLights();
        }

        private void SwitchLights()
        {
            SFXController.Instance.PlaySoundEffectOneShot(lightSwitch);
            isOn = !isOn;
            lightSource.enabled = isOn;
        }
    }
}
