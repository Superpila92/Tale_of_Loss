using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwap3 : MonoBehaviour
{
    public AudioClip newTrack;
    public AudioManager2 am2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Rock"))
        {
            am2.track01.Stop();
            am2.track02.Stop();
            AudioManager3.instance.SwapTrack(newTrack);
        }
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    AudioManager3.instance.ReturnToTrack1();
        //}
    }

}
