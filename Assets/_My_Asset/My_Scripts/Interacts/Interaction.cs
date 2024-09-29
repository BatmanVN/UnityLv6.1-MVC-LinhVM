using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private Transform interactionPoint;

    public Transform InteractionPoint { get => interactionPoint; set => interactionPoint = value; }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(InteractionPoint.position, radius);
    }
}
