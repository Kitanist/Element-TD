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

  

    private void Start()
    {
       
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
        
    }
    public Vector3 GetBuildPosition() // kule pozisyonu ayarlaması
    {
        return transform.position + pozisyonOffset;
    }
    private void OnMouseEnter() // mouse node a girince
    {
      
      
    
      if(turret)
      turret.GetComponent<Tower>().rangeObject.SetActive(true); 
       
       

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
            TheUI.Instance.ShopUIClose();
               Invoke("OpenUIUTower",.6f);
            
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
}
    private void OnMouseExit()
    {
    
        if(turret)
        turret.GetComponent<Tower>().rangeObject.SetActive(false);
        rend.material.color = StartColor;
    }
} 
