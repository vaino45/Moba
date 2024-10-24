using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitchManager : MonoBehaviour
{

    public FollowPlayer FollowPlayerScript; 
    public CameraRoam CameraRoamScript;

    bool camViewChanged = false;
    // Start is called before the first frame update
    void Start()
    {
        CameraRoamScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(camViewChanged == false )
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                camViewChanged = true;

                CameraRoamScript.enabled = true;
                FollowPlayerScript.enabled = false; 
            }
        }
        else if(camViewChanged == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                camViewChanged = false; 

                CameraRoamScript.enabled = false; 
                FollowPlayerScript.enabled = true; 
            }
        }
    }
}
