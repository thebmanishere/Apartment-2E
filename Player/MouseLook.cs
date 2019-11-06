using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    float mouseX;
    float mouseY;

    public float maxY;
    public float minY;

    public float maxX;
    public float minX;

    public float speedH;
    public float speedV;

    public bool allowXClamp = false;
   

    private void Start()
    {
        CursorState(true);
    }


    void FixedUpdate () {

        cameraLook();

    }


   

    public void CursorState(bool state)
    {
        switch(state)
        {
            case true:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;

            case false:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
        }
    }


    void cameraLook() {

      
        mouseX += speedH * Input.GetAxis("Mouse X") * Time.deltaTime;

        mouseY -= speedV * Input.GetAxis("Mouse Y") * Time.deltaTime;

        mouseY = Mathf.Clamp(mouseY, minY, maxY);

        if (allowXClamp)
        {
            mouseX = Mathf.Clamp(mouseX, minX, maxX);
        }


        transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }

    
}
