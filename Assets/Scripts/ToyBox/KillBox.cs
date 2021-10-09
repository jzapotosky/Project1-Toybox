using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerReset.Instance?.ResetLastPosition();
        }
    }

    private IEnumerator PlatformFallDelay()
    {
        yield return new WaitForSeconds(1f);

    }
}
