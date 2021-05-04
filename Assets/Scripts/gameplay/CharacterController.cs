using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public GameState controller;

    private Rigidbody2D rb;
    public float dashspeed;
    private float dashTime;
    public float startDashTime;
    private int direction = 0;
    public float recoilTime = 1;
    Vector3 charScale;

    public Transform launchOffset;
    public Bullet bullet;   
    public Bullet bullet1;   

    public int maxlife;
    private int life;
    public int ammo;
    void Start()
    {
        life = maxlife;
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        charScale = transform.localScale;
    }

    private void Update()
    {
        if (controller.playing)
        {
            if (!controller.pause)
            {
                transform.localScale = charScale;
                {
                    if (direction == 0)
                    {
                        if (Input.GetKeyDown(KeyCode.LeftArrow))
                        {
                            direction = -1;
                            charScale.x = 1;
                            Instantiate(bullet1, launchOffset.position, transform.rotation);
                        }
                        else if (Input.GetKeyDown(KeyCode.RightArrow))
                        {
                            direction = 1;
                            rb.velocity = Vector2.left * dashspeed;
                            Instantiate(bullet, launchOffset.position, transform.rotation);
                        }


                    }
                    else
                    {
                        if (dashTime <= 0)
                        {
                            direction = 0;
                            dashTime = startDashTime;
                            rb.velocity = Vector2.zero;
                        }
                        else
                        {
                            dashTime -= Time.deltaTime;

                            if (direction == 1)
                            {

                                charScale.x = -1;
                            }
                            else if (direction == -1)
                            {
                                rb.velocity = Vector2.right * dashspeed;

                            }
                        }
                    }
                }
            }
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<ZombieHealth>();

        print("collision");
        if (enemy)
        {
            life--;
            Destroy(enemy.gameObject);
        }

        
    }
}
