
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color HoverColor;
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
    private void OnMouseExit()
    {
        rend.material.color = StartColor;
    }
} 
