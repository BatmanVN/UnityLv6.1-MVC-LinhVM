using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairManager : Singleton<ChairManager>
{
    [SerializeField] private List<Transform> listSitPoint;
    //[SerializeField] private List<Transform> listChair;
    [SerializeField] private List<Chair> chairs;
    public List<Transform> ListSitPoint { get => listSitPoint; }
    //public List<Transform> ListChair { get => listChair;}
    public List<Chair> Chairs { get => chairs; set => chairs = value; }
    //public List<bool> StatusChair { get => statusChair;}

    private void Start()
    {
        
    }
}
