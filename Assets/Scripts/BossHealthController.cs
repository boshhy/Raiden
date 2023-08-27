using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthController : MonoBehaviour
{
    static public BossHealthController instance;
    private int currentHealth = 1000;
    private int maxHealth = 1000;
    public GameObject parentHolder;
    public bool canTripleShot = false;
    public bool canQuintupleShot = false;

    public bool canDoubleTorpedo = false;
    public bool canTripleTorpedo = false;
    public bool isHalfHealth = false;
    public bool isTenPercentHealth = false;
    public GameObject theSpawner;

    public HealthBar healthBar;
    
    //private SpriteRenderer spriteRenderer;
    private Animator anim;
    // Start is called before the first frame update

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        healthBar.SetMaxHealth(maxHealth);
        theSpawner.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (anim.GetInteger("hurtNumber") != 2)
        {
            if ((float)currentHealth/(float)maxHealth >= 0.4f)
            {
                anim.SetInteger("hurtNumber", 0);
            }
            else
            {
                anim.SetInteger("hurtNumber", 3);
            }
        }

        if (!canTripleShot && ((float)currentHealth/(float)maxHealth <= 0.75f))
        {
            canTripleShot = true;
        }

        if (!canQuintupleShot && ((float)currentHealth/(float)maxHealth <= 0.5f))
        {
            canQuintupleShot = true;
        }

        if (!canDoubleTorpedo && ((float)currentHealth/(float)maxHealth <= 0.5f))
        {
            canDoubleTorpedo = true;
        }

        if (!canTripleTorpedo && ((float)currentHealth/(float)maxHealth <= 0.25f))
        {
            canTripleTorpedo = true;
        }

        if (!isHalfHealth && ((float)currentHealth/(float)maxHealth <= 0.5f))
        {
            isHalfHealth = true;
        }

        if (!isTenPercentHealth && ((float)currentHealth/(float)maxHealth <= 0.1f))
        {
            isTenPercentHealth = true;
        }

    }

    void DestoryNairanShip()
    {
        Destroy(parentHolder);
    }

    void SpawnPickup()
    {
        PickupDrop.instance.GetRandomPickupProbability(1, gameObject.transform);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(currentHealth);
        if (other.tag == "Bullet" || other.tag == "Bullet Zapper")
        {
            currentHealth--;
            anim.SetInteger("hurtNumber", 1);
            AudioManager.instance.PlaySFX(1);
            
            //spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.2f);

            if (currentHealth <= 0)
            {
                gameObject.tag = "Dead";
                currentHealth = 0;
                anim.SetInteger("hurtNumber", 2);
                if (healthBar)
                {
                    Destroy(healthBar.gameObject);
                }
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
                if (healthBar)
                {
                    Destroy(healthBar.gameObject);
                }
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
                if (healthBar)
                {
                    Destroy(healthBar.gameObject);
                }
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
                if (healthBar)
                {
                    Destroy(healthBar.gameObject);
                }

                //anim.SetBool("isExploding", true);
            } 
        }

        if (other.tag == "Raiden")
        {
            RaidenHealthController.instance.KillRaiden();
            Destroy(other.gameObject);
        }

        healthBar.SetHealth(currentHealth);
        //Debug.Log("BOSS SHIP HP: " + currentHealth);
    }

    public void PlayExplosionSound()
    {
        AudioManager.instance.PlaySFXNoStop(4);
    }

    public void PlayVictorySound()
    {
        AudioManager.instance.StopBGM();
        AudioManager.instance.PlayBGMNumber(2);
        AudioManager.instance.StartEpicMusic();
        theSpawner.SetActive(true);
    }

    public bool isDead()
    {
        if (currentHealth == 0)
        {
            return true;
        }
        return false;
    }
}
