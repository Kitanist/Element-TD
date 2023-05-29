using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoSingeleton<BuildManager>
{
    [SerializeField]private TowerBlueprint insaedilcektower;

    public Tower currentUpgradementTower;

    public Node node;
    
    public GameObject ArrowTower;
    public GameObject FireTower;
    public GameObject BallTower;
    public bool CanBuild { get { return insaedilcektower != null; } }
    public bool HasMoney { get { return GameManager.Instance.Gold >= insaedilcektower.cost; } }

    public float PayBackRatio = 0.65f;

    public void SelectTowerToBuild(TowerBlueprint turret)
    {
        insaedilcektower = turret;
    }
    public void DestroyTowerOn()
    {
        if (node.turret)
        {

            GameManager.Instance.Gold += node.turret.GetComponent<TowerBlueprint>().cost * PayBackRatio;
            Destroy(node.turret);
            node.turret = null;
            TheUI.Instance.ShopUIClose();
        }
    }
    public void BuildTowerOn()
    {
        if (GameManager.Instance.Gold< insaedilcektower.cost)
        {
            Debugger.Instance.Debuger("Kule inşa edemezsin !");

            return;
        }
      GameManager.Instance.Gold -= insaedilcektower.cost;

      GameObject turret =  (GameObject)Instantiate(insaedilcektower.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        
        Debugger.Instance.Debuger("Kule insa edildi kalan para :", GameManager.Instance.Gold);
       
            TheUI.Instance.ShopUIClose();
    }

}
