using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public MovingTarget prefab = null;

    public int totalTargets = 5;

    public Transform minX = null;
    public Transform maxX = null;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < totalTargets; i++)
        {
            MovingTarget copy = Instantiate(prefab);
            copy.SetTargets(minX, maxX);
            float randomX = Random.Range(minX.position.x, maxX.position.x);
            float randomY = Random.Range(maxX.position.y, minX.position.y);
            copy.transform.position = new Vector3(randomX, randomY, copy.transform.position.z) ;

            copy.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
