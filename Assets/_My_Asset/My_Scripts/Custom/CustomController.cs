using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class CustomController : MonoBehaviour
{
    [SerializeField] private CustomMove customMove;
    [SerializeField] private Transform sitPoint;
    [SerializeField] private int randomPoint;
    [SerializeField] private Transform chairPoint;
    [SerializeField] private float timeStandup;
    [SerializeField] private UnityEvent onSitdown;
    [SerializeField] private UnityEvent onStandup;
    private bool isRandom;
    private bool move;

    public int RandomPoint { get => randomPoint; set => randomPoint = value; }

    private void Start()
    {
        RandomPoint = Random.Range(0, ChairManager.Instance.ListSitPoint.Count);
    }
    private void Move()
    {
        sitPoint = ChairManager.Instance.ListSitPoint[RandomPoint];
        chairPoint = ChairManager.Instance.ListChair[RandomPoint];
        customMove.MoveToPoint(sitPoint);
        Vector3 rotate = (sitPoint.position - chairPoint.position).normalized;
        if (customMove.EndOfLine())
        {
            transform.rotation = Quaternion.LookRotation(rotate);
            Sitdown();
        }
        if (!customMove.EndOfLine())
            isRandom = false;
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
        move = false;
    }
    private void Sitdown()
    {
        onSitdown?.Invoke();
        StartCoroutine(Standup());
        if (!isRandom)
        {
            RandomSitPoint();
        }
        timeStandup = Random.Range(5, 7);
        move = true;
    }

    private void RandomSitPoint()
    {
        RandomPoint = Random.Range(0, ChairManager.Instance.ListSitPoint.Count);
        isRandom = true;
    }
    private void Update()
    {
        MoveAgain();
    }
}
