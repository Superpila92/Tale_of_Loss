using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesapareceTodo1 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Collider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //this.GetComponentInChildren<Collider2D>().enabled = false;
    }
}
