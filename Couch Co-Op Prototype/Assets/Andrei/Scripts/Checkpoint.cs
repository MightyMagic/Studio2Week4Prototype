using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    GameObject player;
    [SerializeField] int checkpointIndex;
    void Start()
    {
        player = GameObject.Find("CarObject");
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(PlayerPrefs.GetInt("Check") == 0)
            {
                PlayerPrefs.SetInt("Check", 1);
                player.GetComponent<PlayerHp>().RestartFromCheckPoint();
            }
        }
    }
}
