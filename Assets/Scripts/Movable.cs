using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{   
    Vector2 offset;
    void Setup() 
    {

    }
    void Update() 
    {
            Vector2 tpos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position=tpos+offset;


    }
    void OnMouseDown()
    {
        offset=transform.position-Camera.main.ScreenToWorldPoint(Input.mousePosition);
        enabled=true;
    }
    void OnMouseUp()
    {
        enabled=false;
    }

}
