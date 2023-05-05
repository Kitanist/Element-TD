
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color HoverColor;
    public Vector3 pozisyonOffset;

    private GameObject turret;

    private Renderer rend;
    private Color StartColor;



    private void Start()
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
    }
    private void OnMouseEnter()
    {
        rend.material.color = HoverColor;
    }
    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Gardaþ buraya kule yapaman");
            return;
        }
        GameObject inþaEdilcekKule = BuildManager.instance.GetTower();
        turret = Instantiate(inþaEdilcekKule, transform.position - pozisyonOffset , transform.rotation);
    }

    private void OnMouseExit()
    {
        rend.material.color = StartColor;
    }
} 
