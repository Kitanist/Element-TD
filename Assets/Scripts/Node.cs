using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color HoverColor;
    public Vector3 pozisyonOffset;
    public GameObject ShopInterface;

    private GameObject turret;

    private Renderer rend;
    private Color StartColor;

    BuildManager BM;

    private void Start()
    {
        ShopInterface = transform.GetChild(0).transform.GetChild(0).gameObject;
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
        BM = BuildManager.instance;
    }
    private void OnMouseEnter()
    {
      if (BM.GetTower() == null)
          return;
      if (EventSystem.current.IsPointerOverGameObject())
          return;
        ShopInterface.SetActive(true);
        rend.material.color = HoverColor;
    }
    private void OnMouseDown()
    {
        if (BM.GetTower() == null)
            return;
        if (turret != null)
        {
            Debug.Log("Gardas buraya kule yapaman");
            return;
            // kule menusu buradan açýlacak
        }
        GameObject insaEdilcekKule = BM.GetTower();
        turret = Instantiate(insaEdilcekKule, transform.position - pozisyonOffset , transform.rotation);
    }

    private void OnMouseExit()
    {
        ShopInterface.SetActive(false);
        rend.material.color = StartColor;
    }
} 
