using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaidenMainController : MonoBehaviour
{
    public static RaidenMainController instance;
    private MainShipController shipController;
    private Rigidbody2D rb2d;
    private Vector2 inputVector = Vector2.zero;
    public float shipSpeed = 3.0f;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        shipController = new MainShipController();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (inputVector == Vector2.zero)
        {
            rb2d.velocity = new Vector2(0.0f, 0.0f);
            rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else
        {
            rb2d.constraints = RigidbodyConstraints2D.None;
            
            if (transform.position.x > -8.8 && transform.position.x < 8.8 && transform.position.y > -4.9 && transform.position.y < 4.9)
            {
                rb2d.velocity = new Vector2(inputVector.x * shipSpeed,inputVector.y * shipSpeed);
            }
            else
            {
                // Bottom-Left
                if(transform.position.x <= -8.8 && transform.position.y <= -4.9)
                {
                    rb2d.velocity = new Vector2(0.0f, 0.0f);
                    //rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
                    
                    if(inputVector.x > 0.0f && inputVector.y > 0.0f)
                    {
                        //rb2d.constraints = RigidbodyConstraints2D.None;
                        rb2d.velocity = new Vector2(inputVector.x * shipSpeed,inputVector.y * shipSpeed);
                    }
                    else if (inputVector.x > 0.0f)
                    {
                        //rb2d.constraints = RigidbodyConstraints2D.None;
                        rb2d.velocity = new Vector2(inputVector.x * shipSpeed, 0.0f);
                    }
                    else if (inputVector.y > 0.0f)
                    {
                        //rb2d.constraints = RigidbodyConstraints2D.None;
                        rb2d.velocity = new Vector2(0.0f, inputVector.y * shipSpeed);
                    }
                }
                // Top-Right
                else if(transform.position.x >= 8.8 && transform.position.y >= 4.9)
                {
                    rb2d.velocity = new Vector2(0.0f, 0.0f);
                    //rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
                    
                    if(inputVector.x < 0.0f && inputVector.y < 0.0f)
                    {
                        //rb2d.constraints = RigidbodyConstraints2D.None;
                        rb2d.velocity = new Vector2(inputVector.x * shipSpeed,inputVector.y * shipSpeed);
                    }
                    else if (inputVector.x < 0.0f)
                    {
                        //rb2d.constraints = RigidbodyConstraints2D.None;
                        rb2d.velocity = new Vector2(inputVector.x * shipSpeed, 0.0f);
                    }
                    else if (inputVector.y < 0.0f)
                    {
                        //rb2d.constraints = RigidbodyConstraints2D.None;
                        rb2d.velocity = new Vector2(0.0f, inputVector.y * shipSpeed);
                    }
                }
                // Bottom-Right
                else if(transform.position.x >= 8.8 && transform.position.y <= -4.9)
                {
                    rb2d.velocity = new Vector2(0.0f, 0.0f);
                    //rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
                    
                    if(inputVector.x < 0.0f && inputVector.y > 0.0f)
                    {
                        //rb2d.constraints = RigidbodyConstraints2D.None;
                        rb2d.velocity = new Vector2(inputVector.x * shipSpeed,inputVector.y * shipSpeed);
                    }
                    else if (inputVector.x < 0.0f)
                    {
                        //rb2d.constraints = RigidbodyConstraints2D.None;
                        rb2d.velocity = new Vector2(inputVector.x * shipSpeed, 0.0f);
                    }
                    else if (inputVector.y > 0.0f)
                    {
                        //rb2d.constraints = RigidbodyConstraints2D.None;
                        rb2d.velocity = new Vector2(0.0f, inputVector.y * shipSpeed);
                    }
                }
                // Top-Left
                else if(transform.position.x <= -8.8 && transform.position.y >= 4.9)
                {
                    rb2d.velocity = new Vector2(0.0f, 0.0f);
                    //rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
                    
                    if(inputVector.x > 0.0f && inputVector.y < 0.0f)
                    {
                        //rb2d.constraints = RigidbodyConstraints2D.None;
                        rb2d.velocity = new Vector2(inputVector.x * shipSpeed,inputVector.y * shipSpeed);
                    }
                    else if (inputVector.x > 0.0f)
                    {
                        //rb2d.constraints = RigidbodyConstraints2D.None;
                        rb2d.velocity = new Vector2(inputVector.x * shipSpeed, 0.0f);
                    }
                    else if (inputVector.y < 0.0f)
                    {
                        //rb2d.constraints = RigidbodyConstraints2D.None;
                        rb2d.velocity = new Vector2(0.0f, inputVector.y * shipSpeed);
                    }
                }
                // Edge Cases
                else if (transform.position.x <= -8.8 && inputVector.x <= 0)
                {
                    rb2d.velocity = new Vector2(0.0f, inputVector.y * shipSpeed);
                }
                else if (transform.position.x >= 8.8 && inputVector.x >= 0)
                {
                    rb2d.velocity = new Vector2(0.0f, inputVector.y * shipSpeed);
                }
                else if (transform.position.y <= -4.9 && inputVector.y <= 0)
                {
                    rb2d.velocity = new Vector2(inputVector.x * shipSpeed, 0.0f);
                }
                else if (transform.position.y >= 4.9 && inputVector.y >= 0)
                {
                    rb2d.velocity = new Vector2(inputVector.x * shipSpeed, 0.0f);
                }
                else
                {
                    rb2d.velocity = new Vector2(inputVector.x * shipSpeed,inputVector.y * shipSpeed);
                }
            }
        }
        //Debug.Log(rb2d.velocity);

    }

    private void MoveShip(InputAction.CallbackContext cntx)
    {
        inputVector = cntx.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        shipController.Ship.Enable();
        shipController.Ship.Move.performed += MoveShip;
        shipController.Ship.Move.canceled += MoveShip;
    }

    private void OnDisable()
    {
        shipController.Ship.Disable();
        shipController.Ship.Move.performed -= MoveShip;
        shipController.Ship.Move.canceled -= MoveShip;
    }
}
