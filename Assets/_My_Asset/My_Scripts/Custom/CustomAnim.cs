using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomAnim : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float animSmoothTime;
    private void StatusAnim()
    {
        float speed = agent.velocity.magnitude / agent.speed;
        anim.SetFloat(StringConst.moveParaname, speed, animSmoothTime, Time.deltaTime);
    }
    public void Sitdown()
    {
        anim.SetBool(StringConst.sitParaname, true);
        agent.enabled = false;
    }
    public void StandUp()
    {
        anim.SetBool(StringConst.sitParaname, false);
        anim.SetTrigger(StringConst.standParaname);
        agent.enabled = true;
    }
    private void Update()
    {
        StatusAnim();
    }
}
