using Lukas.Triggers;
using UnityEngine;

public class UnityMoment : MonoBehaviour
{
    private BoxCollider b;
    private StartDialogueTrigger t;

    private void Start()
    {
        b = GetComponent<BoxCollider>();
        t = GetComponent<StartDialogueTrigger>();
    }

    private void Update()
    {
        if (t.pomoc)
        {
            Destroy(gameObject, 4f);
        }
        else
        {
            b.enabled = true;
        }
    }

    private void LateUpdate()
    {
        if (t.pomoc)
        {
            Destroy(gameObject, 4f);
        }
        else
        {
            b.enabled = true;
        }
    }
}
