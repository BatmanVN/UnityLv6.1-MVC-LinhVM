using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : Interactable
{
    [SerializeField] private Item item;

    private void Start()
    {

    }
    public void StatusItem()
    {
        Debug.Log("Sitted in: " + gameObject.name);
    }
}
