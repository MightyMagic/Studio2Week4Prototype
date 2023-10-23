using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLogic : MonoBehaviour
{
    float mouseX;
    float mouseY;

    [SerializeField] float sensitivity;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        RotateViaMouse();
    }

    void RotateViaMouse()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y") * sensitivity;

        mouseY = Mathf.Clamp(mouseY, -20, 30);

        transform.rotation = Quaternion.Euler(new Vector3(-mouseY, mouseX * sensitivity, 0));// * transform.parent.parent.rotation;
    }
}
