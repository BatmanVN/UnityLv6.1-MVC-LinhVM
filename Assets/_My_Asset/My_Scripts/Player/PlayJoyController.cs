using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayJoyController : MonoBehaviour
{
    [SerializeField] protected JoyStickMove joyMove;
    [SerializeField] protected CharacterController character;
    [SerializeField] protected PlayJoyAnim anim;
    [SerializeField] protected Transform target;
    [SerializeField] private float time;
    private Coroutine enableCharater;
    private bool isNear;
    private bool isMoving;
    private bool asPos;
    private void Start()
    {
        enableCharater = StartCoroutine(EnableController());
    }
    protected void Move()
    {
        joyMove.PlayerMove();
        if (!isNear)
            CheckChair();
        if (isNear)
        {
            Sitdown();
        }
        isMoving = true;
    }
    protected IEnumerator EnableController()
    {
        yield return new WaitForSeconds(time);
        character.enabled = true;
        StopCoroutine(enableCharater);
    }
    protected void Sitdown()
    {
        anim.Sitdown();
        isMoving = false;
        asPos = true;
        StartCoroutine(EnableController());
    }
    protected void StandUp()
    {
        if (isMoving)
        {
            anim.StandUp();
            isNear = false;
        }
    }
    protected void CheckChair()
    {
        var listPoint = SitPointManager.Instance.sitPoints;
        for (int i = 0; i < listPoint.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, listPoint[i].transform.position);
            if (distance < 4f)
            {
                if (listPoint[i] != null && !listPoint[i].isFull)
                {
                    Transform sitPoint = listPoint[i].transform.Find("SitPoint");
                    Vector3 rotate = (sitPoint.position - listPoint[i].transform.position);
                    transform.rotation = Quaternion.LookRotation(rotate);
                    isNear = true;
                    if(!asPos)
                        transform.position = sitPoint.position;
                }
            }
        }
    }
    private void Update()
    {
        StandUp();
        Move();
    }
}
