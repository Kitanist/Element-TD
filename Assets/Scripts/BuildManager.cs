using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private TowerBlueprint insaedilcektower;

    public static BuildManager instance;

    
    public GameObject ArrowTower;
    public GameObject FireTower;
    public bool CanBuild { get { return insaedilcektower != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= insaedilcektower.cost; } }
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void SelectTowerToBuild(TowerBlueprint turret)
    {
        insaedilcektower = turret;
    }
    public void BuildTowerOn(Node node)
    {
        if (PlayerStats.Money < insaedilcektower.cost)
        {
            Debug.Log("Kule inþa edemezsin");
            return;
        }
        PlayerStats.Money -= insaedilcektower.cost;

      GameObject turret =  (GameObject)Instantiate(insaedilcektower.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Kule inþa edildi kalan para :" + PlayerStats.Money);
    }

}
