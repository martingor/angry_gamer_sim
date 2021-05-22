//THIS FILE IS FOR PLAYER CONTROLS AND VARIABLES
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //controllers
    private GameState controller;
    private GameInGameManager manager;

    //variables for actions
    private Rigidbody2D rb;
    public float dashspeed;
    private float dashTime;
    public float startDashTime;
    private int direction = 0;
    public float recoilTime = 1;
    Vector3 charScale;

    //game objects for shooting
    public Transform launchOffset;
    public Bullet bullet;
    public Bullet bullet1;

    //player character stats
    public int maxlife = 3;
    private int life;
    public int ammoCount;
    public int maxAmmo = 6;

    //general functions
    void Start()
    {
        life = maxlife;
        ammoCount = maxAmmo;
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        charScale = transform.localScale;
        controller = FindObjectOfType<GameState>();
        manager = FindObjectOfType<GameInGameManager>();
    }
    private void Update()
    {
        if (controller.playing)
        {
            if (!controller.pause)
            {
                if(life == 0)
                {
                    manager.ResetGame();
                    
                }
                manager.ShowAmmoCount(ammoCount, maxAmmo);
                transform.localScale = charScale;
                {
                    if (direction == 0)
                    {
                        if (ammoCount > 0)
                        {
                            if (Input.GetKeyDown(KeyCode.A))
                            {

                                LoseAmmo();
                                direction = -1;
                                charScale.x = 0.25f;
                                Instantiate(bullet1, launchOffset.position, transform.rotation);
                            }
                            else if (Input.GetKeyDown(KeyCode.D))
                            {

                                LoseAmmo();
                                direction = 1;
                                rb.velocity = Vector2.left * dashspeed;
                                Instantiate(bullet, launchOffset.position, transform.rotation);
                            }
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

                                charScale.x = -0.25f;
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

        //print("collision");
        if (enemy)
        {
            ReceiveDamage();
            Destroy(enemy.gameObject);
        }
        else
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }


    }

    //receive damage on collision with zomvbie
    public void ReceiveDamage()
    {
        if (life > 0)
        {
            manager.hearts[life - 1].SetActive(false);
            life--;

        }
    }
    //lose ammo when shooting
    public void LoseAmmo()
    {
        if (ammoCount >= 0)
        {
            
            ammoCount--;

        }
    }
    //add heart to player
    public void Revive()
    {
        if (life < maxlife)
        {
            manager.hearts[life - 1].SetActive(true);
            life++;
        }
    }
    //add ammo to player
    public void ReceiveAmmo()
    {
        if (ammoCount < maxAmmo)
        {
            print(ammoCount);

            ammoCount++;
        }
    }
}
