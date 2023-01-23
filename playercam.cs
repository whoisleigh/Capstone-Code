using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playercam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;  //makes it so the cursor stays in centre of screen/doesn't move and also not seen
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.smoothDeltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.smoothDeltaTime * sensY;
//the above is getting the mouse input
        yRotation += mouseX;
//handling rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);//making sure you cant look up or down too far

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);//rotating camera and orientation
    }
}
