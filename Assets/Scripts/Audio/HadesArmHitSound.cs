using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadesArmHitSound : MonoBehaviour
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            BigHit.Play();
        }
    }

}
