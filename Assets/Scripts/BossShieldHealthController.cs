using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShieldHealthController : MonoBehaviour
{
    private int currentHealth = 400;
    private int maxHealth = 400;
    private Animator anim;
    public HealthBar healthBar;
   // private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        healthBar.SetMaxHealth(maxHealth);
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        anim.SetInteger("hurtNumber", 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(currentHealth);
        if (other.tag == "Bullet" || other.tag == "Bullet Zapper")
        {
            AudioManager.instance.PlaySFX(1);
            currentHealth--;
            anim.SetInteger("hurtNumber", 1);
            
            //spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.2f);

            if (currentHealth <= 0)
            {
                AudioManager.instance.PlaySFX(2);
                currentHealth = 0;
                Destroy(gameObject);
                Destroy(healthBar.gameObject);
            }
        }
        if (other.tag == "Bullet Rocket")
        {
            currentHealth -= 3;
            anim.SetInteger("hurtNumber", 1);
            //spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.2f);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Destroy(gameObject);
                Destroy(healthBar.gameObject);
            }
        }
        if (other.tag == "Bullet Cannon")
        {
            currentHealth -= 5;
            anim.SetInteger("hurtNumber", 1);
            //spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.2f);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Destroy(gameObject);
                Destroy(healthBar.gameObject);
            }
        }
        if (other.tag == "Bullet Big Space Gun")
        {
            currentHealth -= 20;
            anim.SetInteger("hurtNumber", 1);
            //spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.2f);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Destroy(gameObject);
                Destroy(healthBar.gameObject);
            }
        }
        if (other.tag == "Raiden")
        {
            RaidenHealthController.instance.KillRaiden();
            Destroy(other.gameObject);
            Destroy(healthBar.gameObject);
        }

        healthBar.SetHealth(currentHealth);
    }
}
