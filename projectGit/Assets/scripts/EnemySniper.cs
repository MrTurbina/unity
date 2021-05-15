using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySniper : MonoBehaviour
{

    public float visionradius;
    public float zonoinsegura;
    public float speed;
   

    GameObject player;

    Vector3 inicialposition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");        
    }

    // Update is called once per frame
    void Update()
    {
        float fixedSpeed = speed*Time.deltaTime;
        Vector3 target = inicialposition;
        target=player.transform.position;

        float dist=Vector3.Distance(player.transform.position,transform.position);
        if(dist<=visionradius)
        {
            
            Debug.Log("Esats viendo al enemigo");
         

        }
        else{
            
            transform.position = Vector3.MoveTowards(transform.position,target,fixedSpeed);
        } 

        
       
    }
     void OnDrawGizmos()
    {
        Gizmos.color=Color.yellow;
        Gizmos.DrawWireSphere(transform.position,visionradius);
        
        
    }
  
}
