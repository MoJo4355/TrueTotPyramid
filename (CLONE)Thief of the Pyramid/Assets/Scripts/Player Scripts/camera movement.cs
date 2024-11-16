using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public GameObject OGobj;
    public Transform orientation;
    float xRotation;
    float yRotation;
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if(orientation == null){
            OGobj = GameObject.FindWithTag("orientation");
            orientation = OGobj.GetComponent<Transform>();
        }
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        //this makes it so the camera doesnt turn a full 360 up or down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
