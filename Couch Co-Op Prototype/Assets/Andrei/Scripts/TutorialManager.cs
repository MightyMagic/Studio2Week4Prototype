using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    [SerializeField] List<GameObject> pickUps = new List<GameObject>();

    [SerializeField] List<TextMeshProUGUI> driverTutorials;
    int driverCount = 0;
    [SerializeField] List<TextMeshProUGUI> turretTutorials;
    int turretCount = 0;

    bool isTutorial = false;

    void Awake()
    {
        if (PlayerPrefs.HasKey("Tutorial"))
        {
            if (PlayerPrefs.GetInt("Tutorial") >= 5)
            {
                EnablePlayField(true);
                isTutorial = false;
            }
            else
            {
                EnablePlayField(false);
                isTutorial = true;
            }
        }
        else
        {
            PlayerPrefs.SetInt("Tutorial", 0);
            EnablePlayField(false);
            isTutorial = false;
        }
    }

    private void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ResetTutorial();
        }

        if(isTutorial && Input.GetKeyDown(KeyCode.Return))
        {
            int currentTutorialCount = PlayerPrefs.GetInt("Tutorial") +1;
            driverCount++;

            if(driverCount < driverTutorials.Count)
            {

            }
            DisableTutorialMessages();
            
        }
    }

    void EnablePlayField(bool state)
    {
        CarPhysicalMovement carMovement = playerObject.GetComponent<CarPhysicalMovement>();
        VehicleEffects vehicleEffects= playerObject.GetComponent<VehicleEffects>();

        if (state)
        {
            carMovement.enabled= true;
            vehicleEffects.enabled= true;

            foreach (GameObject item in pickUps)
            {
                item.SetActive(true);
            }

            foreach (TextMeshProUGUI text in driverTutorials)
            {
                text.enabled= false;
            }
            foreach (TextMeshProUGUI text in turretTutorials)
            {
                text.enabled = false;
            }
        }
        else
        {
            carMovement.enabled = false;
            vehicleEffects.enabled = false;

            foreach (GameObject item in pickUps)
            {
                item.SetActive(false);
            }
           
            DisableTutorialMessages();

            turretTutorials[0].enabled = true;
            driverTutorials[0].enabled = true;
        }
    }

    void DisableTutorialMessages()
    {
        foreach (TextMeshProUGUI text in driverTutorials)
        {
            text.enabled = false;
        }
        foreach (TextMeshProUGUI text in turretTutorials)
        {
            text.enabled = false;
        }
    }

    void ResetTutorial()
    {
        PlayerPrefs.SetInt("Tutorial", 0);
        SceneManager.LoadScene("Andrei1");

    }
}
