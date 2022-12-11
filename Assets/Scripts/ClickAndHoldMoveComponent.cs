using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickAndHoldMoveComponent : MonoBehaviour
{
    PlayerControls controls;
    [SerializeField] NavMeshAgent moveAgent;
    Plane plane = new Plane(Vector3.up, 0);
    GameObject targetItem;
    GameObject targetEnemy;
    Ray ray;
    // Start is called before the first frame update
    void Awake()
    {
        controls = new PlayerControls();
        controls.PlayersControls.Enable();
        controls.PlayersControls.Click.performed += _ => StartCoroutine(Click_performed());

        controls.PlayersControls.Click.canceled += _ => StopAllCoroutines();
    }

    private IEnumerator Click_performed()
    {
        float distance;
        RaycastHit hit;

        while(true)
        {
            if (Physics.Raycast(ray, out hit))
            {
                plane.Raycast(ray, out distance);

                switch (hit.collider.tag)
                {
                    case "Ground":
                        moveAgent.destination = ray.GetPoint(distance);
                        transform.LookAt(ray.GetPoint(distance));
                        break;
                    case "UI":
                        break;
                    case "Healing":
                        GetComponent<StatsComponent>().Heal();
                        break;
                }
            }
            yield return new WaitForEndOfFrame();
        }

    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (targetItem != null && (transform.position - targetItem.transform.position).magnitude < 3)
        {
            targetItem.SetActive(false);
        }

        if (targetEnemy != null && (transform.position - targetEnemy.transform.position).magnitude < 3)
        {
            GetComponent<CombatComponent>().StartCombat(targetEnemy);
        }

    }
}
