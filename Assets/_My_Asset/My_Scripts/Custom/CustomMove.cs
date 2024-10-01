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
    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
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
