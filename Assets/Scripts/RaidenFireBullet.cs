using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaidenFireBullet : MonoBehaviour
{
    public GameObject bullet;
    private MainShipController raidenController;
    private bool isFiring = false;

    private float TimeBeforeFiring = 0.0f;
    private float TimeBetweenBullets = 0.02f;
    // Start is called before the first frame update
    void Awake()
    {
        raidenController = new MainShipController();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(isFiring)
        {
            if (TimeBeforeFiring <= 0.0f)
            {
                TimeBeforeFiring = TimeBetweenBullets;
                Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
            }
            else
            {
                TimeBeforeFiring -= Time.deltaTime;
            }
        }
        else
        {
            TimeBeforeFiring = 0.0f;
        }
    }

    private void FireBullet(InputAction.CallbackContext cntx)
    {
        isFiring = true;
        //Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
    }

    private void StopFiring(InputAction.CallbackContext cntx)
    {
        isFiring = false;
    }

    private void OnEnable()
    {
        raidenController.Ship.Enable();
        raidenController.Ship.FireBullet.performed += FireBullet;
        raidenController.Ship.FireBullet.canceled += StopFiring;
    }

    private void OnDisable()
    {
        raidenController.Ship.Disable();
        raidenController.Ship.FireBullet.performed -= FireBullet;
        raidenController.Ship.FireBullet.canceled -= StopFiring;
    }
}
