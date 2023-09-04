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
      // yoyoYoYo(); 
    }
    public void yoyoYoYo()
    {
        transform.DOMoveY(2, 2f, false).SetLoops(99, LoopType.Yoyo);
    }
    
}
