using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawnComponent : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    bool respawning = false;
    StatsComponent enemyStats;
    void Awake()
    {
        enemyStats = enemy.GetComponent<StatsComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyStats.dead)
        {
            Respawn();   
        }
    }
    public void Respawn()
    {
        if (!respawning)
        {
            StartCoroutine("timerRespawn");
        }

    }
    IEnumerator timerRespawn()
    {
        respawning = true;
        enemy.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        enemy.transform.position = gameObject.transform.position;
        enemy.gameObject.SetActive(true);
        respawning = false;
    }
}
