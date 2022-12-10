using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMoveComponent : MonoBehaviour
{
    const float CLOUDS_SPAWNER_X = -40f;
    float Speed;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(MoveFoward());
        Speed = Random.Range(0.01f, 0.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 100)
        {
            transform.position = new Vector3(CLOUDS_SPAWNER_X, transform.position.y, transform.position.z);
        }
    }

    IEnumerator MoveFoward()
    {
        while (true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
            yield return new WaitForEndOfFrame();
        }
    }
}
