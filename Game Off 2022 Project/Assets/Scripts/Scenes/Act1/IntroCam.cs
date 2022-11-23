using UnityEngine;

namespace Scenes.Act1
{
    public class IntroCam : MonoBehaviour
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
