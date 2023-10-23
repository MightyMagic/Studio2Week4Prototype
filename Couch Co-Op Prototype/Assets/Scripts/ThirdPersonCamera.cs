using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header ("Horizontal Rotation")]
    [SerializeField, Range(1, 180)]
    private float leftRotationLimit = 180;

    [SerializeField, Range(1, 180)]
    private float rightRotationLimit = 180;

    [Header ("Vertical Rotation")]
    [SerializeField, Range(1, 180)]
    private float upRotationLimit = 30;

    [SerializeField, Range(1, 180)]
    private float downRotationLimit = 30;

    [SerializeField, Range(1, 50)]
    private float sensitivity = 20;

    private float rotationX;
    private float rotationY;

    private Vector3 velocity;
    private Vector3 currentRotation;
    private float smoothTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CameraMovement();
    }

    void CameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX += mouseX;
        rotationY += mouseY;

        rotationX = Mathf.Clamp(rotationX, -rightRotationLimit, leftRotationLimit);
        rotationY = Mathf.Clamp(rotationY, upRotationLimit, -downRotationLimit);

        Vector3 newRotation = new Vector3(rotationY, rotationX, 0);
        currentRotation = Vector3.SmoothDamp(currentRotation, newRotation, ref velocity, smoothTime);

        transform.localEulerAngles = currentRotation;
    }
}
