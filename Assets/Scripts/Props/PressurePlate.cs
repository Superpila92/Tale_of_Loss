using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Vector3 originalPos;
    public ChangeCamera cc;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Rock")
        {
            transform.Translate(0, -0.05f, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Rock")
        {
            collision.transform.parent = transform;
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            collision.transform.parent = null;
        }
    }
    private void Update()
    {
            if(transform.position.y <= -911f)
            {
                transform.Translate(0, 0.05f, 0);
            }

            if(transform.position.y <= -893f)
            {
                cc.mainCam.depth = 0;
                cc.elevatorCam.depth = 1;
                cc.nowMainCam = false;
            }
            if(transform.position.y <= -910.5f)
            {
                cc.mainCam.depth = 1;
                cc.elevatorCam.depth = 0;
                cc.nowMainCam = true;
            }


    }


}
