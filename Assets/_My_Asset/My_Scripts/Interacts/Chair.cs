using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : Interaction
{
    [SerializeField] private Item item;
    [SerializeField] private bool checkBlank;
    private void Start()
    {
        InteractionPoint = GetComponent<Transform>();
    }
    public void StatusItem()
    {
        Debug.Log("Sitted in: " + gameObject.name);
    }
}
