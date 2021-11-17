using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graviter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
     if(Input.GetKeyDown("a"))
     {
       Physics2D.gravity=Physics2D.gravity*1.25f;
     }
     if(Input.GetKeyDown("s"))
     {
       Physics2D.gravity=Physics2D.gravity*0.8f;
     }   
   
    }
}
