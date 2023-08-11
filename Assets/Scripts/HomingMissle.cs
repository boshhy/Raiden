using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissle : MonoBehaviour
{
    public Transform target;
    public float speed = 5.0f;
    public float rotateSpeed = 200.0f;
    private Rigidbody2D rb;
    public GameObject bulletExplosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (target)
        {
            Vector2 direction = (Vector2)target.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;
        }
        else
        {
            
            rb.angularVelocity = 0.0f;
            rb.velocity = transform.up * speed;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.tag);
        // Destroy bullet when it comes in contact with an enemy
        if (other.tag == "Enemy")
        {   
            Debug.Log("Destroyed by: " + other.tag);

            Destroy(gameObject);
            Instantiate(bulletExplosion, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
