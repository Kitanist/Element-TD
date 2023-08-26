using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoSingeleton<BuildManager>
{
    public Agument_SO towerToBuild; // Tower from Agument
     
    public Tower currentUpgradementTower; //For Upgrade Towers

    public Node node;

    public GameObject ArrowTower;
    public GameObject FireTower;
    public GameObject BallTower;
    public GameObject Mine;

    public bool CanBuild
    {
        get { return towerToBuild != null; }
    }

    public bool HasMoney
    {
        get { return GameManager.Instance.Gold >= node.cost; }
    }

    public float PayBackRatio = 0.65f;


    public void DestroyTowerOn()
    {
        if (node.turret)
        {
            GameManager.Instance.Gold += node.turret.GetComponent<TowerBlueprint>().cost * PayBackRatio;

            if (UnityEngine.Random.Range(0, 2) == 1) // random sound effect
                GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik1);
            else
                GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik2);

            Destroy(node.turret.gameObject);
            currentUpgradementTower = null;
            node.turret = null;

            //  TheUI.Instance.isButton=true;
            // TheUI.Instance.ShopUIClose();
        }
    }

    public void BuildTowerOn()
    {
      // if (GameManager.Instance.Gold < node.cost)
      // {
      //     Debugger.Instance.Debuger("Not Enough Gold!");
      //     return;
      // }

        GameManager.Instance.Gold -= node.cost;

        GameObject turret = Instantiate(towerToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
            
        GameObject particle = ObjectPool.Instance.GetPooledObject(34);
        particle.transform.position = node.GetBuildPosition();
        GameManager.Instance.asource.PlayOneShot(turret.GetComponent<Tower>().buildSoundClip);

        node.turret = turret;
        turret.GetComponent<Tower>().node = node;

        OnEfect(turret.GetComponent<Tower>());
        Debugger.Instance.Debuger("Tower is Builded: -", node.cost);
        //TheUI.Instance.ShopUIClose();
    } // Before Call This Func Set towerToBuild
    public void OnEfect(Tower tower)
    {
        if(towerToBuild.agumentName=="Alevli Oklar")
        {
            tower.isAlevliOklarEnabled = true;
        }
        if(towerToBuild.agumentName == "Ikinci Darbe")
        {
            tower.isIlkDarbeEnabled = true;
        }
        if (towerToBuild.agumentName == "Yandým Anam")
        {
            tower.isIamBurning = true;
        }
        if (towerToBuild.agumentName == "Yandým Anam II")
        {
            tower.isIamBurningII = true;
        }
        if (towerToBuild.agumentName == "Ilk Darbe")
        {
            tower.isFistImpact= true;
        }
    }
}