using UnityEngine;

namespace Scenes.Act1
{
    public class FallCam : MonoBehaviour
    {
        public GameObject player, ui;
        
        public void SwitchToPlayer()
        {
            ui.SetActive(true);
            player.SetActive(true);
            Destroy(gameObject);
        }
    }
}
