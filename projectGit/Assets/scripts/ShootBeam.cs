using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBeam : MonoBehaviour
{
    public float CoolDown = 10;
    float initTime = 0;
    float waitTime = 0;
    public int bulletNumber = 3;
    public float cadence = .02f;
    public float bulletSpeed = 50f;
    public GameObject bullet;
    public Transform bulletOrigin;

    void Update()
    {
        waitTime += Time.deltaTime;
        if (waitTime > CoolDown) {
            StartCoroutine(Shoot());
            waitTime = 0;
        }
    }
    IEnumerator Shoot() {
        for (int i = 0; i < bulletNumber; i++) {
            GameObject bull = Instantiate(
                bullet,
                bulletOrigin.position,
                gameObject.transform.rotation
            );
            // bull.transform.rotation = gameObject.transform.rotation;
            // bull.transform.position = gameObject.transform.position;
            

            Bullet bullProps = bull.GetComponent<Bullet>();
            bullProps.speed = bulletSpeed;
            bullProps.Shoot();
            waitTime = 0;
            yield return new WaitForSeconds(cadence );
        }
    }
}
