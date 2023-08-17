using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovementController : MonoBehaviour
{
    public float speed = 1.0f;

    [SerializeField]
    private Renderer bgRenderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
        // transform.position += new Vector3(0.0f, -speed * Time.deltaTime, 0.0f);
    }
}
