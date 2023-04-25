using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosque_04 : MonoBehaviour
{
    private PlayerMovement thePlayer;
    public Transform flameHere04;

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
            
            if (thePlayer.followingLlama04 != null)
            {
                thePlayer.followingLlama04.followTarget = flameHere04.transform;
                mega.Activada4 = true;
            }
        }
    }
}
