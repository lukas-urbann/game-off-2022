using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private void Update()
    {
        transform.LookAt(target.transform);
    }
}
