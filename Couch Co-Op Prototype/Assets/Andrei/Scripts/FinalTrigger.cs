using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalTrigger : MonoBehaviour
{
    [SerializeField] GameObject finalCanvas;
    [SerializeField] GameObject otherCanvases;
    // Start is called before the first frame update
    void Start()
    {
        finalCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameOver();
        }
    }

    IEnumerator GameOver()
    {
        otherCanvases.SetActive(false);
        finalCanvas.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        PlayerPrefs.SetInt("Check", 0);
        SceneManager.LoadScene("MainMenu");

    }
}
