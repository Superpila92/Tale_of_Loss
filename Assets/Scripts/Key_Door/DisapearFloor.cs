using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearFloor : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponentInChildren<Collider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //this.GetComponentInChildren<Collider2D>().enabled = false;
    }
}
