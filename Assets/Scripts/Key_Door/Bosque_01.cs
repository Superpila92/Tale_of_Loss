using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosque_01 : MonoBehaviour
{
    private PlayerMovement thePlayer;
    public Transform flameHere01;

    public Megallama mega;

    public AudioSource soundSymbol;

    private float num = 1f;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
        AudioSource audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           
            
            if (thePlayer.followingLlama01 != null)
            {
                thePlayer.followingLlama01.followTarget = flameHere01.transform;
                mega.Activada1 = true;

                if(num == 1)
                {
                    Invoke("PlaySound", 1f);
                    num++;
                }

                
            }

        }
    }
    private void PlaySound()
    {
        soundSymbol.pitch = Random.Range (0.9f, 1f);
        soundSymbol.Play();
    }
}
