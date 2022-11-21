using Discord;
using UnityEngine;

public class DiscordController : MonoBehaviour
{
    private long applicationID = 1042881884650229800;
    private string details = "Very scary game";
    private string state = "Menu";
    private string largeImage = "icon";
    private string largeText = "Scary Horror Game";

    private long time;

    private static bool instanceExists;
    private Discord.Discord discord;

    private void Awake()
    {
        if (!instanceExists)
        {
            instanceExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        try
        {
            discord = new Discord.Discord(applicationID, (ulong)CreateFlags.NoRequireDiscord);
        }
        catch (ResultException)
        {
            Debug.Log("Discord is not running");
            Destroy(gameObject);
        }

        time = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();

        UpdateStatus();
    }

    private void Update()
    {
        try
        {
            discord.RunCallbacks();
        }
        catch
        {
            Debug.Log("Discord is not running");
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        UpdateStatus();
    }

    private void UpdateStatus()
    {
        try
        {
            var activityManager = discord.GetActivityManager();
            var activity = new Discord.Activity
            {
                Details = details,
                State = state,
                Assets =
                {
                    SmallImage = state.ToLower(),
                    SmallText= state,
                    LargeImage = largeImage.ToLower(),
                    LargeText = largeText
                },
                Timestamps =
                {
                    Start = time
                }
            };

            activityManager.UpdateActivity(activity, (res) =>
            {
                if (res != Discord.Result.Ok)
                {
                    Debug.LogWarning("Discord not respoding");
                }
            });
        }
        catch
        {
            Debug.Log("Discord is not running");
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Sets Discord status
    /// </summary>
    /// <param name="status">Current level</param>
    public void SetStatus(string status)
    {
        state = status;
    }
}
