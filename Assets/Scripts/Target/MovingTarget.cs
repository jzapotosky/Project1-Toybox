using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Transform minX = null;
    public Transform maxX = null;

    public bool movingLeft = false;

    private float moveThreshold = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(movingLeft)
        {
            Vector3 leftBound = new Vector3(minX.position.x, transform.position.y, transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, leftBound, moveSpeed * Time.deltaTime);

            if(Vector3.Distance(transform.position, leftBound) < moveThreshold)
            {
                movingLeft = false;
            }
        }
        else
        {
            Vector3 rightBound = new Vector3(maxX.position.x, transform.position.y, transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, rightBound, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, rightBound) < moveThreshold)
            {
                movingLeft = true;
            }
        }
    }

    public void SetTargets(Transform minX, Transform maxX)
    {
        this.minX = minX;
        this.maxX = maxX;
    }
}
