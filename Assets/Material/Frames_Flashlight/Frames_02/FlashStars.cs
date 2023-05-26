using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashStars : MonoBehaviour
{
    public Animator flashStars;
    public TriggerFlash flash;
    // Start is called before the first frame update
    void Start()
    {
        flashStars = gameObject.GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
