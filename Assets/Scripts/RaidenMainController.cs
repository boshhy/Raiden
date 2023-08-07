using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaidenMainController : MonoBehaviour
{
    private MainShipController shipController;
    private Rigidbody2D rb2d;
    private Vector2 inputVector = Vector2.zero;
    public float shipSpeed = 10.0f;

    // Start is called before the first frame update
    void Awake()
    {
        shipController = new MainShipController();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // inputVector = shipController.Ship.Move.ReadValue<Vector2>();
        //Debug.Log(inputVector);
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
            rb2d.velocity = new Vector2(inputVector.x * shipSpeed,inputVector.y * shipSpeed);
        }
        Debug.Log(rb2d.velocity);

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
