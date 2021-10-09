using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public Rigidbody rigidbody = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider collider)
    {
        Debug.LogError("Collided with " + collider.gameObject.name);

        if (collider.gameObject.tag == "Player")
        {
            StartCoroutine(PlatformFallDelay());
        }
    }
    private IEnumerator PlatformFallDelay()
    {
        yield return new WaitForSeconds(1f);
        rigidbody.useGravity = true;
        Destroy(gameObject, 10);
    }
}
