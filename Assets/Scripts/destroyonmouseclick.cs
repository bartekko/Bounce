using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyonmouseclick : MonoBehaviour
{
    void OnMouseOver() 
    {
      if(Input.GetMouseButton(1))
      {
        Destroy(gameObject);
      }
    }
}