using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Vector3 player;

    public void Start()
    {
        if (navMeshAgent == null)
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            Debug.LogWarning("navMeshAgent is not referenced");
        }
        if (player == null)
        {
            player = GameObject.Find("Player").transform.position;
            Debug.LogWarning("player is not referenced");
        }
    }

    private void Update()
    {
        navMeshAgent.SetDestination(player);
    }
}
