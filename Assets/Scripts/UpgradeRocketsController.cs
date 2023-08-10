using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpgradeRocketsController : MonoBehaviour
{
    private MainShipController rocketsController;
    private Animator anim;
    public GameObject bulletRocket;
    // Start is called before the first frame update
    void Awake()
    {
        rocketsController = new MainShipController();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void FireLeftInsideRocket()
    {   
        Vector3 theBulletPosition = gameObject.transform.position;
        theBulletPosition.x -= 0.0625f;
        theBulletPosition.y += 0.01f;
        Instantiate(bulletRocket, theBulletPosition, gameObject.transform.rotation);
    }

    public void FireLeftMiddleRocket()
    {   
        Vector3 theBulletPosition = gameObject.transform.position;
        theBulletPosition.x -= 0.104f;
        theBulletPosition.y -= 0.03f;
        Instantiate(bulletRocket, theBulletPosition, gameObject.transform.rotation);
    }

    public void FireLeftOutsideRocket()
    {   
        Vector3 theBulletPosition = gameObject.transform.position;
        theBulletPosition.x -= 0.145f;
        theBulletPosition.y -= 0.074f;
        Instantiate(bulletRocket, theBulletPosition, gameObject.transform.rotation);
    }
    
    public void FireRightInsideRocket()
    {   
        Vector3 theBulletPosition = gameObject.transform.position;
        theBulletPosition.x += 0.073f;
        theBulletPosition.y += 0.01f;
        Instantiate(bulletRocket, theBulletPosition, gameObject.transform.rotation);
    }

    public void FireRightMiddleRocket()
    {   
        Vector3 theBulletPosition = gameObject.transform.position;
        theBulletPosition.x += 0.114f;
        theBulletPosition.y -= 0.03f;
        Instantiate(bulletRocket, theBulletPosition, gameObject.transform.rotation);
    }

    public void FireRightOutsideRocket()
    {   
        Vector3 theBulletPosition = gameObject.transform.position;
        theBulletPosition.x += 0.157f;
        theBulletPosition.y -= 0.074f;
        Instantiate(bulletRocket, theBulletPosition, gameObject.transform.rotation);
    }

    private void StartFiringRockets(InputAction.CallbackContext cntx)
    {
        //Debug.Log("should start firing rockets");
        anim.SetBool("isFiringRockets", true);
    }

    private void StopFiringRockets(InputAction.CallbackContext cntx)
    {
        //Debug.Log("------------- stop rocket firing ---------");
        anim.SetBool("isFiringRockets", false);
    }

    private void OnEnable()
    {
        rocketsController.Ship.Enable();
        rocketsController.Ship.FireRockets.performed += StartFiringRockets;
        rocketsController.Ship.FireRockets.canceled += StopFiringRockets;
    }

    private void OnDisable()
    {
        rocketsController.Ship.Disable();
        rocketsController.Ship.FireRockets.performed -= StartFiringRockets;
        rocketsController.Ship.FireRockets.canceled -= StopFiringRockets;
    }
}
