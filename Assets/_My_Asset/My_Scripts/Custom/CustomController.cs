using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class CustomController : MonoBehaviour
{
    [SerializeField] private CustomMove customMove;
    [SerializeField] private Chair sitPoint;
    [SerializeField] private Transform chairPoint;
    [SerializeField] private float timeStandup;
    [SerializeField] private UnityEvent onSitdown;
    [SerializeField] private UnityEvent onStandup;
    private bool isRandom;
    private bool move;

    private void Start()
    {
        GetChair();
    }
    private void Move()
    {
        chairPoint = sitPoint.transform;
        customMove.MoveToPoint(sitPoint.SitPointDown.position);
        Vector3 rotate = (sitPoint.SitPointDown.position - chairPoint.position).normalized;
        if (customMove.EndOfLine())
        {
            transform.rotation = Quaternion.LookRotation(rotate);
            Sitdown();
        }
    }
    private void MoveAgain()
    {
        if (!move)
        {
            Move();
        }
    }
    private void Standup()
    {
        onStandup?.Invoke();
        RestChair();
        GetChair();
        move = false;
    }
    private void Sitdown()
    {
        timeStandup = Random.Range(5, 7);
        onSitdown?.Invoke();
        Invoke(nameof(Standup), timeStandup);
        move = true;
    }

    private void RestChair()
    {
        if (sitPoint.Custom != null)
        {
            sitPoint.isFull = false;
            sitPoint.Custom = null;
        }
    }
    private void GetChair()
    {
        //sitPoint = CusManager.Instance.RandomSit();
        sitPoint = CusManager.Instance.RandomSitPoint();
        sitPoint.Custom = this;
    }
    private void Update()
    {
        MoveAgain();
    }
}
