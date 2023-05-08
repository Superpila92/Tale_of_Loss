using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StoneAudioController : MonoBehaviour
{
    public AudioSource stoneDraggedbyPlayer;
    public PlayerMovement ply;

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
        if (collision.gameObject.CompareTag("Empujable"))
        {
            stoneDraggedbyPlayer.pitch = Random.Range(0.7f, 1f);
            stoneDraggedbyPlayer.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Empujable"))
        {
            stoneDraggedbyPlayer.Stop();
        }
    }

}
