using Lukas.Story;
using UnityEngine;

public class FinalBench : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Dialogue>().BeginDialogue();
        }
    }
}
