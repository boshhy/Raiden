using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRockets : MonoBehaviour
{
    public GameObject rockets;
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
            Instantiate(rockets, other.transform);
            Destroy(gameObject);
            AudioManager.instance.PlaySFX(3);
        }
    }
}
