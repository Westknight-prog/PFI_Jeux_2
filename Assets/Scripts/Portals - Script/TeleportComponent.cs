using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TeleportComponent : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform RedPortalEnter;
    [SerializeField] Transform BluePortalEnter;
    [SerializeField] Transform RedPortalExit;
    [SerializeField] Transform BluePortalExit;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.tag);
        if(other.transform.tag == RedPortalEnter.tag)
        {
            agent.Warp(BluePortalExit.position);
        }
        else if(other.transform.tag == BluePortalEnter.tag)
        {
            agent.Warp(RedPortalExit.position);
        }
    }
}
