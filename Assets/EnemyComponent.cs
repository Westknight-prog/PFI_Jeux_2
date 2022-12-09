using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(StatsComponent))]
public class EnemyComponent : MonoBehaviour
{
    StatsComponent selfStats;
    bool respawning = false;
    
    void Awake()
    {
        selfStats = GetComponent<StatsComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDisable()
    {
        
    }
    private void OnEnable()
    {
        selfStats.CurrentHp = selfStats.MaxHp;
    }

    
}
