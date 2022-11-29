using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StopAudio : MonoBehaviour
{
    public AudioSource MainTrack;
    // Start is called before the first frame update
    void Start()
    {
        MainTrack.Play();
        AudioSource audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwapTrack(AudioClip newClip)
    {
        StopAllCoroutines();

        StartCoroutine(FadeTrack(newClip));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            MainTrack.Stop();
        }
    }

    private IEnumerator FadeTrack(AudioClip newClip)
    {
        float timeToFade = 0.25f;
        float timeElapsed = 0;

            while (timeElapsed < timeToFade)
            {
                MainTrack.volume = Mathf.Lerp( 1, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
    }
}
