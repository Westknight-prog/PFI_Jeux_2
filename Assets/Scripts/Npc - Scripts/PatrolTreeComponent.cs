using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PatrolTreeComponent : MonoBehaviour
{
    [SerializeField] NavMeshAgent[] enemies;
    [SerializeField] Transform[] destinations;
    [SerializeField] float waitTime = 2;
    [SerializeField] Animator animator;
    [SerializeField] float DetectionDistance = 5;
    NavMeshAgent agent;
    Node root, tryDetectChase, enemyDetected, patrolTask, chase;
    

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        
        SetupTree();
    }

    private void SetupTree()
    {
        //enemyDetected = new EnemyDetected(enemies, agent);
        //enemyDetected.parent = tryDetectChase;
        //patrolTask = new PatrolTask(destinations, waitTime, agent);
        //patrolTask.parent = root;
        //chase = new Chase(agent);
        //chase.parent = tryDetectChase;
        //tryDetectChase = new Sequence(new List<Node>() { enemyDetected, chase });
        //tryDetectChase.parent = root;
        //root = new Selector(new List<Node>(){ tryDetectChase, patrolTask });

        root = new Selector(new List<Node>()
        {
            new Sequence(new List<Node>()
            {
                new EnemyDetected(enemies, agent, DetectionDistance),
                new Chase(agent, animator),
                new Attack(agent, animator)
            }),
            new PatrolTask(destinations, waitTime, agent, animator)
        }) ;
    }

    // Update is called once per frame
    void Update()
    {
        root.Evaluate();
    }
}
