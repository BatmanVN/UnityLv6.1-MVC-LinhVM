using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomAnim : MonoBehaviour
{
    private const string moveParaname = "move";
    private const string sitParaname = "Sit";

    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float animSmoothTime;
    private void StatusAnim()
    {
        float speed = agent.velocity.magnitude / agent.speed;
        anim.SetFloat(moveParaname, speed, animSmoothTime, Time.deltaTime);
    }
    public void Sitdown()
    {
        anim.SetBool(sitParaname, true);
    }
    public void StandUp()
    {
        anim.SetBool(sitParaname, false);
    }
    private void Update()
    {
        StatusAnim();
    }
}
