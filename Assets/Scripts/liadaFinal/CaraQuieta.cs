using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaraQuieta : MonoBehaviour
{
    public Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        rb2d.IsSleeping();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
