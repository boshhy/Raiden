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
        Debug.Log("hit: " + other.tag);
        if (other.tag == "Raiden")
        {
            Debug.Log("raiden should be dealt damage");
            Destroy(gameObject);
            RaidenHealthController.instance.DealDamage();
        }
    }
}
