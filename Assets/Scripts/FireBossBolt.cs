using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBossBolt : MonoBehaviour
{
    public GameObject bullet;
    private bool isFiring = false;

    private float TimeBeforeFiring = 0.0f;
    private float TimeBetweenBullets = 1.0f;
    public bool canTripleShot = false;
    public bool  canQuintupleShot = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        if (TimeBeforeFiring <= 0.0f && BossHealthController.instance.tag != "Dead")
        {
            TimeBeforeFiring = TimeBetweenBullets;

            if (BossHealthController.instance.canTripleShot)
            {
                 Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, 20));
                 Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, -20));
            }

            if (BossHealthController.instance.canQuintupleShot)
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
}
