using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpgradeZapperController : MonoBehaviour
{
    private MainShipController zapperController;
    private Animator anim;
    public GameObject bulletZapper;
    // Start is called before the first frame update
    void Awake()
    {
        zapperController = new MainShipController();
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FireTheLazer()
    {
        Vector3 theBulletPosition = gameObject.transform.position;
        theBulletPosition.y += 0.1f;
        Instantiate(bulletZapper, theBulletPosition, gameObject.transform.rotation);  
    }

    private void FireZapperGun(InputAction.CallbackContext cntx)
    {
        anim.SetBool("isFiringZapper", true);
    }

    private void StopFiringZapperGun(InputAction.CallbackContext cntx)
    {
        anim.SetBool("isFiringZapper", false);
    }

    private void OnEnable()
    {
        zapperController.Ship.Enable();
        zapperController.Ship.FireZapperGun.performed += FireZapperGun;
        zapperController.Ship.FireZapperGun.canceled += StopFiringZapperGun;
    }

    private void OnDisable()
    {
        zapperController.Ship.Disable();
        zapperController.Ship.FireZapperGun.performed -= FireZapperGun;
        zapperController.Ship.FireZapperGun.canceled -= StopFiringZapperGun;
    }
}
