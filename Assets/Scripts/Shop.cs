using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowerBlueprint ArrowTower;
    public TowerBlueprint FireTower;
    BuildManager BM;
    private void Start()
    {
        BM = BuildManager.instance;
    }
    public void SelectArrowTower()
    {
        BM.SelectTowerToBuild(ArrowTower);
    }
    public void SelectFireTower()
    {
        BM.SelectTowerToBuild(FireTower);
    }
}
