using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    
    BuildManager BM;
    private void Start()
    {
        BM = BuildManager.instance;
    }
    public void PurchaseArrowTower()
    {
        BM.SetTowerToBuild(BM.ArrowTower);
    }
    public void PurchaseFireTower()
    {
        BM.SetTowerToBuild(BM.FireTower);
    }
}
