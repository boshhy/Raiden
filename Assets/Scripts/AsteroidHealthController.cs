using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHealthController : MonoBehaviour
{
    public int currentHealth = 40;
    public int maxHealth = 40;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (anim.GetInteger("hurtNumber") != 2)
        {
            anim.SetInteger("hurtNumber", 0);
        }
        //spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1.0f);
    }

    void DestoryAsteroid()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(currentHealth);
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
            }
        }

        if (other.tag == "Raiden")
        {
            // kill raiden
            RaidenHealthController.instance.KillRaiden();
        }



    }
}
