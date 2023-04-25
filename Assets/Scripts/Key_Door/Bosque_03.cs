using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosque_03 : MonoBehaviour
{
    private PlayerMovement thePlayer;
    public Transform flameHere03;

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
            
            if (thePlayer.followingLlama03 != null)
            {
                thePlayer.followingLlama03.followTarget = flameHere03.transform;
                mega.Activada3 = true;
            }
        }
    }
}
