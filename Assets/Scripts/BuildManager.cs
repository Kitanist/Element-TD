using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoSingeleton<BuildManager>
{
    [SerializeField]private TowerBlueprint insaedilcektower;


    public Node node;
    
    public GameObject ArrowTower;
    public GameObject FireTower;
    public GameObject BallTower;
    public bool CanBuild { get { return insaedilcektower != null; } }
    public bool HasMoney { get { return GameManager.Instance.Gold >= insaedilcektower.cost; } }
    

    public void SelectTowerToBuild(TowerBlueprint turret)
    {
        insaedilcektower = turret;
    }
    public void BuildTowerOn()
    {
        if (GameManager.Instance.Gold< insaedilcektower.cost)
        {
            Debug.Log("Kule in�a edemezsin");
            return;
        }
      GameManager.Instance.Gold -= insaedilcektower.cost;

      GameObject turret =  (GameObject)Instantiate(insaedilcektower.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Kule in�a edildi kalan para :" + GameManager.Instance.Gold);
    }

}
