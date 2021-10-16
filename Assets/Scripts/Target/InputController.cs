using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private Mouse mouse = null;

    // Start is called before the first frame update
    void Start()
    {
        mouse = Mouse.current;
    }

    // Update is called once per frame
    void Update()
    {
        if(mouse.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(mouse.position.ReadValue());
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100f))
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
