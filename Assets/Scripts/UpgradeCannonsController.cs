using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpgradeCannonsController : MonoBehaviour
{
    private MainShipController cannonController;
    private Animator anim;
    public GameObject bulletCannon;
    // Start is called before the first frame update
    void Awake()
    {
        cannonController = new MainShipController();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void FireCannonLeft()
    {   
        Vector3 theBulletPosition = gameObject.transform.position;
        theBulletPosition.x -= 0.094f;
        theBulletPosition.y += 0.08f;
        Instantiate(bulletCannon, theBulletPosition, gameObject.transform.rotation);
    }

    public void FireCannonRight()
    {   
        Vector3 theBulletPosition = gameObject.transform.position;
        theBulletPosition.x += 0.094f;
        theBulletPosition.y += 0.08f;
        Instantiate(bulletCannon, theBulletPosition, gameObject.transform.rotation);
    }

    private void FireCannon(InputAction.CallbackContext cntx)
    {
        Debug.Log("should fire Cannon");
        anim.SetBool("isFiringCannon", true);
    }

    private void StopFiringCannon(InputAction.CallbackContext cntx)
    {
        Debug.Log("------------- stop cannon firing ---------");
        anim.SetBool("isFiringCannon", false);
    }

    private void OnEnable()
    {
        cannonController.Ship.Enable();
        cannonController.Ship.FireCannons.performed += FireCannon;
        cannonController.Ship.FireCannons.canceled += StopFiringCannon;
    }

    private void OnDisable()
    {
        cannonController.Ship.Disable();
        cannonController.Ship.FireCannons.performed -= FireCannon;
        cannonController.Ship.FireCannons.canceled -= StopFiringCannon;
    }
}
