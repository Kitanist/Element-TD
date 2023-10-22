using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    public bool isBreakNode=false;
    public PathNode[] nextNodes;
    public PathNode[] pastNodes;

   
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.GetComponent<Unit>() )
        {
            if (other.GetComponent<Unit>().isBackPath && pastNodes.Length > 0) // eger geri donuyorsa geri nodeları kullan
            {
              
                if (!isBreakNode)
                    other.GetComponent<Unit>().nextPathNode = pastNodes[0];
                else
                {
                    var rand = Random.Range(0, pastNodes.Length);
                    other.GetComponent<Unit>().nextPathNode = pastNodes[rand];

                }
               

            }
            else if(!other.GetComponent<Unit>().isBackPath && nextNodes.Length > 0)// ileri gidiyorsa ileri nodları kullan
            {
                if (!isBreakNode)
                    other.GetComponent<Unit>().nextPathNode = nextNodes[0];
                else
                {
                    var rand = Random.Range(0, nextNodes.Length);
                    other.GetComponent<Unit>().nextPathNode = nextNodes[rand];

                }
              
            }

          
        }
    }

}
