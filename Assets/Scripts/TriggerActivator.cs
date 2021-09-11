using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerActivator : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _onTriggered.Invoke();
        }
    }
}
