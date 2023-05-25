using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame2GoHere : MonoBehaviour
{
    private PlayerMovement thePlayer;
    public Transform flameHere;

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
            if (thePlayer.followingKey != null)
            {
                thePlayer.followingFlame.Target = flameHere.transform;
            }
        }
    }
}
