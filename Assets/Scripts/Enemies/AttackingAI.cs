using UnityEngine;
using System.Collections;
using UnityEngine.AI;

internal class AttackingAI : MonoBehaviour
{
    GameObject player;

    public float wanderRadius;
    public float minWanderRadius = 1;
    public float maxWanderRadius = 8;

    public float wanderTimer;
    public float minWanderTimer = 2;
    public float maxWanderTimer = 5;

    // -1 = every layer
    [SerializeField] int LayerMaskInteracteable = -1;

    Transform target;
    NavMeshAgent agent;
    float timer;

    // Use this for initialization
    void OnEnable()
    {
        player = GameObject.FindWithTag("MyPlayer");
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    public void Attack()
    {
        Debug.DrawLine(gameObject.transform.position, agent.destination, Color.red);
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, LayerMaskInteracteable);
            agent.SetDestination(newPos);
            timer = 0;
            wanderTimer = Random.Range(minWanderTimer, maxWanderTimer);
            wanderRadius = Random.Range(minWanderRadius, maxWanderRadius);
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector2 randDirection = Random.insideUnitCircle * dist;

        Vector3 r = origin + new Vector3(randDirection.x, 0, randDirection.y);

        NavMeshHit navHit;

        NavMesh.SamplePosition(r, out navHit, dist, layermask);

        return navHit.position;
    }
}
