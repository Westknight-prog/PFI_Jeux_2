using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(StatsComponent))]
public class CombatComponent : MonoBehaviour
{
    StatsComponent targetStats;
    StatsComponent selfStats;
    bool isInCombat = false;
    public float radius;
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag == "Enemy")
            {
                if (!isInCombat)
                {
                    StartCombat(hitCollider.gameObject);
                }

            }

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
        Attack();
        yield return new WaitForSeconds(2f);
        StopCombat();
    }

    private void Attack()
    {
        if (targetStats.Defense <= Random.Range(1, selfStats.Accuracy))
        {
            int damage = Random.Range(1, selfStats.Attack / 3);
            targetStats.TakeDamage(damage);
            
            if(targetStats.Defense <= Random.Range(1, targetStats.Accuracy))
            {
                damage = Random.Range(1, selfStats.Attack / 3);
                selfStats.TakeDamage(damage);
            }
            else
            {
                selfStats.TakeDamage(0);
            }
        }
        else
        {
            targetStats.TakeDamage(0);
        }
    }


}
