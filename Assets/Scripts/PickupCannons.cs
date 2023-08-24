using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCannons : MonoBehaviour
{
    public GameObject Cannons;
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
            Instantiate(Cannons, other.transform);
            Destroy(gameObject);
            AudioManager.instance.PlaySFX(3);
        }
    }
}
