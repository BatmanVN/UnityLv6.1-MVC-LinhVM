using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayJoyController : MonoBehaviour
{
    [SerializeField] protected JoyStickMove joyMove;
    [SerializeField] protected CharacterController character;
    [SerializeField] protected PlayJoyAnim anim;
    private bool isNear;
    private bool isMoving;
    protected void Move()
    {
        joyMove.PlayerMove();
        if(!isNear)
            CheckChair();
        if (isNear)
        {
            Sitdown();
            Debug.Log("Sit");
        }
        isMoving = true;
    }

    protected void Sitdown()
    {
        anim.Sitdown();
        Invoke(nameof(EnableCharacter), 1f);
    }
    protected void EnableCharacter()
    {
        character.enabled = true;
        if (isMoving)
        {
            anim.StandUp();
            isNear = false;
        }
    }
    protected void CheckChair()
    {
        var listPoint = SitPointManager.Instance.sitPoints;
        for(int i = 0; i < listPoint.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, listPoint[i].position);
            if (distance < 1f)
            {
                if (listPoint[i] != null)
                {
                    Transform sitPoint = listPoint[i].Find("Chair");
                    Vector3 rotate = (listPoint[i].position - sitPoint.position);
                    transform.rotation = Quaternion.LookRotation(rotate);
                    isNear = true;
                    break;
                }
            }
        }
    }
    private void Update()
    {
        Move();
    }
}
