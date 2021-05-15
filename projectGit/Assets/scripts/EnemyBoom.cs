using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoom : MonoBehaviour
{
    public float visionradius;
    public float speed;

    GameObject player;
     

    

    Vector3 inicialposition;
    // Start is called before the first frame update
    void Start()
    {
        

        player = GameObject.FindGameObjectWithTag("Player");  

        inicialposition = transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = inicialposition;
        float dist=Vector3.Distance(player.transform.position,transform.position);
        if(dist<visionradius)target=player.transform.position;

       float fixedSpeed = speed*Time.deltaTime;
       

       transform.position = Vector3.MoveTowards(transform.position,target,fixedSpeed);


        Debug.DrawLine(transform.position ,target ,Color.blue);

        
        
    }
     void OnDrawGizmos()
    {
        Gizmos.color=Color.yellow;
        Gizmos.DrawWireSphere(transform.position,visionradius);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag==("Player"))
          {
              player.GetComponent<Stats>().life-=2;
              Destroy(gameObject);
          }
        
    }

}
