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

    BuildManager BM;

    private void Start()
    {
       
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
        BM = BuildManager.instance;
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + pozisyonOffset;
    }
    private void OnMouseEnter()
    {
        Debug.Log("Girdim");
      if (!BM.CanBuild)
          return;
      if (EventSystem.current.IsPointerOverGameObject())
          return;

        if (BM.HasMoney)
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
        if (!BM.CanBuild)
            return;
        if (turret != null)
        {
            Debug.Log("Gardas buraya kule yapaman");
            return;
            // kule menusu buradan açýlacak
        }
        BM.BuildTowerOn(this);
    }

    private void OnMouseExit()
    {
       
        rend.material.color = StartColor;
    }
} 
