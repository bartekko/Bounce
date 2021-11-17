using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{   
    public GameObject spawnee;
    private float NextSpawnTime;
    public float SpawnDelay=1;
        public bool ScalerEnable;
        public float MinScale;
        public float MaxScale;
    // Start is called before the first frame update
    void Start()
    {  
        NextSpawnTime=Time.time;
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown("q"))
        {
            SpawnDelay*=0.8f;
        }
        if (Input.GetKeyDown("w"))
        {
            SpawnDelay*=1.25f;
        }

        float t= Time.time;
    //    float newScale;
      //  if(ScalerEnable)
        //{newScale=MinScale+MaxScale*(1+Mathf.Sin(2*Mathf.PI*(NextSpawnTime-t/(SpawnDelay))));}
        //else newScale=MinScale;

        //transform.localScale = new Vector2(newScale,newScale);
        if(t>=NextSpawnTime)
        {
          NextSpawnTime+=SpawnDelay;
          Instantiate(spawnee,transform.position,Quaternion.Euler(0,0,0));
        }
    }
}
