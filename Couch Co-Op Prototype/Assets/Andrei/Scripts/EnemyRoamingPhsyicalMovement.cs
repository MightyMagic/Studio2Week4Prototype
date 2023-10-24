using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoamingPhsyicalMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;

    [SerializeField] List<GameObject> roamingPoints;

    Rigidbody rb;
    bool reachedPoint = false;
    int point = 0;
    Vector3 tempVelocity = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
       // Rotate();

        tempVelocity = new Vector3((roamingPoints[point].transform.position - transform.position).x, 0f, (roamingPoints[point].transform.position - transform.position).z);
        rb.velocity = tempVelocity.normalized * speed;
        //rb.AddForce(tempVelocity, ForceMode.VelocityChange);

    }

    void Update()
    {
        if(!reachedPoint && (roamingPoints[point].transform.position - transform.position).magnitude > 1f)
        {
            tempVelocity = new Vector3((roamingPoints[point].transform.position - transform.position).x, 0f, (roamingPoints[point].transform.position - transform.position).z);
            rb.velocity = tempVelocity.normalized * speed;
        }
        else if (!reachedPoint && (roamingPoints[point].transform.position - transform.position).magnitude < 1f)
        {
            reachedPoint = true;
            MoveToNextPoint();
            reachedPoint = false;
        }

        RotateTowardPoint();
    }

    void MoveToNextPoint()
    {
        point = (point + 1) % roamingPoints.Count;
        tempVelocity = new Vector3((roamingPoints[point].transform.position - transform.position).x, 0f, (roamingPoints[point].transform.position - transform.position).z);
        rb.velocity = tempVelocity.normalized * speed;
    }

    void RotateTowardPoint()
    {
        // Vector3 rotationVector = new Vector3(0, (roamingPoints[point].transform.position - transform.position).y * turnSpeed, 0);
        // Quaternion deltaRotation = Quaternion.Euler(rotationVector);
        // rb.MoveRotation(deltaRotation);

        tempVelocity = new Vector3((roamingPoints[point].transform.position - transform.position).x, 0f, (roamingPoints[point].transform.position - transform.position).z);
        Quaternion targetRotation = Quaternion.LookRotation(tempVelocity);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed*Time.deltaTime);
    }
}
