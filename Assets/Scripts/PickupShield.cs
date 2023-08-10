using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupShield : MonoBehaviour
{
    public GameObject shield;
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
        if (other.tag == "Raiden")
        {
            //Debug.Log("should attach cannons");
            Instantiate(shield, other.transform);
            Destroy(gameObject);
        }
    }
}
