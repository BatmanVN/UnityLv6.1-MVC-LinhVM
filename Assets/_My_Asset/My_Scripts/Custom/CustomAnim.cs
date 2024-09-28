using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomAnim : MonoBehaviour
{
    private const string moveParaname = "move";
    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float animSmoothTime;
    public void StatusAnim()
    {
        float speed = agent.velocity.magnitude / agent.speed;
        anim.SetFloat(moveParaname, speed, animSmoothTime, Time.deltaTime);
    }
    private void Update()
    {
        StatusAnim();
    }
}
