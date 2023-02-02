using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameHades : MonoBehaviour
{
    private PlayerMovement thePlayer;

    public SpriteRenderer SR;
    public SpriteRenderer doorOpenSprite;

    public float followSpeed;
    public Transform followTarget;
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        {

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (thePlayer.followingKey != null)
            {
                thePlayer.followingKey.followTarget = followTarget;

            }
        }
    }
}