using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera2 : MonoBehaviour
{
    public Camera mainCam;
    public Camera cabesaCam;



    public bool nowMainCam = true;

    public void CamSwitch()
    {
        if(nowMainCam)
        {
            mainCam.depth = 0;
            cabesaCam.depth = 1;
            nowMainCam = false;
        }
        else if(!nowMainCam)
        {
            mainCam.depth = 1;
            cabesaCam.depth = 0;
            nowMainCam = true;
            
        }
    }

}
