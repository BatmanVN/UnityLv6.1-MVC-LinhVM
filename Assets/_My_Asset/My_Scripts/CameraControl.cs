using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected Vector3 offset = new Vector3(0, 2, -10);

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
