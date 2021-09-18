using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    private void Awake()
    {
       Debug.LogError("Awake"); 
    }

    private void OnEnable()
    {
        Debug.LogError("Enable");
    }

    private void OnDisable()
    {
        Debug.LogError("Disable");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.LogError("Start"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Fixedupdate is called at a set time Interval
    private void FixedUpdate()
    {
        
    }
}
