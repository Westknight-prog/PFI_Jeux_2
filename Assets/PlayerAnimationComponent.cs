using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimationComponent : MonoBehaviour
{
    bool changed;
    NavMeshAgent player;
    Animator playerAnimator;
    void Awake()
    {
        player = GetComponent<NavMeshAgent>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerAnimator.SetBool("IsWalking",(transform.position - player.destination).magnitude > 1);
    }
}
