using UnityEngine;

public class LastCutscene : MonoBehaviour
{
    [SerializeField] private Transform finalCam;
    [SerializeField] private CharacterController playerCol;
    [SerializeField] private Rigidbody playerRb;
    public bool lerp = false;

    private void Update()
    {
        if (lerp)
        {
            playerCol.enabled = false;
            playerRb.mass = 0;
            playerRb.useGravity = false;
            transform.LerpTransform(finalCam, Time.deltaTime);
            if (Vector3.Distance(transform.position, finalCam.position) <= 0.5f)
            {
                finalCam.gameObject.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    } 
}

public static class Helper
{
    /// <summary>
    /// Smoothly transforms an object to given location and position
    /// </summary>
    /// <param name="t1">Object to be transformed</param>
    /// <param name="t2">Destination</param>
    /// <param name="t">Time scale</param>
    public static void LerpTransform(this Transform t1, Transform t2, float t)
    {
        t1.position = Vector3.Lerp(t1.position, new Vector3(8.366f, 2.9f, 39.797f), t);
        t1.rotation = Quaternion.Lerp(t1.rotation, t2.rotation, t);
        //t1.localScale = Vector3.Lerp(t1.localScale, t2.localScale, t);
    }
}