using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HoplitaColocado : MonoBehaviour
{
    public AudioSource clickHoplita;
    public bool hoplita = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Finish"))
        {
            hoplita = true;
            clickHoplita.Play();
        }
    }
}
