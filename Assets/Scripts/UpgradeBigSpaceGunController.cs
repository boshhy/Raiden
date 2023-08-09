using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpgradeBigSpaceGunController : MonoBehaviour
{
    private MainShipController bigSpaceGunController;
    private Animator anim;
    public GameObject bulletBigSpaceGun;
    // Start is called before the first frame update
    void Awake()
    {
        bigSpaceGunController = new MainShipController();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FireBullet()
    {
        Instantiate(bulletBigSpaceGun, gameObject.transform.position, gameObject.transform.rotation);
    }

    private void FireBigSpaceGun(InputAction.CallbackContext cntx)
    {
        anim.SetBool("isFiringBigSpaceGun", true);
    }

    private void StopFiringBigSpaceGun(InputAction.CallbackContext cntx)
    {
        anim.SetBool("isFiringBigSpaceGun", false);
    }

    private void OnEnable()
    {
        bigSpaceGunController.Ship.Enable();
        bigSpaceGunController.Ship.FireBigSpaceGun.performed += FireBigSpaceGun;
        bigSpaceGunController.Ship.FireBigSpaceGun.canceled += StopFiringBigSpaceGun;
    }

    private void OnDisable()
    {
        bigSpaceGunController.Ship.Disable();
        bigSpaceGunController.Ship.FireBigSpaceGun.performed -= FireBigSpaceGun;
        bigSpaceGunController.Ship.FireBigSpaceGun.canceled -= StopFiringBigSpaceGun;
    } 
}
