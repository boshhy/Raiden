using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaidenHealthController : MonoBehaviour
{
    public static RaidenHealthController instance;
    public int currentHealth = 4;
    public int maxHealth = 4;
    public GameObject hitExplosion;

    private float invincibleLength = 0.2f;
    private float invincibleCounter = 0.0f;
    private SpriteRenderer spriteRenderer;
    
    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // If player is Invincible
        if(invincibleCounter > 0)
        {
            // Adjust invincibiliy time
            invincibleCounter -= Time.deltaTime;

            // If we are no longer invincible then change players color back to normal
            //Debug.Log(invincibleCounter);
            if(invincibleCounter <= 0)
            {
                //Debug.Log("Change back to normal color");
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1.0f);
            }
        }
    }

    public void DealDamage()
    {
        if(invincibleCounter <= 0)
        {
            // Play hurt SFX and take away health from player
            // AudioManager.instance.PlaySFX(3);
            currentHealth--;

            // If player health is zero or less kill player
            if (currentHealth <= 0)
            {
                // Change to zero so UI can reference how many hearts to draw
                currentHealth = 0;
                Instantiate(hitExplosion, transform.position, transform.rotation);
                Destroy(gameObject);
                
                // Instantiate a kill effect and respawn player
                // Instantiate(killEffect, transform.position, transform.rotation);
                // LevelManager.instance.RespawnPlayer();
            }
            // Else player need to get hurt
            else
            {
                // Make player invincible for some length of time
                invincibleCounter = invincibleLength;

                // Change opacity so player looks hurt
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.2f);

                // Knock back the player
                //MovementController.instance.KnockBack();
            }
            
            // Update UI controller to display hearts
            //UIController.instance.UpdateHealthDisplay();
        }
    }

    public void KillRaiden()
    {
        currentHealth = 0;
        Instantiate(hitExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
