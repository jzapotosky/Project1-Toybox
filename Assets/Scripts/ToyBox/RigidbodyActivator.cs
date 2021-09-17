using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyActivator : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> _rigidBodies = new List<Rigidbody>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (Rigidbody rb in _rigidBodies)
            {
                rb.useGravity = true;
            }
        }
    }
}
