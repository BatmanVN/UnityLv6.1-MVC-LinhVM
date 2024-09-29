using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string nameItem;

    public virtual void StatusItem()
    {
        Debug.Log("Sitted in: " + name);
    }
}
