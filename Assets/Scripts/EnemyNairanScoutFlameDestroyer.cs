using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNairanScoutFlameDestroyer : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (anim.GetInteger("hurtNumber") == 2)
        {
            Debug.Log("Need to destroy flame");
            Destroy(gameObject);
        }
    }
}
