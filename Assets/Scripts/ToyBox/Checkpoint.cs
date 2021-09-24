using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private PlayerReset _reset = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_reset == null) { _reset = other.gameObject.GetComponent<PlayerReset>(); }
            
            if(_reset != null)
            {
                _reset.RecordTransform();
            }
        }
    }
}
