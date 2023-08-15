using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovementController : MonoBehaviour
{
    public float speed = 1.0f;
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
       // TODO Maybe add explosion for when bullet hits Raiden
        if (other.tag == "Raiden")
        {
            Destroy(gameObject);
            RaidenHealthController.instance.DealDamage();
        }
    }
}
