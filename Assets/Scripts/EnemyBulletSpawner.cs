using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawner : MonoBehaviour
{
    private float time = 0.0f;
    public float interpolationPeriod = 4.0f;
    public GameObject hitExplosion;

    public GameObject enemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        time = interpolationPeriod;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = time - interpolationPeriod;
            Instantiate(enemyBullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Raiden")
        {
            // TODO Add explosion effect for enemy crash into Raiden
            Instantiate(hitExplosion, transform.position, transform.rotation);
            Debug.Log("raiden should be dealt damage");
            Destroy(gameObject);
            RaidenHealthController.instance.DealDamage();
        }
    }
}
