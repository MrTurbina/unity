using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUB : MonoBehaviour
{
    public Player player;
    public int life;
    int maxLife;
    Stats stats;

    public Image[] hearts = new Image[5];
    public bool[] activeHearts = new bool[5];
    void Start()
    {

        stats = player.GetComponent<Stats>();

        //heart.active(false);
        //Vector3 hearthPosition = new Vector3(40, -20 , 0);
        // newHeart = Instantiate<Image>(heart, transform);
        // newHeart.transform.position = hearthPosition.normalized;
        // newHeart.transform.localPosition = hearthPosition;


        // newHeart.transform.localScale = new Vector3(zoom, zoom, 1);
    }
    private void Awake()
    {

        // DrawLife();
        // Destroy(heart);
    }
    // Update is called once per frame
    void Update()
    {
        life = stats.life;
        maxLife = stats.maxLife;

        updateLife();
    }

    void updateLife() {
        foreach (Image heart in hearts)
        {
            heart.enabled = false;
        }
        for (int i = 0; i < maxLife; i++)
        {
            Image heart = hearts[i];
            heart.color = Color.white;
            heart.enabled = true;
            if (i > life -1)
            {

                heart.color = Color.black;
            }
        }
    }
}
