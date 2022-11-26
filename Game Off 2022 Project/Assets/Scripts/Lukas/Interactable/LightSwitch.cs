using Singletons;
using UnityEngine;

namespace Lukas.Interactable
{
    public class LightSwitch : InteractableObject, IInteractableObject
    {
        [SerializeField] private Light light;
        [SerializeField] private bool isOn = false;
        public AudioClip lightSwitch;

        public override void PrivateInteraction()
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
