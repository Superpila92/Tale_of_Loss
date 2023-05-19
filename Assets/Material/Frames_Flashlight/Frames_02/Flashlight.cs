using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    
    public Animator flashlight;
    public TriggerFlash flash;
    // Start is called before the first frame update
    void Start()
    {
        flashlight = gameObject.GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
