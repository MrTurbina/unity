using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 10f;
    public float speed = 3000f;

    private void Awake() {
        // gameObject.SetActive(true);
        
    }
    void Start()
    {
        // Crear creador de bullets porque bullet desaparece de gameobject7
        
    }
    public void Shoot() {
        gameObject.SetActive(true);
        Destroy(gameObject, lifetime);
        var rigidBody = GetComponent<Rigidbody2D>();
        // var rigidBody = gameObject.AddComponent<Rigidbody2D>();
        // var collider = gameObject.AddComponent<Collider2D>();
        // rigidBody.gravityScale = 0;
        // collider.isTrigger = true;
        rigidBody.AddRelativeForce(Vector2.right * speed);
        // rigidBody.velocity = Vector2.right * speed * Time.deltaTime;
    }


private void OnTriggerEnter2D(Collider2D other) {
    // Debug.Log(other.tag);
    if (other.tag == "wall") {
        Destroy(gameObject);
    }
}
    private void OnCollisionEnter2D(Collision2D other) {
        
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "wall") {
            Destroy(gameObject);
        }
    }
}
