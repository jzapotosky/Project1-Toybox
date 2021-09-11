using System.Collections;
using System.Collections.Generic;
using MichaelWolf;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerReset.Instance?.ResetLastPosition();
            
            ECMPlayerReset.Instance?.ResetLastPosition();
        }
    }
}
