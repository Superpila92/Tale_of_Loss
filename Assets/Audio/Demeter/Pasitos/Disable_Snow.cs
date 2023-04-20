using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable_Snow : MonoBehaviour
{

    public snow_Footsteps snow;
    public bool inSnow = true;


    // Start is called before the first frame update
    void Start()
    {
        snow.StopSnowFootsteps();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            inSnow = false;
            snow.snowFootstep.SetActive(false);
        }
    }
}
