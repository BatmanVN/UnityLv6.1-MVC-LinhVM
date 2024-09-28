using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomController : MonoBehaviour
{
    [SerializeField] private CustomMove customMove;
    [SerializeField] private Transform point;
    [SerializeField] private Transform chair;

    private void Move()
    {
        customMove.MoveToPoint(point);
        float distance = Vector3.Distance(transform.position, point.position);
        if (distance < 2.7f)
        {
            transform.LookAt(chair);
            transform.Rotate(0, 180, 0);
        }
        Debug.Log(distance);
    }
    private void Update()
    {
        Move();
    }
}
