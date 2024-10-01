using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayJoyAnim : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private JoyStickMove speedMove;
    [SerializeField] private CharacterController character;
    [SerializeField] private float animSmoothTime;
    private void StatusAnim()
    {
        float speed = character.velocity.magnitude / speedMove.Speed;
        anim.SetFloat(StringConst.moveParaname, speed, animSmoothTime, Time.deltaTime);
    }
    public void Sitdown()
    {
        anim.SetBool(StringConst.sitParaname, true);
        character.enabled = false;
    }
    public void StandUp()
    {
        anim.SetBool(StringConst.sitParaname, false);
        anim.SetTrigger(StringConst.standParaname);
    }
    private void Update()
    {
        StatusAnim();
    }
}
