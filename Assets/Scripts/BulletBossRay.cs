using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBossRay : MonoBehaviour
{
    public float speed;
    public GameObject bulletExplosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Destroy bullet when it comes in contact with an object
        if (other.tag == "Raiden")
        {
            Destroy(gameObject);
            // TODO FIX THE POSITION OF
            Instantiate(bulletExplosion, gameObject.transform.position, gameObject.transform.rotation);
            RaidenHealthController.instance.DealDamage();
            // Instantiate(bulletExplosion, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
