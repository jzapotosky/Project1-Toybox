using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private bool isFalling = false;
    [SerializeField] private float downSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if(isFalling)
        {
            downSpeed += Time.deltaTime/10;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "Player")
        {
            isFalling = true;
            Destroy(gameObject, 10);
        }
    }
}
