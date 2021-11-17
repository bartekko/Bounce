using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineAdder : MonoBehaviour
{
    public GameObject spawnee;
    public GameObject spawnee2;
    GameObject tempLine;
    GameObject tempBall;
    Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnMouseOver()
    {     
        if(Input.GetMouseButtonDown(0))
        {
          startPosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
          tempLine=Instantiate(spawnee);//length
        }
        if(Input.GetMouseButton(0))
        { 
          if (tempLine==null) return;
        //Calculate position 
          Vector2 endPosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
          Vector2 midpoint=(startPosition+endPosition)/2;
        //Calculate spin
          float rotation = Vector2.SignedAngle(endPosition-startPosition,Vector2.right);
          Quaternion spin = Quaternion.Euler(0,0,-rotation);
        //Calculate size
          float length = (startPosition-endPosition).magnitude;
        //Transform the line accordingly
          tempLine.transform.position=midpoint;
          tempLine.transform.rotation=spin;
          tempLine.transform.localScale=new Vector2(length,0.015f);

        }
        if(Input.GetMouseButtonUp(0))
        {
           tempLine=null; 
        }


     if(Input.GetMouseButtonDown(2))
        {
          startPosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
          tempBall=Instantiate(spawnee2);//length
        }
        if(Input.GetMouseButton(2))
        { 
          Vector2 v = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          tempBall.transform.position=v;
        }
        if(Input.GetMouseButtonUp(2))
        {
          tempBall.GetComponent<CircleCollider2D>().enabled=true;
          tempBall=null; 
        }

    }

}
