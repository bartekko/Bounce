using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaler : MonoBehaviour
{   
    PointEffector2D pe;
    SpriteRenderer sr;

    void Start()
    {
      pe=GetComponentInChildren<PointEffector2D>();
      sr=GetComponent<SpriteRenderer>();
    }
    void Update() 
    {
     
    }
    void OnMouseOver()
    { 
      if(Input.mouseScrollDelta.y!=0)
      {
        pe.forceMagnitude=pe.forceMagnitude*Mathf.Pow(0.8f,-Input.mouseScrollDelta.y);
        float xs=Mathf.Sqrt(-pe.forceMagnitude)/10;
       
        transform.localScale=new Vector2(xs,xs);
      }
    }
}
