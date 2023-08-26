using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgumentManager : MonoSingeleton <AgumentManager>
{
    public  Agument_SO[] aquments;
 
}
public enum AqumentType
{
    Tower,
    Army
}
