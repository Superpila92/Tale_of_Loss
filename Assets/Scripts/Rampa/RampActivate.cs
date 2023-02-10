using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampActivate : MonoBehaviour
{
    public bool activate = false;

    public PlayerMovement plyM2;
    //public SmoothCamera cam2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activate)
        {
           // cam2.offset.x = 0f;
           // cam2.offset.y = 2f;
            //cam2.offset.z = -100f;
            //cam2.damping = 0.3f;
            plyM2.jumpingPower = 54f;
            plyM2.speed = 24f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            activate = true;
        }


    }
}
