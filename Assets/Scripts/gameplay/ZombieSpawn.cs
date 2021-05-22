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
        time = RestartTime();
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
                    time = RestartTime();
                }
                else
                {
                    time -= Time.deltaTime;
                }
            }
        }
        
    }
    private float RestartTime()
    {
        return Random.Range(0.5f, timeToSpawn);
    }
}
