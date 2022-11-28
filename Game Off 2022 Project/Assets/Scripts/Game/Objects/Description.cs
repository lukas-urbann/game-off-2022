using UnityEngine;

public class Description : MonoBehaviour
{
    public string description = "Description is not filled in yet!";

    private void Awake()
    {
        if (!gameObject.CompareTag("Object"))
        {
            Debug.LogWarning(gameObject.name + " does not have tag Object");
        }
    }
}
