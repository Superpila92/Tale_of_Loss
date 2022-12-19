using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwap2 : MonoBehaviour
{
    public AudioClip newTrack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            AudioManager2.instance.SwapTrack(newTrack);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager2.instance.ReturnToTrack1();
        }
    }
}
