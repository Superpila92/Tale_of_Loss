using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ramp : MonoBehaviour
{

    public PlayerMovement plyM;
    public CameraLimits cam;


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cam.offset.x = 14f;
            cam.offset.y = -14f;
            cam.offset.z = -100f;
            cam.damping = 0.3f;
            plyM.jumpingPower = 0f;
            plyM.speed = 0f;
            plyM.canFlip = false;
            Invoke("CanFlipDem", 13f);
            plyM.FlipDust2.Play();
        }


    }
    public void CanFlipDem()
    {
        plyM.canFlip = true;
        plyM.FlipDust2.Stop();
    }


}
