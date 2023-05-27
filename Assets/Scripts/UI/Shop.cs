using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    
    
    public void SelectArrowTower()
    {
        BuildManager.Instance.SelectTowerToBuild(BuildManager.Instance.ArrowTower.GetComponent<TowerBlueprint>());
        BuildManager.Instance.BuildTowerOn();
        TheUI.Instance.ShopUIClose();
    }
    public void SelectFireTower()
    {
     BuildManager.Instance.SelectTowerToBuild(BuildManager.Instance.FireTower.GetComponent<TowerBlueprint>());
        BuildManager.Instance.BuildTowerOn();
             TheUI.Instance.ShopUIClose();
    }
     public void SelectBallTower()
    {
       BuildManager.Instance.SelectTowerToBuild(BuildManager.Instance.BallTower.GetComponent<TowerBlueprint>());
        BuildManager.Instance.BuildTowerOn();
            TheUI.Instance.ShopUIClose();
    }
}
