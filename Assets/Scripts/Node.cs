using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color HoverColor;
    public Vector3 pozisyonOffset;

    private GameObject turret;

    private Renderer rend;
    private Color StartColor;

    BuildManager BM;

    private void Start()
    {
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
        }
        GameObject insaEdilcekKule = BM.GetTower();
        turret = Instantiate(insaEdilcekKule, transform.position - pozisyonOffset , transform.rotation);
    }

    private void OnMouseExit()
    {
        rend.material.color = StartColor;
    }
} 
