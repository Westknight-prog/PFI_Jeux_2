using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(StatsComponent))]
public class CombatComponent : MonoBehaviour
{
    StatsComponent targetStats;
    StatsComponent selfStats;
    bool isInCombat = false;
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<StatsComponent>().TakeDamage(1);
        }
    }


    public void StartCombat(GameObject target)
    {
        if (!isInCombat)
        {
            targetStats = target.GetComponent<StatsComponent>();
            selfStats = GetComponent<StatsComponent>();
            isInCombat = true;
            StartCoroutine("Combat");
        }
       
    }
    public void StopCombat()
    {
        if (isInCombat)
        {
            isInCombat = false;
            targetStats = null;
            StopCoroutine("Combat");
        }

    }
    IEnumerator Combat()
    {
        while (isInCombat)
        {
            Attack();
            yield return new WaitForSeconds(2f);
        }
    }

    private void Attack()
    {
        if (targetStats.Defense / 3 <= Random.Range(1, selfStats.Accuracy / 3))
        {
            Debug.Log("Hit de " + Random.Range(1, selfStats.Attack/3));
        }
        else
        {
            Debug.Log("Miss");
        }
    }


}
