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
      GameObject turret =  (GameObject)Instantiate(insaedilcektower.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }

}
