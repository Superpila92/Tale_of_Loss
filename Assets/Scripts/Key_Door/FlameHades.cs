using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameHades : MonoBehaviour
{
    private bool isFollowingFlame;

    public float Speed;

    public Transform Target;

    public DisapearFloor floor;

    //public AudioSource pickKey;

    // Start is called before the first frame update
    void Start()
    {
        //floor.GetComponentInChildren<Collider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowingFlame)
        {
            transform.position = Vector3.Lerp(transform.position, Target.position, Speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //pickKey.Play();
            if (!isFollowingFlame)
            {
                PlayerMovement thePlayer = FindObjectOfType<PlayerMovement>();

                Target = thePlayer.flameFollowPoint;

                isFollowingFlame = true;
                thePlayer.followingFlame = this;

                floor.GetComponentInChildren<Collider2D>().enabled = false;
            }
        }
    }
}


