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
    public Vector3 GetBuildPosition()
    {
        return transform.position + pozisyonOffset;
    }
    private void OnMouseEnter()
    {
        Debug.Log("Girdim");
      if (!BuildManager.Instance.CanBuild)
          return;
      if (EventSystem.current.IsPointerOverGameObject())
          return;
      if(turret)
      turret.GetComponent<Tower>().rangeObject.SetActive(true);
        if (BuildManager.Instance.HasMoney)
        {
            rend.material.color = HoverColor;
        }
        else
        {
            rend.material.color = NotHaveMoneyColor;
        }
        
        
    }
    private void OnMouseDown()
    {
        if (!BuildManager.Instance.CanBuild)
            return;
        if (turret != null)
        {
          
            Debug.Log("Gardas buraya kule yapaman");
            return;
            // kule menusu buradan a��lacak
        }
        BuildManager.Instance.BuildTowerOn(this);
    }

    private void OnMouseExit()
    {
        Debug.Log("ciktim");
        if(turret)
        turret.GetComponent<Tower>().rangeObject.SetActive(false);
        rend.material.color = StartColor;
    }
} 
