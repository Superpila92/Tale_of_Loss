using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Camera mainCam;
    public Camera elevatorCam;



    public bool nowMainCam = true;

    public void CamSwitch()
    {
        if(nowMainCam)
        {
            mainCam.depth = 0;
            elevatorCam.depth = 1;
            nowMainCam = false;
        }
        else if(!nowMainCam)
        {
            mainCam.depth = 1;
            elevatorCam.depth = 0;
            nowMainCam = true;
            
        }
    }

}
