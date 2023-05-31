using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosque_03 : MonoBehaviour
{
    private PlayerMovement thePlayer;
    public Transform flameHere03;

    public Megallama mega;

    public AudioSource soundSymbol;

    private float num = 1f;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            if (thePlayer.followingLlama03 != null)
            {
                thePlayer.followingLlama03.followTarget = flameHere03.transform;
                mega.Activada3 = true;

                if (num == 1)
                {
                    Invoke("PlaySound", 1f);
                    num++;
                }
            }
        }
    }
    private void PlaySound()
    {
        soundSymbol.pitch = Random.Range(0.9f, 1f);
        soundSymbol.Play();
    }
}
