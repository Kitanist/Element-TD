using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float time=2;
    public float speed=2;
    private void OnEnable()
    {
        StartCoroutine(InactiveText());
    }
    private void Update() {
        transform.position+=new Vector3(0,speed*Time.deltaTime,0);
    }

    IEnumerator InactiveText(){
        yield return new WaitForSeconds(time);
        if (this.isActiveAndEnabled)
        {
            gameObject.SetActive(false);
            gameObject.transform.SetParent(ObjectPool.Instance.gameObject.transform);
        }
        
    }


}
