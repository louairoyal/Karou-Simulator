using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float SenX;
    public float SenY;
    public Transform Orientation, head;
    float xRotation;
    float yRotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible= false;
    }

    // Update is called once per frame
    void Update()
    {
        getMouseAxis();
        Rotate(); 
    }
    void getMouseAxis()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * SenX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * SenY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }
    void Rotate()
    {
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        head.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        Orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
