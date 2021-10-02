using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : MonoBehaviour
{
    public float force = 120f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            TankController tController = other.gameObject.GetComponentInParent<TankController>();

            if(tController != null)
            {
                tController.OnLandmineHit(force);
            }

            Destroy(gameObject);
        }
    }
}
