using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : Singleton<TableManager>
{
    [SerializeField] private List<Table> tables;

    public List<Table> Tables { get => tables; set => tables = value; }

    private void Update()
    {

    }
}
