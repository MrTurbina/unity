using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbital : MonoBehaviour
{

    GameObject boleador;

  
    void Start()
    {
       boleador= GameObject.Find("Boloador");
    }

    void Update()
    {
        transform.RotateAround(boleador.transform.position,Vector3.back, 200 * Time.deltaTime);
    }
}
