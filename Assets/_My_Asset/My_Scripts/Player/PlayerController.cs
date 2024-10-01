using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private CustomAnim anim;
    [SerializeField] private PlayerMove move;
    [SerializeField] private LayerMask floorMask;
    [SerializeField] private Camera cam;
    [SerializeField] private Interactable forcus;

    private void Start()
    {
        cam = Camera.main;
        move = GetComponent<PlayerMove>();
    }
    protected virtual void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    if (interactable.transform.GetComponent<Chair>().isFull) return;
                    SetFocus(interactable);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, floorMask))
            {
                anim.StandUp();
                move.MoveToPoint(hit.point);
                RemoveFocus();
            }
        }
        
    }
    protected virtual void SetFocus(Interactable newFocus)
    {
        if (newFocus != forcus)
        {
            if (forcus != null)
                forcus.DeOnFocus();
            forcus = newFocus;
            move.FollowTarget(newFocus);
        }
        newFocus.Onfocus(transform);
    }
    protected virtual void RemoveFocus()
    {
        if (forcus != null)
            forcus.DeOnFocus();
        forcus = null;
        move.StopFollowTarget();
    }
    private void Update()
    {
        Move();
    }
}
