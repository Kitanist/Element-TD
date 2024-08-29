using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoSingeleton<BuildManager>
{
    public Agument_SO towerToBuild; // Tower from Agument
     
    public Node node;
    


    public bool CanBuild
    {
        get { return towerToBuild != null; }
    }

    public bool HasMoney
    {
        get { return GameManager.Instance.Gold >= node.cost; }
    }

    public float PayBackRatio = 0.65f;


 

    public void BuildTowerOn()
    {
        if (!node.turret)
        {
            GameManager.Instance.Gold -= node.cost;

            GameObject turret = Instantiate(towerToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);

            GameObject particle = ObjectPool.Instance.GetPooledObject(34);
            particle.transform.position = node.GetBuildPosition();
            GameManager.Instance.asource.PlayOneShot(turret.GetComponent<Tower>().buildSoundClip);

            node.turret = turret;
            turret.GetComponent<Tower>().node = node;

            OnEfect(turret.GetComponent<Tower>());
            Debugger.Instance.Debuger("Tower is Builded: -", node.cost);
            node.mrenderer.enabled = false;

            node = null;
            towerToBuild = null;

        }


    } // Before Call This Func Set towerToBuild
    public void OnEfect(Tower tower)
    {
        if (towerToBuild.agumentName == "Alevli Oklar")
        {
            tower.isAlevliOklarEnabled = true;
        }
        if (towerToBuild.agumentName == "Ikinci Darbe")
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
            tower.isFistImpact = true;
        }
        if (towerToBuild.agumentName == "Tonla Hasar")
        {
            tower.isTonlaHasarEnabled = true;
            GameManager.Instance.myCastle.GetComponent<HealthComponent>().GetDamage(GameManager.Instance.myCastle.GetComponent<HealthComponent>().Health / 4, Element_Type.None,Color.cyan);
            tower.damage += 4;
        }
        if (towerToBuild.agumentName == "Gecemezsin")
        {
            tower.isCantPass = true;
        }
        if (towerToBuild.agumentName == "Dondurma")
        {
            tower.isDon = true;
        }
        if (towerToBuild.agumentName == "Coss")
        {
            tower.isCoss = true;
        }
        if (towerToBuild.agumentName == "Bir icim Su")
        {
            Debug.Log("+20");
            tower.isBirIcimSu = true;

            GameManager.Instance.myCastle.GetComponent<HealthComponent>().Health += 20;
            GameManager.Instance.myCastle.GetComponent<HealthComponent>().HealtBar.DOValue(GameManager.Instance.myCastle.GetComponent<HealthComponent>().Health / GameManager.Instance.myCastle.GetComponent<HealthComponent>().maxHealth, .5f, false);
            if (GameManager.Instance.myCastle.GetComponent<HealthComponent>().Health > GameManager.Instance.myCastle.GetComponent<HealthComponent>().maxHealth)
            {
                GameManager.Instance.myCastle.GetComponent<HealthComponent>().Health = GameManager.Instance.myCastle.GetComponent<HealthComponent>().maxHealth;
                GameManager.Instance.myCastle.GetComponent<HealthComponent>().HealtBar.DOValue(1, .5f, false);
            }

        }
        if (towerToBuild.agumentName == "Olumcul Tempo")
        {
            tower.isOlumculTempo= true;

        }
        if(towerToBuild.agumentName == "Geri Bass")
        {
            tower.isBassGeri= true;
        }
    }
    }