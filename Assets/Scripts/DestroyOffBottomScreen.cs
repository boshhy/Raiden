using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffBottomScreen : MonoBehaviour
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
        if(other.tag == "Kill Zone For Objects")
        {
            Destroy(gameObject);
        }
    }
}
