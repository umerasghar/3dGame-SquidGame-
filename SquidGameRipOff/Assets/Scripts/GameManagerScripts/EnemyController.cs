using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] points;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            StartPatrolling();
        }
    }
    public void StartPatrolling()
    {
        if (points.Length != 0)
        {
            agent.destination = points[index].position;
            index = (index + 1) % points.Length;
        }

    }
}
