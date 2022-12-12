using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class behaviourTree
{
    

    
}

public enum NodeState
{
    Running,
    Success,
    Failure
}

public abstract class Node
{
    protected NodeState state { get; set; } = NodeState.Running;

    public Node parent { get; set; } = null;

    protected List<Node> children = new();

    Dictionary<string, object> data = new Dictionary<string, object>();

    public void SetData(string key, object value)
    {
        data[key] = value;
    }

    public object GetData(string key)
    {
        if (data.TryGetValue(key, out object value))
            return value;
        if(parent != null)
            return parent.GetData(key);

        return null;
    }

    public bool RemoveData(string key)
    {
        if (data.Remove(key))
        {
            return true;
        }
            
        if (parent != null)
            return parent.RemoveData(key);

        return false;
    }

    protected Node()
    {
    }

    protected Node(List<Node> children)
    {
        foreach (Node n in children)
        {
            Attach(n);
        }
    }

    protected void Attach(Node n)
    {
        n.parent = this;
        children.Add(n);
    }

    abstract public NodeState Evaluate();
}

public class Selector : Node // arrete au premier retour de success
{
    public  Selector(List<Node> n ) : base(n) { }
    
    public override NodeState Evaluate()
    {
        state = NodeState.Failure;
        foreach(Node node in this.children)
        {
            switch(node.Evaluate())
            {
                case NodeState.Failure:
                    continue;
                case NodeState.Success:
                    state = NodeState.Success;
                    return state;
                case NodeState.Running:
                    state = NodeState.Running;
                    return state;
            }
        }
        return state; 
    }
}

public class Sequence : Node // doit etre success pour passez au prochain node/leaf
{
    public Sequence(List<Node> n) : base(n) { }

    public override NodeState Evaluate()
    {
        state = NodeState.Success;
        foreach (Node node in this.children)
        {
            switch (node.Evaluate())
            {
                case NodeState.Success:
                    continue;
                case NodeState.Failure:
                    state = NodeState.Failure;
                    return state;
                case NodeState.Running:
                    state = NodeState.Running;
                    return state;
            }
        }
        return state;
    }
}


public class Inverter : Node
{
    public Inverter(Node n)
    {
        Attach(n);
    }

    public override NodeState Evaluate()
    {
        foreach (Node node in this.children)
        {
            switch (node.Evaluate())
            {
                case NodeState.Success:
                    state = NodeState.Failure;
                    break;
                case NodeState.Failure:
                    state = NodeState.Success;
                    break;
                case NodeState.Running:
                    state = NodeState.Running;
                    break;
            }
        }
        return state;
    }
}

public class PatrolTask : Node
{
    Transform[] destinations;
    float waitTime;
    float elapsedTime = 0;
    int destinationIndex = 0;
    bool isWaiting = false;
    NavMeshAgent agent;
    Animator animator;

    public PatrolTask(Transform[] destinations, float waitTime, NavMeshAgent agent, Animator animator)
    {
        this.destinations = destinations;
        this.waitTime = waitTime;
        this.agent = agent;
        this.animator = animator;
    }

    public override NodeState Evaluate()
    {
        animator.SetBool("isAttacking", false);
        if (isWaiting)
        {
            animator.SetBool("isWalking", false);
            elapsedTime += Time.deltaTime;
            if(elapsedTime > waitTime)
            {
                isWaiting = false;
            }
        }
        else
        {
            if (Vector3.Distance(agent.transform.position, destinations[destinationIndex].position) < agent.stoppingDistance)
            {
                destinationIndex = (destinationIndex + 1) % destinations.Length;
                isWaiting = true;
                elapsedTime = 0;
            }
            else
            {
                agent.destination = destinations[destinationIndex].position;
            }
            animator.SetBool("isWalking", true);
        }

        state = NodeState.Running;
        return state;
    }
}

public class EnemyDetected : Node
{
    NavMeshAgent[] enemies;
    NavMeshAgent agent;
    float detectionDistance, smallestDistance;
    bool enemyDectected = false;

    public EnemyDetected(NavMeshAgent[] enemies, NavMeshAgent agent, float detectionDistance = 5)
    {
        this.enemies = enemies;
        this.agent = agent;
        this.detectionDistance = detectionDistance;
        this.smallestDistance = detectionDistance;
    }

    public override NodeState Evaluate()
    {
        int targetIndex = -1;
        for (int i=0; i< enemies.Length; i++)
        {
            float distance = Vector3.Distance(agent.transform.position, enemies[i].transform.position);
            if (distance < detectionDistance && distance < smallestDistance)
            {
                targetIndex = i;
            }
        }

        if(targetIndex == -1)
        {
            state = NodeState.Failure;
            return state;
        }

        parent.SetData("target",enemies[targetIndex].transform.position);
        state = NodeState.Success;
        return state;

        
    }
}

public class Chase : Node
{
    NavMeshAgent agent;
    Animator animator;

    public Chase(NavMeshAgent agent, Animator animator)
    {
        this.agent = agent;
        this.animator = animator;
    }

    public override NodeState Evaluate()
    {
        Vector3 enemy = (Vector3)parent.GetData("target");
        if (enemy != null && Vector3.Distance(agent.transform.position, enemy) < agent.stoppingDistance)
        {
            animator.SetBool("isWalking", false);
            state = NodeState.Success;
            return state;
        }
        else if (enemy != null)
        {
            agent.destination = enemy;
            animator.SetBool("isWalking", true);
            state = NodeState.Running;
            return state;
        }
        state = NodeState.Failure;
        return state;
    }
}

public class Attack : Node 
{
    NavMeshAgent agent;
    Animator animator;

    public Attack(NavMeshAgent agent, Animator animator)
    {
        this.agent = agent;
        this.animator = animator;
    }

    public override NodeState Evaluate()
    {
        Vector3 enemy = (Vector3)parent.GetData("target");
        if (enemy != null && Vector3.Distance(agent.transform.position, enemy) < agent.stoppingDistance)
        {
            agent.transform.LookAt(enemy);
            animator.SetBool("isAttacking", true);
            state = NodeState.Running;
            return state;
        }
        state = NodeState.Failure;
        return state;
    }
}