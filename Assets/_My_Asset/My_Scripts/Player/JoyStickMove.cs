using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickMove : MonoBehaviour
{
    [SerializeField] protected CharacterController characterController;
    [SerializeField] protected VariableJoystick joyStick;
    [SerializeField] private float speed;
    [SerializeField] protected float rotationSpeed;
    private bool isTrigger;
    public float Speed { get => speed;}
    public bool IsTrigger { get => isTrigger;}

    private void OnValidate() => characterController = GetComponent<CharacterController>();

    public void PlayerMove()
    {
        float hInput = joyStick.Horizontal;
        float xInput = joyStick.Vertical;
        var direction = new Vector3(hInput,0f,xInput);
        characterController.SimpleMove(direction * Speed);
        if (characterController.velocity != Vector3.zero)
        {
            Quaternion targetRotate = Quaternion.LookRotation(characterController.velocity);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotate, rotationSpeed * Time.deltaTime);
        }
    }
    //public void UpdateMove()
    //{

    //}
    //private void OnTriggerEnter(Collider player)
    //{
    //    if (player.CompareTag("Chair"))
    //    {
    //        isTrigger = true;
    //    }
    //}
    //public void FollowTarget(Interactable newTarget)
    //{
    //    target = newTarget.InteractionPoint;
    //}
    //public void StopFollowTarget()
    //{
    //    target = null;
    //}
}
