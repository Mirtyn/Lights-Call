using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class GetObjectMouseClicked : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    [SerializeField] LayerMask Interacteable;
    Coroutine storedChestClickedCourotine;
    bool clickedChest = false;

    void Start()
    {
        player = gameObject;
        agent = player.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, float.MaxValue, Interacteable))
            {
                agent.destination = hit.point;
                
                switch (hit.transform.tag)
                {
                    case "Ground":
                        agent.destination = hit.point;
                        if (clickedChest == true)
                        {
                            StopCoroutine(storedChestClickedCourotine);
                        }
                        clickedChest = false;
                        break;
                    case "InteracteableTrigger":
                        agent.destination = hit.point;
                        GameObject hitObject = hit.collider.gameObject;
                        storedChestClickedCourotine = StartCoroutine(ChestClicked(hitObject));
                        clickedChest = true;
                        break;
                    default:
                        if (clickedChest == true)
                        {
                            StopCoroutine(storedChestClickedCourotine);
                        }
                        clickedChest = false;
                        break;
                }
            }
        }
    }

    public IEnumerator ChestClicked(GameObject hitObject)
    {
        while (clickedChest == true)
        {
            if (Vector3.Distance(player.transform.position, hitObject.transform.position) <= 3)
            {
                Debug.Log("Chest Opened");
                StopCoroutine(storedChestClickedCourotine);
                yield return null;
            }
        }
    }
}