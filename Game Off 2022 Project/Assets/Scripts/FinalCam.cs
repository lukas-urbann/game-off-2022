using UnityEngine;
using UnityEngine.Rendering.PostProcessing; 
using Scenes;

public class FinalCam : MonoBehaviour
{
    private float time = 0f;
    private bool isDrug = false;

    [Header("PostFX")]
    [SerializeField] private PostProcessVolume postFx;
    private Vignette vignette;

    private void Start()
    {
        postFx.profile.TryGetSettings(out vignette);
    }

    private void Update()
    {
        if (isDrug)
        {
            time += Time.deltaTime;
            if (time > 5f)
            {
                LoadingScreen.Instance.StartLoading("Game_Scene_5");
                isDrug = false;
            }
            vignette.intensity.value = PlayerController.MapToRange(0.406f, 1f, 0f, 5f, time);
        }
    }

    public void IsDrug()
    {
        isDrug = true;
    }
}
