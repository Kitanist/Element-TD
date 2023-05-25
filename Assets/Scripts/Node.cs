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
        

        if (turret != null)
        {
          
         //   Debug.Log("Gardas buraya kule yapaman");
           
            // kule menusu buradan a��lacak
        }
        else
        {
            TheUI.Instance.ControlTheUI();
            // shopopen
        }

    }

    private void OnMouseExit()
    {
    
        if(turret)
        turret.GetComponent<Tower>().rangeObject.SetActive(false);
        rend.material.color = StartColor;
    }
} 
