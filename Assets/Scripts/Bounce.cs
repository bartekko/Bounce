using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{   
    private Rigidbody2D rb;
    private Vector2 PrevVel;
    private AudioSource pingSound;
    private AudioSource wrrSound;
    private bool Dampen;
    // Start is called before the first frame update
    void Start()
    {   Dampen=true;
        AudioSource[] cps=GetComponents<AudioSource>();
        if(cps[0].loop)
        {
          pingSound = cps[1];
          wrrSound  = cps[0];
        }
        else
        {
          pingSound = cps[0];
          wrrSound  = cps[1];
        }
        rb=GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    { 
        if(Dampen){Dampen=false; PrevVel=rb.velocity; return;}
        
        wrrSound.volume=Mathf.Pow((PrevVel-rb.velocity).magnitude,2)/10;  
        
        PrevVel=rb.velocity;
        wrrSound.pitch=Mathf.Pow((rb.velocity).magnitude/6,2);
        if (transform.position.y<-30){Destroy(gameObject);}
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.attachedRigidbody==null) return; //Do not interact with non rigidbody collisions

        float alfa=collision.attachedRigidbody.rotation;
        Vector2 normal=new Vector2(-Mathf.Sin(alfa*Mathf.Deg2Rad),Mathf.Cos(alfa*Mathf.Deg2Rad));

        Vector2 rbPrevVel=rb.velocity;
     //   if( Vector2.Dot(rb.velocity, collision.attachedRigidbody.position-rb.position)>0) //moving towards collider, this is to prevent a case where the ball gets stuck inside a line;
        {
          rb.velocity=Vector2.Reflect(rb.velocity,normal);

          if(!Dampen)
          {
            pingSound.volume=(rb.velocity).magnitude/10;
            pingSound.pitch=(rb.velocity-rbPrevVel).magnitude/10;
            pingSound.PlayOneShot(pingSound.clip,pingSound.volume);
            Dampen=true;
          }

        }
 
    }
    void OnTriggerStay2D(Collider2D collision)
    {
      OnTriggerEnter2D(collision);
      //todo: hard-set the velocity parallel to line
    }

}
