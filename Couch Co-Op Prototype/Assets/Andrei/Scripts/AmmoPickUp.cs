using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    GameObject player;
    [SerializeField] int ammoAmount;
    void Start()
    {
        player = GameObject.Find("CarObject");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerShooting>().ChangeAmmo(ammoAmount);
            Destroy(this.gameObject);
        }
    }
}
