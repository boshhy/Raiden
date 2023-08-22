using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBossRockets : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireFirstLeft()
    {
        Instantiate(bullet, transform.position + new Vector3(-0.3f, -1.0f, 0.0f), bullet.transform.rotation * Quaternion.Euler(0, 0, 140));
    }

    public void FireFirstRight()
    {
        Instantiate(bullet, transform.position + new Vector3(0.3f, -1.0f, 0.0f), bullet.transform.rotation * Quaternion.Euler(0, 0, 220));
        Instantiate(bullet, transform.position + new Vector3(-0.24f, -0.55f, 0.0f), bullet.transform.rotation * Quaternion.Euler(0, 0, 140));

    }

    public void FireSecondLeft()
    {
        Instantiate(bullet, transform.position + new Vector3(-0.48f, -0.7f, 0.0f), bullet.transform.rotation * Quaternion.Euler(0, 0, 140));
    }

    public void FireScecondRight()
    {
         Instantiate(bullet, transform.position + new Vector3(0.48f, -0.7f, 0.0f), bullet.transform.rotation * Quaternion.Euler(0, 0, 220));
         Instantiate(bullet, transform.position + new Vector3(-0.57f, -0.2f, 0.0f), bullet.transform.rotation * Quaternion.Euler(0, 0, 140));
    }

    public void FireThirdLeft()
    {
        Instantiate(bullet, transform.position + new Vector3(-0.31f, -0.2f, 0.0f), bullet.transform.rotation * Quaternion.Euler(0, 0, 140));
        Instantiate(bullet, transform.position + new Vector3(0.56f, -0.17f, 0.0f), bullet.transform.rotation * Quaternion.Euler(0, 0, 220));
    }

    public void FireThirdRight()
    {
        Instantiate(bullet, transform.position + new Vector3(0.24f, -0.13f, 0.0f), bullet.transform.rotation * Quaternion.Euler(0, 0, 220));
    }

    public void FireLastRocket()
    {
        Instantiate(bullet, transform.position + new Vector3(0.32f, -0.12f, 0.0f), bullet.transform.rotation * Quaternion.Euler(0, 0, 220));
    }
}
