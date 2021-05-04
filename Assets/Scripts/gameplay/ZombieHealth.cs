using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{

    public float speed;
    public int direction = 1;

    public int maxHealth;
    private int health;

    private GameState controller;
    void Start()
    {
        health = maxHealth;
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
    }

    void Update()
    {
        if (!controller.pause)
        {
            if (controller.playing)
            {
                if (health <= 0)
                {
                    Destroy(gameObject);
                }

                if (direction == -1)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                transform.position += transform.right * speed * Time.deltaTime * direction;
            }
        }
        
    }

    public void receiveDmg()
    {
        health--;
    }
}
