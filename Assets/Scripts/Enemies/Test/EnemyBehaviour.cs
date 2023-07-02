using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    WanderingAI wanderingAI;
    FleeingAI fleeingAI;

    public float SightDistance = 10;
    public float StopAIDistance = 40;

    [SerializeField] bool flee = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("MyPlayer");
        agent = GetComponent<NavMeshAgent>();
        wanderingAI = this.GetComponent<WanderingAI>();
        fleeingAI = this.GetComponent<FleeingAI>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForMode();
    }

    void CheckForMode()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) >= StopAIDistance)
        {
            Debug.DrawLine(this.transform.position, this.transform.position + new Vector3(0, 20, 0) );
        }
        else if (flee)
        {
            Flee();
        }
        else if (Vector3.Distance(player.transform.position, this.transform.position) <= SightDistance)
        {
            Attack();
        }
        else
        {
            Idle();
        }
    }

    void Idle()
    {
        wanderingAI.Wander();
    }

    void Attack()
    {
        
    }

    void Flee()
    {
        fleeingAI.RunAway();
    }
}
