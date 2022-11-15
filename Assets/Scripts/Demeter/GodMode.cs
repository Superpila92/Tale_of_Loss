using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    public bool godMode = false;

    public float velocity = 20f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.G))
        {
            godMode = true;

           GetComponent<PlayerMovement>().enabled = false;



            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
            {
                transform.position += Vector3.left * velocity * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
            {
                transform.position += Vector3.right * velocity * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
            {
                transform.position += Vector3.up * velocity * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
            {
                transform.position += Vector3.down * velocity * Time.deltaTime;
            }
        }


    }
}
