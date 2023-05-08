using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwap4 : MonoBehaviour
{
    public AudioClip newTrack;
    public AudioManager am1;
    public AudioManager2 am2;
    public AudioManager3 am3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            am1.track01.Stop();
            am1.track02.Stop();
            am2.track01.Stop();
            am2.track02.Stop();
            am3.track01.Stop();
            am3.track02.Stop();
            AudioManager4.instance.ReturnToTrack1();

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            am1.track01.Stop();
            am1.track02.Stop();
            am2.track01.Stop();
            am2.track02.Stop();
            am3.track01.Stop();
            am3.track02.Stop();
            AudioManager4.instance.SwapTrack(newTrack);
        }
    }

}
