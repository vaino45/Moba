using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoam : MonoBehaviour
{
    public float camSpeed = 20; 
    public float screenSizeThickness = 10; 

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if(Input.mousePosition.y >= Screen.height - screenSizeThickness)
        {
            pos.z += camSpeed * Time.deltaTime; 
        }

        if(Input.mousePosition.y <= screenSizeThickness)
        {
            pos.z -= camSpeed * Time.deltaTime; 
        }

        if(Input.mousePosition.x >= Screen.height - screenSizeThickness)
        {
            pos.x += camSpeed * Time.deltaTime; 
        }

        if(Input.mousePosition.x <= screenSizeThickness)
        {
            pos.x -= camSpeed * Time.deltaTime; 
        }

        transform.position = pos; 
    }
}
