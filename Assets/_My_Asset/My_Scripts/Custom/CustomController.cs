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
    private bool move;
    private Coroutine standUpTime;
    private void Start()
    {
        GetChair();
        standUpTime = StartCoroutine(Standup());
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
    private IEnumerator Standup()
    {
        yield return new WaitForSeconds(timeStandup);
        onStandup?.Invoke();
        RestChair();
        GetChair();
        move = false;
        StopCoroutine(standUpTime);
    }
    private void Sitdown()
    {
        timeStandup = Random.Range(5, 7);
        onSitdown?.Invoke();
        StartCoroutine(Standup());
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
