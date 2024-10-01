using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : Interactable
{
    [SerializeField] private Item item;
    [SerializeField] private CustomController custom;
    [SerializeField] private Transform sitPointDown;
    public bool isFull = false;

    public CustomController Custom { get => custom; set => custom = value; }
    public Transform SitPointDown { get => sitPointDown; set => sitPointDown = value; }

    private void Start()
    {
        Custom = null;
        sitPointDown = transform.Find("SitPoint");
    }
}
