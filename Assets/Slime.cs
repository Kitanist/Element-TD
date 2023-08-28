using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Slime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        yoyoYoYo();
        
    }

    public void yoyoYoYo()
    {
        transform.DOMoveY(2, .5f, false).SetLoops(99,LoopType.Yoyo);
    }
    
}
