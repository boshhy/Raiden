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
    public bool canTripleShot = false;
    public bool  canQuintupleShot = false;
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

                if (canTripleShot)
                {
                    Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, 5));
                    Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, -5));
                }

                if (canQuintupleShot)
                {
                    Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, 10));
                    Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, -10));
                }

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PickupTripleShot")
        {
            if (!canTripleShot)
            {
                canTripleShot = true;
            }
            else if (canTripleShot && !canQuintupleShot)
            {
                canQuintupleShot = true;
            }
        }
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
