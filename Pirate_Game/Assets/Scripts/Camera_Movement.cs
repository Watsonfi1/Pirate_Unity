using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour{
    public float sensX;
    public float sensY;

    public Transform orentation;

    float xRotation;
    float yRotation;

    private void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update(){
        //getting the mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate camera and orentation
        transform.rotation = Quarternion.Euler(xRotation, yRotation, 0);
        orentation.rotation = Quarternion.Euler(0, yRotation, 0);
    }
}