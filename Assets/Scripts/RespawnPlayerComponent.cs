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
            playerStats.gameObject.GetComponent<NavMeshAgent>().Warp(gameObject.transform.position);
            playerStats.dead = false;
            playerStats.Heal();
        }
    }
}
