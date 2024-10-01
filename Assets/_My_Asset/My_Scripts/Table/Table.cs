using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private List<Chair> chairs;

    public List<Chair> Chairs { get => chairs; set => chairs = value; }

    public Chair CheckChair()
    {
        for (int i = 0; i < chairs.Count; i++)
        {
            ////if (chairs[i].Custom == null)
            ////{
            ////    return chairs[i];
            //}
            if (!chairs[i].isFull)
            {
                chairs[i].isFull = true;
                return chairs[i];
            }
        }
        return null;
    }
}
