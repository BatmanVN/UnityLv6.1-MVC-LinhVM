using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitPointManager : Singleton<SitPointManager>
{
    public List<Chair> sitPoints;
    void Start()
    {
        foreach (Transform table in transform)
        {
            foreach (Transform chair in table)
            {
                //foreach (Transform sitPoint in chair)
                //{
                if (chair.CompareTag("Chair"))
                {
                    Chair chair1 = chair.GetComponent<Chair>();
                    if (chair1 != null)
                    {
                        sitPoints.Add(chair1);
                    }
                }
                //}
            }
        }
    }
}
