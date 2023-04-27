using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwap4 : MonoBehaviour
{
    public AudioClip newTrack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager4.instance.SwapTrack(newTrack);
        }
    }

}
