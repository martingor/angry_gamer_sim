using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float timeToDisappear;
    public int direction = 1;
    public void Start()
    {
        Destroy(gameObject, timeToDisappear);
    }

    public void Update()
    {

        transform.position += transform.right * speed * Time.deltaTime * direction;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<ZombieHealth>();

        print("collision");
        if (enemy)
        {
            enemy.receiveDmg();
        }

        Destroy(gameObject);
    }
}
