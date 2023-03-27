using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Key : MonoBehaviour
{
    private bool isFollowing;

    public float followSpeed;

    public Transform followTarget;

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
        if(isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, followTarget.position, followSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
           //pickKey.Play();
            if(!isFollowing)
            {
                PlayerMovement thePlayer = FindObjectOfType<PlayerMovement>();

                followTarget = thePlayer.keyFollowPoint;

                isFollowing = true;
                thePlayer.followingKey = this;

                floor.GetComponentInChildren<Collider2D>().enabled = false;
            }
        }
    }
}
