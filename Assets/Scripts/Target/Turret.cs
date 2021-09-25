using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float firingRange;
    [SerializeField] private float firingDelay;
    [SerializeField] private Transform player;

    private float currDelayTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerGo = GameObject.FindWithTag("Player");

        if (playerGo != null) 
        { 
            player = playerGo.transform; 
        }

        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        currDelayTime += Time.deltaTime;

        if(Vector3.Distance(transform.position, player.position) < firingRange)
        {
            AimAtPlayer();

            if(currDelayTime > firingDelay)
            {
                Shoot();
                currDelayTime = 0;
            }
        }
    }

    public void AimAtPlayer()
    {
        transform.LookAt(player);
    }

    public void Shoot()
    {

    }
}
