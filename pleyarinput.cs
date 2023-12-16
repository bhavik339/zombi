using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pleyarinput : MonoBehaviour
{
   
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           RaycastHit2D hit = Physics2D.Raycast(ray.origin , ray.direction);
           if(hit.collider != null){
            if(hit.collider.tag == "Enemy"){
                Debug.Log(hit.collider.tag);
                gameObject.GetComponent<GameControal>().KillEnemy();
            }else  if(hit.collider.tag == "Hart"){
                Debug.Log(hit.collider.tag);
                gameObject.GetComponent<GameControal>().KillEnemy();
            }
           }
        }

    }
}
