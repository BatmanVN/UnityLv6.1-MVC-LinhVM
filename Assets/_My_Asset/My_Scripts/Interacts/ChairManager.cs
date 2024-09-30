using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairManager : Singleton<ChairManager>
{
    [SerializeField] private List<Transform> listSitPoint;
    [SerializeField] private List<Transform> listChair;

    public List<Transform> ListSitPoint { get => listSitPoint; }
    public List<Transform> ListChair { get => listChair;}

    private void Start()
    {

    }
    public void CheckChair()
    {

    }
}
