using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosque_02 : MonoBehaviour
{
    private PlayerMovement thePlayer;
    public Transform flameHere02;

    public Megallama mega;

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
            
            if (thePlayer.followingLlama02 != null)
            {
                thePlayer.followingLlama02.followTarget = flameHere02.transform;
                mega.Activada2 = true;
            }
        }

    }
}
