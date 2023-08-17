using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTorpedoShipHealthController : MonoBehaviour
{
    private int currentHealth = 40;
    private int maxHealth = 40;
    public GameObject parentHolder;
    //private SpriteRenderer spriteRenderer;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (anim.GetInteger("hurtNumber") != 2)
        {
            anim.SetInteger("hurtNumber", 0);
        }
    }

    void DestoryNairanShip()
    {
        Destroy(parentHolder);
    }

    void SpawnPickup()
    {
        PickupDrop.instance.GetRandomPickupProbability(20, gameObject.transform);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(currentHealth);
        if (gameObject.tag != "Dead") {
            if (other.tag == "Bullet" || other.tag == "Bullet Zapper")
            {
                currentHealth--;
                anim.SetInteger("hurtNumber", 1);
                
                //spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.2f);

                if (currentHealth <= 0)
                {
                    gameObject.tag = "Dead";
                    currentHealth = 0;
                    anim.SetInteger("hurtNumber", 2);
                    // PickupDrop.instance.GetRandomPickupGuaranteed(gameObject.transform);
                    //Destroy(gameObject);
                    //anim.SetBool("isExploding", true);
                }
            }
            if (other.tag == "Bullet Rocket")
            {
                currentHealth -= 3;
                anim.SetInteger("hurtNumber", 1);
                //spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.2f);

                if (currentHealth <= 0)
                {
                    gameObject.tag = "Dead";
                    currentHealth = 0;
                    anim.SetInteger("hurtNumber", 2);
                    //anim.SetBool("isExploding", true);
                }
            }
            if (other.tag == "Bullet Cannon")
            {
                currentHealth -= 5;
                anim.SetInteger("hurtNumber", 1);
                //spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.2f);

                if (currentHealth <= 0)
                {
                    gameObject.tag = "Dead";
                    currentHealth = 0;
                    anim.SetInteger("hurtNumber", 2);
                    //anim.SetBool("isExploding", true);
                }
            }
            if (other.tag == "Bullet Big Space Gun")
            {
                currentHealth -= 20;
                anim.SetInteger("hurtNumber", 1);
                //spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.2f);

                if (currentHealth <= 0)
                {
                    gameObject.tag = "Dead";
                    currentHealth = 0;
                    anim.SetInteger("hurtNumber", 2);
                    //anim.SetBool("isExploding", true);
                }
            }
        }
    }
}
