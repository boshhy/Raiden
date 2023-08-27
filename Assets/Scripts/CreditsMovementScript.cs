using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMovementScript : MonoBehaviour
{
    private float speed = 108.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.0f, -speed * Time.deltaTime, 0.0f); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Kill Zone For Objects")
        {
            Destroy(gameObject);
        }
    }
}
