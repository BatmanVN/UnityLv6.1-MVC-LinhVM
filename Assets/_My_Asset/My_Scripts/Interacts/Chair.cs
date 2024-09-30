using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : Interactable
{
    [SerializeField] private Item item;
    [SerializeField] private bool isFull;
    [SerializeField] private CustomController custom;

    public CustomController Custom { get => custom; set => custom = value; }
    public bool IsFull { get => isFull; set => isFull = value; }

    private void Start()
    {
        isFull = true;
        Custom = null;
    }
}
