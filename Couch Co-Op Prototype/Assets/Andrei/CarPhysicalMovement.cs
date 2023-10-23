using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPhysicalMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    Rigidbody rb;

    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 currentInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        Vector3 yMovement = new Vector3(0f, rb.velocity.y, 0f);

        if (currentInput.magnitude > 0.05f )
        {
            
            Vector3 planeMovement = new Vector3((transform.forward * speed * currentInput.y).x, 0f, (transform.forward * speed * currentInput.y).z);
            rb.velocity = new Vector3(planeMovement.x, rb.velocity.y, planeMovement.z);

            rb.rotation *= Quaternion.Euler(0, currentInput.x * turnSpeed, 0);
        }
        else
        {
            rb.velocity = yMovement;
        }
      
    }
}
