using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    GameObject player;
    Vector3 startingPosition;
    void Start()
    {
        player = GameObject.Find("CarObject");
        startingPosition = transform.position;
    }

    void Update()
    {
        if((transform.position - startingPosition).magnitude > 100f)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerHp>().ChangeHealth(-10);
        }
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHp>().ChangeHealth(-20);
        }
        Destroy(this.gameObject);
    }
}
