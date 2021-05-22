using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    private GameState controller;

    public ZombieHealth zombie;
    private float time;
    public float timeToSpawn;
    // Update is called once per frame
    private void Start()
    {
        controller = FindObjectOfType<GameState>();
        time = timeToSpawn;
    }
    void Update()
    {
        if (controller.playing)
        {
            if (controller.pause == false)
            {
                if (time <= 0)
                {
                    Instantiate(zombie, transform.position, transform.rotation);
                    time = timeToSpawn;
                }
                else
                {
                    time -= Time.deltaTime;
                }
            }
        }

        
        
    }
}
