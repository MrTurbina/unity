using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    public NPC npc;
    // Start is called before the first frame update


    int randomSpot;
    public Transform[] moveSpots;
public float speed;
private float waitTime;
public float startWaitTime;
///https://www.youtube.com/watch?v=8eWbSN2T8TE
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Rotate(0, 0, 1);
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f) {
            if (waitTime <=0) {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            } else {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
