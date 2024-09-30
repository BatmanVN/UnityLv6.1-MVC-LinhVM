using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class CustomController : MonoBehaviour
{
    [SerializeField] private CustomMove customMove;
    [SerializeField] private Transform sitPoint;
    [SerializeField] private int randomPoint;
    [SerializeField] private Transform chairPoint;
    [SerializeField] private float timeStandup;
    [SerializeField] private UnityEvent onSitdown;
    [SerializeField] private UnityEvent onStandup;
    private bool isRandom;
    private bool move;
    private bool isSitted;
    public int RandomPoint { get => randomPoint; set => randomPoint = value; }

    private void Start()
    {
        CheckRandom();
    }
    private void Move()
    {
        sitPoint = ChairManager.Instance.ListSitPoint[RandomPoint];
        chairPoint = ChairManager.Instance.Chairs[RandomPoint].transform;
        customMove.MoveToPoint(sitPoint);
        Vector3 rotate = (sitPoint.position - chairPoint.position).normalized;
        if (customMove.EndOfLine())
        {
            transform.rotation = Quaternion.LookRotation(rotate);
            Sitdown();
        }
        if (!customMove.EndOfLine())
            isRandom = false;
    }
    private void MoveAgain()
    {
        if (!move)
        {
            Move();
        }
    }
    private IEnumerator Standup()
    {
        yield return new WaitForSeconds(timeStandup);
        onStandup?.Invoke();
        ChairManager.Instance.Chairs[RandomPoint].Custom = null;
        isSitted = false;
        if (!isRandom)
        {
            CheckRandom();
            isRandom = true;
        }
        move = false;
    }
    private void Sitdown()
    {
        timeStandup = Random.Range(5, 7);
        onSitdown?.Invoke();
        StartCoroutine(Standup());
        move = true;
    }

    private void CheckRandom()
    {
        var listChair = ChairManager.Instance.Chairs.Where(chair => chair.Custom == null).ToList();
        if (listChair.Count <= 0)
        {
            return;
        }
        if (!isSitted)
        {
            RandomPoint = Random.Range(0, listChair.Count);
            listChair[RandomPoint].Custom = this;
            isSitted = true;
        }
        else return;
    }
    private void Update()
    {
        MoveAgain();
    }
}
