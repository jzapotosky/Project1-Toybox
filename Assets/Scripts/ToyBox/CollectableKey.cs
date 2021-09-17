using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableKey : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UIController.Instance?.OnKeyCollected();
            gameObject.SetActive(false);
        }
    }
}
