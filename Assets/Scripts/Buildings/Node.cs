using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color HoverColor;
    public Color NotHaveMoneyColor;
    public Vector3 pozisyonOffset;
    public int cost;

    public GameObject turret;
   [HideInInspector] public MeshRenderer mrenderer;
    public GameEvent OnAgumentEvent;
    private Renderer rend;
   
    private Color StartColor;

    //public bool isGoldMineNode = false;


    private void Start()
    {
        mrenderer = GetComponent<MeshRenderer>();
        rend = GetComponent<Renderer>();
     
            StartColor = rend.material.color;
        
    }

    public Vector3 GetBuildPosition() // kule pozisyonu ayarlaması
    {
        return transform.position + pozisyonOffset;
    }

    private void OnMouseEnter() // mouse node a girince
    {
        if (AgumentManager.Instance.isOpenTab) return;
       
            if (turret)
                turret.GetComponent<Tower>().rangeObject.SetActive(true);

      
      

    }


    private void OnMouseDown() // Agument Eventini Başlat
    {
        if (AgumentManager.Instance.isOpenTab) return;
        if (turret) return;  
        BuildManager.Instance.node = this;
        OnAgumentEvent.Raise();
       


       
    }

    private void OnMouseExit()
    {
        if (AgumentManager.Instance.isOpenTab) return;
        if (turret)
        {
           
                turret.GetComponent<Tower>().rangeObject.SetActive(false);
        }

        rend.material.color = StartColor;
      
        BuildManager.Instance.node = null;
    }

  
}