using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.04f;
    [SerializeField] private float rotSpeed = 0.1f;
    private Vector3 targetLocation = Vector3.zero;
    private Vector3 targetDirection = Vector3.zero;
    private bool reachedTarget = true;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if the bug reached the previous target, create a new target
        if (reachedTarget)
        {
            // create a random target location within the bounds of the environment
            targetLocation = new Vector3(Random.Range(-25, 25), Random.Range(1, 15), Random.Range(-25, 25));
            targetDirection = targetLocation - transform.position;
            reachedTarget = false;
        }
        else
        {
            // move towards the target location at the speed of speed
            transform.position = Vector3.MoveTowards(transform.position, targetLocation, moveSpeed);

            // rotate towards target location
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotSpeed, 0.0f);
            Debug.DrawRay(transform.position, newDirection, Color.red);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }

        // if bug has reached target, set reachedTarget to true
        if(Vector3.Distance(transform.position, targetLocation) < 0.01f)
        {
            reachedTarget = true;
        }
    }
}
