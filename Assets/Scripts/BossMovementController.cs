using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementController : MonoBehaviour
{
    // Used to adjust pig speed
    public float speed;

    // Used to keep the pig between two points
    public Transform pointA;
    public Transform pointB;

    // Max time that the pig will move or wait
    public float maxMoveTime;
    public float maxWaitTime;
    
    // Used to keep track of how long the pig has been moving or waiting
    private float currentMoveTime;
    private float currentWaitTime;

    // Used to detect if pig is facing left or right
    public bool movingLeft;
    public bool isStopped = false;

    public bool tenPercentSet = false;
    public bool halfPercentSet = false;

    // Used to reference pigs Rigidbody2D, SpriteRenderer, and Animator    
    private Rigidbody2D rBody;
    private Animator anim;

    public static BossMovementController instance;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentMoveTime = maxMoveTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (BossHealthController.instance.isTenPercentHealth && !tenPercentSet)
        {
            speed = speed * 2f;
            tenPercentSet = true;
        }
        else if (BossHealthController.instance.isHalfHealth && !halfPercentSet)
        {
            speed = speed * 2f;
            halfPercentSet = true;
        }

        // If pig currentMoveTime is greater than zero, then move pig
        if (currentMoveTime > 0)
        {
            // Adjust moveTime
            currentMoveTime = currentMoveTime - Time.deltaTime;

            // If pig is moving left
            if (movingLeft)
            {

                // move the pig left by speed
                rBody.velocity = new Vector2(-speed, rBody.velocity.y);

                // If pig reaches the pointA, change his direction
                if(transform.position.x < pointA.position.x)
                {
                    movingLeft = false;
                }
            }
            // Pig is moving right
            else
            {

                // move the pig right by speed
                rBody.velocity = new Vector2(speed, rBody.velocity.y);

                // If pig reaches the pointB, change his direction
                if(transform.position.x > pointB.position.x)
                {
                    movingLeft = true;
                }
            }

            // If move time has been used up then change pig to wait
            if (currentMoveTime <= 0)
            {
                // Randomly get a wait time between half of maxWaitTime and maxWaitTime
                currentWaitTime = Random.Range(3, maxWaitTime);
                isStopped = true;

                // change animation back to idle
               // anim.SetBool("isMoving", false);
            }
        }
        // If pig currentWaitTime is greater than zero, then keep pig idle
        else if (currentWaitTime > 0)
        {
            // Adjust Wait time
            currentWaitTime = currentWaitTime - Time.deltaTime;

            // Do not move the pig left or right
            rBody.velocity = new Vector2(0.0f, rBody.velocity.y);

            // If wait time has been used up then change pig to move
            if (currentWaitTime <= 0)
            {
                // Randomly get a move time between half of maxMoveTime and maxMoveTime
                currentMoveTime = Random.Range(maxMoveTime * 0.5f, maxMoveTime);
               // anim.SetBool("isMoving", true);
            }
        }
    }
}
