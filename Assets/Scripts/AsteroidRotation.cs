using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotation : MonoBehaviour
{
    public float speed = 1.0f;
    private float rotationAmount = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rotationAmount +=  speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0,0, rotationAmount);
        transform.position += new Vector3(0.0f, -speed*0.01f * Time.deltaTime, 0.0f);
    }
}
