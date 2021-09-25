using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float flightspeed;
    [SerializeField] private float lifetime;

    private float currLifeTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currLifeTime += Time.deltaTime;

        transform.Translate(Vector3.forward * flightspeed * Time.deltaTime);

        if(currLifeTime > lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            TankController tController = collision.gameObject.GetComponent<TankController>();
            if(tController != null)
            {
                tController.OnProjectileHit(transform.forward, 30f);
            }
        }
        Debug.LogError("Collided with " + collision.gameObject.name);
        Destroy(gameObject);
    }
}
