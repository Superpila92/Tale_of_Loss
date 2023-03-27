using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilarInSite : MonoBehaviour
{
    public scr_Pilar_Llama flame;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("llama"))
        {
            flame.counterFlames--;
        }
        
    }
}
