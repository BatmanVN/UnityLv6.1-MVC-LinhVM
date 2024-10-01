using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform target;
    [SerializeField] private CustomAnim anim;
    [SerializeField] private Transform sitPoint;
    [SerializeField] private float time;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }
    private void Update()
    {

        UpdateMove();

    }
    public void UpdateMove()
    {
        if (target != null)
        {
            sitPoint = target.Find("SitPoint");
            agent.SetDestination(sitPoint.position);
            //float distance = Vector3.Distance(transform.position, sitPoint.position);
            Vector3 rotate = (sitPoint.position - target.position).normalized;
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance /*distance <= 1f*/)
            {
                transform.rotation = Quaternion.LookRotation(rotate);
                anim.Sitdown();
            }
        }
        else
            return;
    }
    public void FollowTarget(Interactable newTarget)
    {
        target = newTarget.InteractionPoint;
        agent.stoppingDistance = newTarget.Radius * 0.5f;
    }
    public void StopFollowTarget()
    {
        agent.stoppingDistance = 0f;
        target = null;
    }
}
