using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitPointManager : Singleton<SitPointManager>
{
    public List<Transform> sitPoints;
    void Start()
    {
        foreach (Transform table in transform)
        {
            foreach (Transform chair in table)
            {
                foreach (Transform sitPoint in chair)
                {
                    if (sitPoint.CompareTag("SitPoint"))
                    {
                        sitPoints.Add(sitPoint);
                    }
                }
            }
        }
    }
}
