using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    
    
    public void SelectArrowTower()
    {
        if(UnityEngine.Random.Range(0,2)==1)
    GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik1);
    else
      GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik2);

        BuildManager.Instance.SelectTowerToBuild(BuildManager.Instance.ArrowTower.GetComponent<TowerBlueprint>());
        BuildManager.Instance.BuildTowerOn();
       // TheUI.Instance.isButton=true;
       // TheUI.Instance.ShopUIClose();
    }
    public void SelectFireTower()
    {
        if(UnityEngine.Random.Range(0,2)==1)
    GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik1);
    else
      GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik2);

     BuildManager.Instance.SelectTowerToBuild(BuildManager.Instance.FireTower.GetComponent<TowerBlueprint>());
        BuildManager.Instance.BuildTowerOn();
        //TheUI.Instance.isButton=true;
           //  TheUI.Instance.ShopUIClose();
    }
     public void SelectBallTower()
    {
        if(UnityEngine.Random.Range(0,2)==1)
    GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik1);
    else
      GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik2);

       BuildManager.Instance.SelectTowerToBuild(BuildManager.Instance.BallTower.GetComponent<TowerBlueprint>());
        BuildManager.Instance.BuildTowerOn();
        //TheUI.Instance.isButton=true;
         //   TheUI.Instance.ShopUIClose();
    }

     public void SelectGoldMineTower()
    {
        if(UnityEngine.Random.Range(0,2)==1)
    GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik1);
    else
      GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik2);
      
       BuildManager.Instance.SelectTowerToBuild(BuildManager.Instance.Mine.GetComponent<TowerBlueprint>());
        BuildManager.Instance.BuildTowerOn();
                //  TheUI.Instance.isButton=true;
           // TheUI.Instance.ShopUIClose();
    }
}
