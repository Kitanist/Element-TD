using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Agument", menuName = "Aquments/aqument")]
public class Agument_SO : ScriptableObject
{
    public GameObject prefab;
    public Sprite sprite;
    public string agumentName;
    public string agumentDescription;
    public int agumentLevel;
    public Element_Type elementType;
    public AqumentType aqumentType;


}
