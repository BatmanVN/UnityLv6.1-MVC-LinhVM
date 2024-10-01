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
    //public Vector3 RandomPosition()
    //{
    //    bool asPos;
    //    Vector3 randomPos = Random.insideUnitSphere * maxDistance + mapCenter.position;
    //    NavMeshHit hit;
    //    asPos = NavMesh.SamplePosition(randomPos, out hit, maxDistance, NavMesh.AllAreas);
    //    if (asPos)
    //    {
    //        return hit.position;
    //    }
    //    return RandomPosition();
    //}
    public bool EndOfLine()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            return true;
        }
        return false;
    }

}
