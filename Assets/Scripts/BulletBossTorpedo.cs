using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBossTorpedo : MonoBehaviour
{
    public GameObject bulletExplosion;
    public float stallTime = 2.0f;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stallTime <= 0)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            stallTime -= Time.deltaTime;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // Destroy bullet when it comes in contact with an object
        if (other.tag == "Raiden")
        {
            Destroy(gameObject);
            Instantiate(bulletExplosion, gameObject.transform.position, gameObject.transform.rotation);
            RaidenHealthController.instance.DealDamage();
            // Instantiate(bulletExplosion, gameObject.transform.position, gameObject.transform.rotation);
        }
        else if (other.tag == "Shield")
        {
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        } 
    }
}
