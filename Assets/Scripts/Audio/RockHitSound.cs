using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHitSound : MonoBehaviour
{
    public AudioSource BigHit;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            BigHit.Play();
        }
    }

}
