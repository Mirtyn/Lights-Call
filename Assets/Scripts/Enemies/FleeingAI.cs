using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using Unity.VisualScripting;

internal class FleeingAI : MonoBehaviour
{

//    public float runDistance;
//    public float minRunDistance = 7;
//    public float maxRunDistance = 15;

//    public float runTime;
//    public float minrunTime = 0.5f;
//    public float maxrunTime = 2.5f;

//    // -1 = every layer
//    [SerializeField] int LayerMaskInteracteable = -1;

//    Transform target;
//    NavMeshAgent agent;
//    float timer;

//    // Use this for initialization
//    void OnEnable()
//    {
//        agent = GetComponent<NavMeshAgent>();
//        timer = runTime;
//    }

//    public void RunAway()
//    {
//        Debug.DrawLine(gameObject.transform.position, agent.destination, Color.magenta);
//        timer += Time.deltaTime;

//        if (timer >= wanderTimer)
//        {
//            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, LayerMaskInteracteable);
//            agent.SetDestination(newPos);
//            timer = 0;
//            wanderTimer = Random.Range(minWanderTimer, maxWanderTimer);
//            wanderRadius = Random.Range(minWanderRadius, maxWanderRadius);
//        }
//    }

//    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
//    {
//        float randXDirection = Random.Range()
//        Vector3 randDirection = Random.rotation.eulerAngles * dist;

//        randDirection += origin;

//        NavMeshHit navHit;

//        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

//        return navHit.position;
//    }
}
