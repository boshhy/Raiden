using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCannon : MonoBehaviour
{
    // Controls the speed of the bullet
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the bullet
        transform.position += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);    
    }

    // Used to hurt player
    void OnTriggerEnter2D(Collider2D other)
    {
        // Destroy bullet when it comes in contact with an object
        if (other.tag != "Raiden")
        {
            Destroy(gameObject);
        }
    }
}
