using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class GetObjectMouseClicked : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    [SerializeField] LayerMask Interacteable;
    bool clickedChest = false;
    GameObject hitObject;

    void Start()
    {
        player = gameObject;
        agent = player.GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, float.MaxValue, Interacteable))
            {
                switch (hit.transform.tag)
                {
                    case "Ground":
                        clickedChest = false;
                        agent.destination = hit.point;
                        
                        break;
                    case "InteracteableTrigger":
                        clickedChest = true;
                        hitObject = hit.collider.gameObject;
                        agent.destination = hit.point;

                        break;
                    default:
                        clickedChest = false;

                        break;
                }
            }
        }

        ChestClicked();
    }

    public void ChestClicked()
    {
        while (clickedChest == true)
        {
            if (Vector3.Distance(player.transform.position, hitObject.transform.position) <= 3)
            {
                hitObject.GetComponent<PressTriggerScript>().FindTriggerType();
            }
        }
    }
}