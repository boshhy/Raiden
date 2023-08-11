using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletZapper : MonoBehaviour
{
    public float speed;
    public GameObject bulletZapperExplosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the bullet
        transform.position += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);    
    }

    // Used to hurt player
    void OnTriggerEnter2D(Collider2D other)
    {
        // Destroy bullet when it comes in contact with an object
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
            Vector3 theBulletPosition = gameObject.transform.position;
            theBulletPosition.y += 0.185f;
            Instantiate(bulletZapperExplosion, theBulletPosition, transform.rotation * Quaternion.Euler(0, 0, 90));
        }
    }
}
