using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToClickComponent : MonoBehaviour
{
    PlayerControls controls;
    [SerializeField] NavMeshAgent moveAgent;
    Plane plane = new Plane(Vector3.up, 0);
    GameObject targetItem;
    GameObject targetEnemy;
    // Start is called before the first frame update
    void Awake()
    {
        controls = new PlayerControls();
        controls.PlayersControls.Enable();
        controls.PlayersControls.Click.performed += Click_performed;
    }

    private void Click_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            plane.Raycast(ray, out distance);
            if (hit.collider.tag == "Ground")
            {
                moveAgent.destination = ray.GetPoint(distance);
                transform.LookAt(ray.GetPoint(distance));
            }
            if(hit.collider.tag == "Enemy")
            {
                targetEnemy = hit.collider.gameObject;
                targetItem = null;
                Debug.Log(targetEnemy.name);
            }
        }

        /*if(plane.Raycast(ray,out distance))
        {
            
            moveAgent.destination = ray.GetPoint(distance);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if(targetItem != null && (transform.position - targetItem.transform.position).magnitude < 3)
        {
            targetItem.SetActive(false);
        }
        
        if (targetEnemy != null && (transform.position - targetEnemy.transform.position).magnitude < 3)
        {
            GetComponent<CombatComponent>().StartCombat(targetEnemy);
        }
        
    }
}
