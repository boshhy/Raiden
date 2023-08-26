using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovementController : MonoBehaviour
{
    public float speed = 1.0f;

    public GameObject hitExplosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);  
    }

    void OnTriggerEnter2D(Collider2D other)
    {  
        if (other.tag == "Raiden")
        {
            Instantiate(hitExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            
            RaidenHealthController.instance.DealDamage();
        }
        else if (other.tag == "Shield")
        {
            Instantiate(hitExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }      
    }
}
