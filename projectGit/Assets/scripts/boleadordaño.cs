using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boleadordaño : MonoBehaviour
{
     GameObject player;
   
     


     
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");  
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }
       void OnTriggerEnter2D(Collider2D other)
      {
          if(other.tag==("Player"))
          {
               player.GetComponent<Stats>().life-=1;
               Debug.Log("estas dañando al jugador"); 

          }
          
      }
   
  
}
