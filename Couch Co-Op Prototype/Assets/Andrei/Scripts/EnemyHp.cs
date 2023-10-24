using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] Canvas hpCanvas;
    private int enemyHealth = 100;
    [SerializeField] Slider hpBar;
    Vector3 enemyStart;

    GameObject player;
    void Start()
    {
        player = GameObject.Find("CarObject");
        hpBar.value = 100;
        enemyStart = transform.position;
    }

    void Update()
    {
        hpCanvas.transform.rotation = player.transform.rotation;

        if(enemyHealth < 1 || (enemyStart.y - transform.position.y) > 3)
        {
            Death();
        }
    }

    public void ChangeHealth(int difference)
    {
        enemyHealth += difference;
        hpBar.value = enemyHealth;
    }

    void Death()
    {
        player.GetComponent<PlayerHp>().ChangeHealth(50);
        player.GetComponent<PlayerShooting>().ChangeAmmo(10);

        print("Ayayayay");

        Destroy(this.gameObject);
    }

}
