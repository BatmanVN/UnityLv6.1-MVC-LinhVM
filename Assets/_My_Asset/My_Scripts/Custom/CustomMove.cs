using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    

    public void MoveToPoint(Transform point)
    {
        agent.SetDestination(point.position);
    }
}
