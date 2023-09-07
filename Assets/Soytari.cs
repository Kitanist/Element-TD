using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soytari : MonoBehaviour
{
    // Start is called before the first frame update
 
private void OnEnable() {
    int ran=Random.Range(0,3);
    switch(ran){
        case 0:
        GetComponent<Animator>().SetTrigger("Dance1");
        break;
        case 1:
         GetComponent<Animator>().SetTrigger("Dance2");
        break;
        case 2:
         GetComponent<Animator>().SetTrigger("Dance3");
        break;
    }
}

}
