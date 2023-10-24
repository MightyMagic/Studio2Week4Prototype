using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    GameObject player;
    Vector3 tempRotation;
    float turnSpeed = 140f;
    void Start()
    {
        player = GameObject.Find("CarObject");
    }

    void Update()
    {
        if((player.transform.position - transform.position).magnitude < 80f)
        {
            RotateTowardEnemy();
        }
    }

    void RotateTowardEnemy()
    {
        tempRotation = (player.transform.position - transform.position).normalized;
        
        Quaternion targetRotation = Quaternion.LookRotation(tempRotation);
        targetRotation.y = Mathf.Clamp(targetRotation.y, -20, 30);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }
}
