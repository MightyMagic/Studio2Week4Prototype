using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    private int playerHealth = 100;
    [SerializeField] Slider hpBar;
    Vector3 playerStart;

    void Start()
    {
        hpBar.value = playerHealth;
        playerStart = transform.position;
    }

    private void Update()
    {
        if(hpBar.value < 1 || (playerStart.y - transform.position.y) > 3)
        {
            RestartFromCheckPoint();
        }
    }


    public void ChangeHealth(int difference)
    {
        playerHealth += difference;
        if(playerHealth > 100)
            playerHealth= 100;

        hpBar.value = playerHealth;
    }

    public void RestartFromCheckPoint()
    {
        if (PlayerPrefs.GetInt("Check") == 0)
        {
            SceneManager.LoadScene("Andrei1");
        }
        else if ((PlayerPrefs.GetInt("Check") > 0))
            SceneManager.LoadScene("Andrei2");
    }
}
