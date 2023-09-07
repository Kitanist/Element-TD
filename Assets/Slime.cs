using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class Slime : MonoBehaviour
{
    // Start is called before the first frame update
 

    private void Start() {
       yoyoYoYo(); 
    }
    public void yoyoYoYo()
    {
        transform.DOMoveY(2, 1f, false).SetLoops(-1, LoopType.Yoyo);
    }
    
}
