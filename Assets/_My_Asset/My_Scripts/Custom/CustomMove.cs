using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class CustomMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    private void Start()
    {
        
    }
    public void MoveToPoint(Transform point)
    {
        agent.SetDestination(point.position);
    }
    public bool EndOfLine()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            return true;
        }
        return false;
    }

}
