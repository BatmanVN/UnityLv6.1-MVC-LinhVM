using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private Transform player;
    private bool isFocus;

    public Transform InteractionPoint { get => interactionPoint; set => interactionPoint = value; }
    public float Radius { get => radius;}

    public void Onfocus(Transform playerTrasnform)
    {
        isFocus = true;
        player = playerTrasnform;
    }

    public void DeOnFocus()
    {
        isFocus = false;
        player = null;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(InteractionPoint.position, Radius);
    }
}
