using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<Ai>().Chase();
            Destroy(gameObject);
        }
    }
}
