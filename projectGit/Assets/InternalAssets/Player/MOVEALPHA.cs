using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVEALPHA : MonoBehaviour
{

    public Vector3 Movimiento;
    public float Velocidad;
    public bool transitable;
    public float rayotamaño = 2f;

    public LayerMask mask;

    GameObject Player;
   
    
    // Start is called before the first frame update
    void Start()
    {
       Player= GameObject.Find("Skillorbital");
       transitable=true;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
  
        Movimiento= new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Movimiento, rayotamaño,mask);
        Debug.DrawRay(transform.position, Movimiento*rayotamaño,Color.red);

       

        if (transitable != false)
        {
              Movimiento=Movimiento.normalized;
              transform.position += Movimiento * Velocidad * Time.deltaTime;
        }


         if (hit.collider != null)
        {
             transitable=false;
             Debug.Log("chocaste " + hit.collider.tag);
            
        }
        else{

            transitable=true;
        }


      /*if(Input.GetKeyDown(KeyCode.E))
      {
         
        GetComponent<SKILLBOLEADORA>().ActivSkill();

      }
        
*/

        
    }
}
