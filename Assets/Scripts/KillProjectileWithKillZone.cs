using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillProjectileWithKillZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Kill Zone")
        {
            //Debug.Log("Projectile has hit the KILL ZONE");
            Destroy(gameObject);
        }
    }
}
