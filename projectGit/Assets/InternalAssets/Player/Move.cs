using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;

    private float speed;
    
    void Start()
    {
        Rigidbody2D =GetComponent<Rigidbody2D>();
    }
    public void SetSpeed(float value) {
        speed = value;
    }

    void FixedUpdate()
    {
        Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"), 0);
        Rigidbody2D.velocity = playerInput.normalized * speed * Time.deltaTime;
    }
}
