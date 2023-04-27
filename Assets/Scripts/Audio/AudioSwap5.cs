using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwap5 : MonoBehaviour
{
    public AudioClip newTrack;
    public AudioManager4 a4;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            a4.ReturnToTrack1();
        }
    }

}
