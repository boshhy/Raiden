using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTorpedoController : MonoBehaviour
{
    public bool fireNow = false;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (BossMovementController.instance.isStopped && BossHealthController.instance.tag != "Dead")
        {
            Instantiate(bullet, transform.position + new Vector3(-1.2f, 0.5f, 0.0f), bullet.transform.rotation);
            Instantiate(bullet, transform.position + new Vector3(1.2f, 0.5f, 0.0f), bullet.transform.rotation);
            
            if (BossHealthController.instance.canDoubleTorpedo)
            {
                Instantiate(bullet, transform.position + new Vector3(-2f, 0.5f, 0.0f), bullet.transform.rotation);
                Instantiate(bullet, transform.position + new Vector3(2f, 0.5f, 0.0f), bullet.transform.rotation);
            }

            if (BossHealthController.instance.canTripleTorpedo)
            {
                Instantiate(bullet, transform.position + new Vector3(-2.8f, 0.5f, 0.0f), bullet.transform.rotation);
                Instantiate(bullet, transform.position + new Vector3(2.8f, 0.5f, 0.0f), bullet.transform.rotation);
            }

            BossMovementController.instance.isStopped = false;
        }
    }
}