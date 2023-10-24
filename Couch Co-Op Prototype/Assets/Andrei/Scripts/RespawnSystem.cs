using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnSystem : MonoBehaviour
{
    [SerializeField] List<GameObject> locationIndexes;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Check"))
        {
           // if (PlayerPrefs.GetInt("Check") == 0)
           // {
           //     SceneManager.LoadScene("Andrei1");
           // }
           // else if((PlayerPrefs.GetInt("Check") > 0))
           //     SceneManager.LoadScene("SampleScene");
        }
        else
        {
            PlayerPrefs.SetInt("Check", 0);
        }
    }

    void Start()
    {
        print("My playerprefs is " + PlayerPrefs.GetInt("Check"));

        if (SceneManager.GetActiveScene().name == "MainMenu")
            Cursor.visible = true;
    }

  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void Resume()
    {
        if (PlayerPrefs.GetInt("Check") == 0)
        {
            SceneManager.LoadScene("Andrei1");
        }
        else if ((PlayerPrefs.GetInt("Check") > 0))
            SceneManager.LoadScene("Andrei2");
    }

    public void Restart()
    {
        PlayerPrefs.SetInt("Check", 0);
        SceneManager.LoadScene("Andrei1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
