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

    // Used to Spawn a lazer
    private void FireTheLazer()
    {
        Vector3 theBulletPosition = gameObject.transform.position;
        theBulletPosition.y += 0.1f;
        Instantiate(bulletZapper, theBulletPosition, gameObject.transform.rotation);
        AudioManager.instance.PlaySFX(8);  
    }

    // used to change animation to "always fire"
    private void ChangeAnimToKeepFiring()
    {
        //Debug.Log("in the change animation function");
        anim.SetInteger("zapperAnimation", 2);
    }

    // start firing gun
    private void StartFiringZapperGun(InputAction.CallbackContext cntx)
    {
        //Debug.Log("in the startfire function");
        anim.SetInteger("zapperAnimation", 1);
    }

    // Stop firing gun
    private void StopFiringZapperGun(InputAction.CallbackContext cntx)
    {
        //Debug.Log("in the stop firing function");
        anim.SetInteger("zapperAnimation", 0);
    }

    private void OnEnable()
    {
        zapperController.Ship.Enable();
        zapperController.Ship.FireZapperGun.started += StartFiringZapperGun;
        zapperController.Ship.FireZapperGun.canceled += StopFiringZapperGun;
    }

    private void OnDisable()
    {
        zapperController.Ship.Disable();
        zapperController.Ship.FireZapperGun.started -= StartFiringZapperGun;
        zapperController.Ship.FireZapperGun.canceled -= StopFiringZapperGun;
    }
}
