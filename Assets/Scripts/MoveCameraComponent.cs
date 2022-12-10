using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraComponent : MonoBehaviour
{

    float height = 5f;
    float distance = 5f;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v3 = player.transform.position;
        v3.y += height;
        v3.z += distance;
        transform.LookAt(player.transform);
        transform.position = v3;
    }
}
