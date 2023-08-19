using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;

    public bool useMouse = false;
    public float sensX=80;
    public float sensY=80;

    public Transform player;
    public Transform orientation;

    float xRotation;
    float yRotation;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // test code for mouse coltroller
        if (useMouse)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        }

        Vector3 forward = player.forward;
        Vector3 up = player.up;
        Vector3 right = player.right;
        
        // set camera position relative against player
        transform.position = player.position + offset.x * right + offset.y * up + offset.z * forward;

        orientation.rotation = transform.rotation;
    }
}
