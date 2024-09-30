using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CusManager : MonoBehaviour
{
    [SerializeField] private List<CustomController> customs;
    private bool statusChair;
    private void Start()
    {
        customs = new List<CustomController>(GetComponentsInChildren<CustomController>());
    }

    public void CheckListChair()
    {
        List<CustomController> selectedChair = new List<CustomController>();

    }
}
