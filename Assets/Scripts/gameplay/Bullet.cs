using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private CharacterController controller;
    public float speed;
    public float timeToDisappear;
    public int direction = 1;
    public void Start()
    {
        var character = FindObjectOfType<CharacterController>().transform;
        Physics2D.IgnoreCollision(character.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Destroy(gameObject, timeToDisappear);
        controller = FindObjectOfType<CharacterController>();
    }
    public void Update()
    {

        transform.position += transform.right * speed * Time.deltaTime * direction;


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<ZombieHealth>();
       
        if (enemy)
        {
            controller.ReceiveAmmo();
            enemy.receiveDmg();
            Destroy(gameObject);
        }else
        {
            print("collided with character");
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        
    }
}
