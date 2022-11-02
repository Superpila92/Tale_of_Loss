using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideRamp : MonoBehaviour
{
    public bool gravityIncrement = false;
    public bool gravityDecrement = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gravityIncrement)
        {
            Physics2D.gravity = new Vector2(0, -200);
        }
        if(gravityDecrement)
        {
            Physics2D.gravity = new Vector2(0, -9.81f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GravityTrigger")
        {
            gravityIncrement = true;
        }
        else if (collision.gameObject.tag == "GravityNormal")
        {
            gravityDecrement = true;
        }

    }

}
