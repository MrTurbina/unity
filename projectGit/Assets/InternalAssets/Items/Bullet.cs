using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 10f;
    public float speed = 3000f;


    public void Shoot() {
        gameObject.SetActive(true);
        Destroy(gameObject, lifetime);
        var rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddRelativeForce(Vector2.right * speed);
        // rigidBody.velocity = Vector2.right * speed * 1;
        Debug.DrawRay(transform.position, transform.forward, Color.red, 10f);
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "wall") {
            Destroy(gameObject);
        }
    }
    
}
