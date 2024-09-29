using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomController : MonoBehaviour
{
    [SerializeField] private CustomMove customMove;
    [SerializeField] private Transform point;
    [SerializeField] private int randomPoint;
    [SerializeField] private Transform sitPoint;
    [SerializeField] private float timeStandup;
    [SerializeField] private UnityEvent onSitdown;
    [SerializeField] private UnityEvent onStandup;
    private void Start()
    {
        RandomPoint();
    }
    private void Move()
    {
        customMove.MoveToPoint(point);
        float distance = Vector3.Distance(transform.position, point.position);
        if (distance < 1f)
        {
            transform.LookAt(sitPoint);
            transform.Rotate(0, 180, 0);
            StartCoroutine(Sitdown());
        }
        Debug.Log(distance);
    }
    private IEnumerator Standup()
    {
        yield return new WaitForSeconds(timeStandup);
        onStandup?.Invoke();
        RandomPoint();
    }
    private IEnumerator Sitdown()
    {
        yield return new WaitForEndOfFrame();
        onSitdown?.Invoke();
        StartCoroutine(Standup());
    }
    private void RandomPoint()
    {
        randomPoint = Random.Range(0, ChairManager.Instance.ListSitPoint.Count);
        point = ChairManager.Instance.ListSitPoint[randomPoint];
        sitPoint = ChairManager.Instance.ListChair[randomPoint];
    }
    private void Update()
    {
        Move();
    }
}
