using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatsComponent))]
public class RegenComponent : MonoBehaviour
{
    StatsComponent playerStats;
    Animator playerAnimation;
    void Awake()
    {
        playerStats = GetComponent<StatsComponent>();
        StartCoroutine("RegenHealing");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RegenHealing()
    {
        while (true)
        {
            if (!playerAnimation.GetBool("isAttacking"))
            {
                playerStats.Heal(playerStats.MaxHp/20);
            }
            yield return new WaitForSeconds(5);
        }
        
    }
}
