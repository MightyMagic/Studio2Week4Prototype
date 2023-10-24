using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleEffects : MonoBehaviour
{

    [SerializeField] GameObject smokeSystem;
    [SerializeField] GameObject[] wheels = new GameObject[4];
    [SerializeField] float wheelRotationSpeed;

    [SerializeField] private AudioSource engineAudio;
    bool soundPlaying;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        smokeSystem.SetActive(false);

        soundPlaying= false;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.magnitude > 0.2f)
        {
            smokeSystem.SetActive(true);
            if(!soundPlaying)
            {
                soundPlaying= true;
                PlayEngineSound(true);
            }
        
        }
        else
        {
            if (soundPlaying)
            {
                soundPlaying = false;
                PlayEngineSound(false);
            }

            smokeSystem.SetActive(false);
        }
    }

    void WheelsTurnForward()
    {
        Vector3 rotation = transform.right;

        foreach (GameObject wheel in wheels)
        {
            rotation = wheel.transform.right;
            wheel.transform.Rotate(rotation, wheelRotationSpeed * Time.deltaTime);
        }
    }

    void WheelsTurnBackwards()
    {
        Vector3 rotation = transform.right;

        foreach (GameObject wheel in wheels)
        {
            rotation = wheel.transform.right;
            wheel.transform.Rotate(rotation, - wheelRotationSpeed * Time.deltaTime);
        }     
    }

    void PlayEngineSound(bool isPlaying)
    {
        if (isPlaying)
            engineAudio.Play();
        else
            engineAudio.Stop();

        print("Engine!");
    }

   

}
