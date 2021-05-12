using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBeam : MonoBehaviour
{
    public float CoolDown = 10;
    float initTime = 0;
    public float waitTime = 0;
    public float cadence = .2f;
    public float bulletSpeed = 50f;


    // Update is called once per frame
    void Update()
    {
        waitTime += Time.deltaTime;
        if (waitTime > CoolDown) {
            StartCoroutine(Shoot());
            waitTime = 0;
        }
    }
    /* void Shoot() {
        for (int i = 0; i < 4; i++)
        {
            
            // createBullet();
            StartCoroutine(createBullet());
        }
    } */
    IEnumerator Shoot() {
        for (int i = 0; i < 7; i++) {
            
            GameObject bullet = new GameObject();
            bullet.transform.position = transform.position;
            Rigidbody2D rigidBody = bullet.gameObject.AddComponent<Rigidbody2D>();
            // USAR VELOCITI EN UPDATE
            rigidBody.AddForce(Vector2.right * bulletSpeed);
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.SetParent(bullet.transform);
            yield return new WaitForSeconds(cadence);
        }
    }
}
