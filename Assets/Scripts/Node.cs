using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color HoverColor;
    public Color NotHaveMoneyColor;
    public Vector3 pozisyonOffset;

    
    public GameObject turret;

    private Renderer rend;
    private Color StartColor;

    public bool isGoldMineNode=false;
  

    private void Start()
    {
        rend = GetComponent<Renderer>();
       if(!isGoldMineNode){
        
        StartColor = rend.material.color;
       }
       else{
        StartColor=rend.material.color;
       }
       
        
    }
    public Vector3 GetBuildPosition() // kule pozisyonu ayarlaması
    {
        return transform.position + pozisyonOffset;
    }
    private void OnMouseEnter() // mouse node a girince
    {
      if(!isGoldMineNode){
            if(turret)
      turret.GetComponent<Tower>().rangeObject.SetActive(true); 
      }
      
       
       

    }
    private void OnMouseDown()
    {
    //   if (!BuildManager.Instance.CanBuild)
    //       return;
        BuildManager.Instance.node = this;
        
        // upgrade ve insa bolgeleri ayarlandi
     
            
         if (turret)
        {   
            TheUI.Instance.ShopUIClose();
                Invoke("OpenUIUpgrade",.6f);
         
        }
        else
        {
            
               if(!isGoldMineNode){
            TheUI.Instance.ShopUIClose();
            Invoke("OpenUIUTower",.6f);
               }
               else{
            TheUI.Instance.ShopUIClose();
            Invoke("OpenUIUTower",.6f);
           
               }
          
            
        }
        
        
       

    }
     public void OpenUIUpgrade () {
    TheUI.Instance.isTurret = false;
    TheUI.Instance.isUpgrade = true;
    TheUI.Instance.isArmy = false;
    TheUI.Instance.ShopUIOpen();
}
  public void OpenUIUTower () {
    TheUI.Instance.isTurret = true;
    TheUI.Instance.isUpgrade = false;
    TheUI.Instance.isArmy = false;
    TheUI.Instance.ShopUIOpen();
    
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
}
    private void OnMouseExit()
    {
    
        if(turret){
            if(!isGoldMineNode)
             turret.GetComponent<Tower>().rangeObject.SetActive(false);
        }
       
        rend.material.color = StartColor;
    }
} 
