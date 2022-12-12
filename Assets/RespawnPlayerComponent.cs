using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RespawnPlayerComponent : MonoBehaviour
{
    StatsComponent playerStats;
    void Awake()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<StatsComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.dead)
        {
            playerStats.gameObject.transform.position = gameObject.transform.position;
            playerStats.gameObject.GetComponent<NavMeshAgent>().destination = gameObject.transform.position;
            playerStats.Heal();
        }
    }
}
