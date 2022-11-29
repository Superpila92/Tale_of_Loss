using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSound : MonoBehaviour
{
    public AudioSource magicSound;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            magicSound.Play();
        }
    }
}
