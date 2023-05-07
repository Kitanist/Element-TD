using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GameObject insaedilcektower;

    public static BuildManager instance;

    public GameObject ArrowTower;
    public GameObject FireTower;

   
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void SetTowerToBuild(GameObject turret)
    {
        insaedilcektower = turret;
    }
    public GameObject GetTower()
    {
        return insaedilcektower;
    }
}
