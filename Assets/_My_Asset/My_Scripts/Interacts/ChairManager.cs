using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairManager : Singleton<ChairManager>
{
    [SerializeField] private List<Transform> listSitPoint;
    [SerializeField] private List<Transform> listChair;
    [SerializeField] private List<Transform> customs;

    public List<Transform> ListSitPoint { get => listSitPoint; }
    public List<Transform> ListChair { get => listChair;}

    public void CheckChair()
    {

    }
}
