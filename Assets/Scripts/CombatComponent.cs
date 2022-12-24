using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(StatsComponent))]
public class CombatComponent : MonoBehaviour
{
    Animator playerAnimator;
    StatsComponent targetStats;
    StatsComponent selfStats;
    bool isInCombat = false;
    public float radius;
    void Awake()
    {
        playerAnimator = GetComponent<Animator>();
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
            playerAnimator.SetBool("isAttacking", false);
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
        playerAnimator.SetBool("isAttacking", true);
        selfStats.gameObject.transform.LookAt(targetStats.transform);

        if (targetStats.Defence <= Random.Range(1, selfStats.Accuracy))
        {
            targetStats.TakeDamage(Random.Range(1, selfStats.Attack / 3));
        }
        else
        {
            targetStats.TakeDamage(0);
        }

        if (selfStats.Defence <= Random.Range(1, targetStats.Accuracy))
        {
            selfStats.TakeDamage(Random.Range(1, targetStats.Attack / 3));
        }
        else
        {
            selfStats.TakeDamage(0);
        }
    }


}
