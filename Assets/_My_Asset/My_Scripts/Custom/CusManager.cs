using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CusManager : Singleton<CusManager>
{
    [SerializeField] private List<CustomController> customs;
    public List<CustomController> Customs { get => customs; }

    private void Start()
    {
        foreach (Transform child in transform)
        {
            CustomController custom = child.GetComponent<CustomController>();
            if (custom != null)
                customs.Add(custom);
        }
    }
    //dung Do While cho den khi dung dieu kien
    public Chair RandomSitPoint()
    {
        Chair newChair;
        do
        {
            var lisTable = TableManager.Instance.Tables;
            int tableRandom = Random.Range(0, lisTable.Count);

            var lisChair = lisTable[tableRandom].Chairs;
            int chairRandom = Random.Range(0, lisChair.Count);
            newChair = lisChair[chairRandom];
            if (newChair != null && !newChair.isFull)
            {
                newChair.isFull = true;
                Debug.Log("Da ngoi: " + newChair.name);
            }
        } while (!newChair.isFull);
        return newChair;
    }

    //Dung for de duyet CheckChair ben Table
    public Chair RandomSit()
    {
        Chair newChair;
        var listable = TableManager.Instance.Tables;
        int randomTable = Random.Range(0, listable.Count);
        newChair = listable[randomTable].CheckChair();
        if (newChair != null)
        {
            Debug.Log("Da ngoi: " + newChair.name);
            return newChair;
        }
        return RandomSit();
    }
}
