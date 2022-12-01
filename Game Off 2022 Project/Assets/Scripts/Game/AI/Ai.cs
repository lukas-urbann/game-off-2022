using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Ai : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameOverScreen;

    [Header("Variable")]
    [SerializeField] private float randomRange = 10f;
    [SerializeField] private float randomTimer = 10f;
    [SerializeField] private float currentTimer;
    [SerializeField] private float chaseSpeed = 2f;
    [SerializeField] private float gameOverDistance = 1.1f;
    private bool isChase = false;
    private Vector3 temp;


    [Header("Sounds")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip chase;


    public void Start()
    {
        if (navMeshAgent == null)
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            Debug.LogWarning("navMeshAgent is not referenced");
        }
        if (player == null)
        {
            player = GameObject.Find("Player");
            Debug.LogWarning("player is not referenced");
        }
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            Debug.LogWarning("audioSource is not referenced");
        }
        if (gameOverScreen == null)
        {
            gameOverScreen = GameObject.Find("GameOverScreen");
            Debug.LogWarning("gameOverScreen is not referenced");
        }

        temp = player.transform.position;
        navMeshAgent.SetDestination(temp);
    }

    private void Update()
    {
        try
        {
            if (isChase)
            {
                navMeshAgent.SetDestination(player.transform.position);
                //TODO opravit rotaci transform.LookAt(player.transform.position);
                //LookAtPlayer();
            }
            else
            {
                navMeshAgent.SetDestination(GetPointNearPlayer());
                //TODO opravit rotaci transform.LookAt(temp);    
                //LookAtPlayer();
            }
        }catch(Exception){}

        if (Vector3.Distance(transform.position, player.transform.position) <= gameOverDistance && isChase)    //gameover
        {
            player.GetComponent<PlayerController>().enabled = false;
            audioSource.Stop();
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gameOverScreen.SetActive(true);
        }
    }

    /// <summary>
    /// Selects a random point near the player                                 
    /// </summary>
    /// <returns>Random point near player</returns>
    private Vector3 GetPointNearPlayer()
    {
        if (currentTimer <= randomTimer)
        {
            currentTimer += Time.deltaTime;
        }
        else
        {
            currentTimer = 0f;

            float x = player.transform.position.x;
            float y = player.transform.position.y + 0.5f;
            float z = player.transform.position.z;

            float ranX = Random.Range(x - randomRange, x + randomRange);
            float ranZ = Random.Range(z - randomRange, z + randomRange);

            temp = new Vector3(ranX, y, ranZ);
        }
        return temp;
    }

    /// <summary>
    /// Looks at player
    /// </summary>
    private void LookAtPlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2f);
    }

    /// <summary>
    /// Player has been seen by the AI
    /// </summary>
    public void Chase()
    {
        isChase = true;
        navMeshAgent.speed += chaseSpeed;
        audioSource.clip = chase;
        audioSource.Play();
    }
}
