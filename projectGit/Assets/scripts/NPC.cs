using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float Speed = 10;
 Vector3 wayPoint;
 float Range= 10;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.tag == Tags.Untagged) {
            gameObject.transform.tag = Tags.Enemy;
        }
         
    }

    // Update is called once per frame
    void Update()
    {
     // transform.position += transform.TransformDirection(Vector3.forward)*Speed*Time.deltaTime;
     if((transform.position - wayPoint).magnitude < 3)
     {
         // when the distance between us and the target is less than 3
         // create a new way point target
         Wander();
 
 
     }   
    }
     void Wander()
 { 
    // does nothing except pick a new destination to go to
     
     wayPoint=  new Vector2(Random.Range(transform.position.x - Range, transform.position.x + Range), Random.Range(transform.position.y - Range, transform.position.y + Range));
     wayPoint.z = 0;
    // don't need to change direction every frame seeing as you walk in a straight line only
     transform.LookAt(wayPoint);
     Debug.Log(wayPoint + " and " + (transform.position - wayPoint).magnitude);
 }
}
