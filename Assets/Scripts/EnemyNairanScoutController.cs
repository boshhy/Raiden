using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNairanScoutController : MonoBehaviour
{
    public float shipSpeed = 5.0f;
    public float shipDownwardSpeed = 1.0f;


    public Transform pointA;
    public Transform pointB;

    public bool movingLeft = true;
    
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.y, -shipDownwardSpeed);

        if (movingLeft)
        {


            // move the pig left by pigSpeed
            rb.velocity = new Vector2(-shipSpeed, rb.velocity.y);

            // If pig reaches the pointA, change his direction
            if(transform.position.x < pointA.position.x)
            {
                movingLeft = false;
            }
        }
        // Pig is moving right
        else
        {
            rb.velocity = new Vector2(shipSpeed, rb.velocity.y);

            if(transform.position.x > pointB.position.x)
            {
                movingLeft = true;
            }
        }
    }
}
