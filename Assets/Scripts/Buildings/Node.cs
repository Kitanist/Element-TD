using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color HoverColor;
    public Color NotHaveMoneyColor;
    public Vector3 pozisyonOffset;
    public int cost;

    public GameObject turret;
    public GameEvent OnAgumentEvent;
    private Renderer rend;
    public MeshRenderer mrenderer;
    private Color StartColor;

    public bool isGoldMineNode = false;


    private void Start()
    {
        mrenderer = GetComponent<MeshRenderer>();
        rend = GetComponent<Renderer>();
        if (!isGoldMineNode)
        {
            StartColor = rend.material.color;
        }
        else
        {
            StartColor = rend.material.color;
        }
    }

    public Vector3 GetBuildPosition() // kule pozisyonu ayarlaması
    {
        return transform.position + pozisyonOffset;
    }

    private void OnMouseEnter() // mouse node a girince
    {
        if (AgumentManager.Instance.isOpenTab) return;
        if (!isGoldMineNode)
        {
            if (turret)
                turret.GetComponent<Tower>().rangeObject.SetActive(true);
        }
    }

    public void NodeToTower()
    {
        BuildManager.Instance.node = this;
    }

    private void OnMouseDown() // Agument Eventini Başlat
    {
        if (AgumentManager.Instance.isOpenTab) return;
        if (turret) return;
        //   if (!BuildManager.Instance.CanBuild)
        //       return;
      
        NodeToTower();  
        OnAgumentEvent.Raise();
        // upgrade ve insa bolgeleri ayarlandi


        if (turret)
        {
            if (turret.GetComponent<Tower>().towerIsPlayer)
            {
                // TheUI.Instance.isButton=false;
                //   TheUI.Instance.ShopUIClose();
                // Invoke("OpenUIUpgrade",.6f);
            }
        }
        else
        {
            //TheUI.Instance.isButton=false;
            //  TheUI.Instance.ShopUIClose();
            //   Invoke("OpenUIUTower",.6f);
        }
    }

    /* public void OpenUIUpgrade () {

   // TheUI.Instance.isTurret = false;
   // TheUI.Instance.isUpgrade = true;
   // TheUI.Instance.isArmy = false;
  //  TheUI.Instance.ShopUIOpen();
     if(isGoldMineNode){
 
    // TheUI.Instance.UShopButton3.interactable = false;
     }
     else{
      
    // TheUI.Instance.UShopButton3.interactable = true;
     }
    
}
  public void OpenUIUTower () {
   // TheUI.Instance.isTurret = true;
   // TheUI.Instance.isUpgrade = false;
   // TheUI.Instance.isArmy = false;
   // TheUI.Instance.ShopUIOpen();

    if(isGoldMineNode){
         TheUI.Instance.ShopButton1.interactable=false;
            TheUI.Instance.ShopButton2.interactable=false;
            TheUI.Instance.ShopButton3.interactable=false;
            TheUI.Instance.ShopButton4.interactable=true;
    }
    else{
              TheUI.Instance.ShopButton1.interactable=true;
            TheUI.Instance.ShopButton2.interactable=true;
            TheUI.Instance.ShopButton3.interactable=true;
            TheUI.Instance.ShopButton4.interactable=false;
    }
}*/
    private void OnMouseExit()
    {
        if (AgumentManager.Instance.isOpenTab) return;
        if (turret)
        {
            if (!isGoldMineNode)
                turret.GetComponent<Tower>().rangeObject.SetActive(false);
        }

        rend.material.color = StartColor;
    }
}