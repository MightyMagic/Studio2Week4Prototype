using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EnemyChasingPhysics : MonoBehaviour
{
    GameObject player;
    [SerializeField] float distanceToTrigger;
    bool isTriggered = false;

    [SerializeField] float turnSpeed;
    [SerializeField] float moveSpeed;

    Rigidbody rb;
    void Start()
    {
        player = GameObject.Find("CarObject");
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        if ((player.transform.position - transform.position).magnitude < distanceToTrigger)// && !isTriggered)
        {
            isTriggered= true;
            ChaseThePlayer();
           // print("Police triggered!");
        }
        
    }
    private void ChaseThePlayer()
    {
        Vector3 tempVelocity = new Vector3((player.transform.position - transform.position).x, 0f, (player.transform.position - transform.position).z);
        Quaternion targetRotation = Quaternion.LookRotation(tempVelocity);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

        rb.velocity = transform.forward * moveSpeed;
    }
}
