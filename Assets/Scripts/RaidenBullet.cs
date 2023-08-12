using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaidenBullet : MonoBehaviour
{
    // Controls the speed of the bullet
    public float speed;
    // public GameObject bulletExplosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the bullet
        // transform.position += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);  
        transform.Translate(Vector3.up * speed * Time.deltaTime);  
    }

    // Used to hurt player
    void OnTriggerEnter2D(Collider2D other)
    {
        // Destroy bullet when it comes in contact with an object
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
            // Instantiate(bulletExplosion, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
