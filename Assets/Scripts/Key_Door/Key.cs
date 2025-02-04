using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Key : MonoBehaviour
{
    public bool isFollowing;

    public float followSpeed;

    public Transform followTarget;

    public AudioSource pickKey;

    public ParticleSystem Destello;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing)
        {
            transform.position = Vector2.Lerp(transform.position, followTarget.position, followSpeed * Time.deltaTime);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            pickKey.pitch = Random.Range(0.7f, 1f);
           pickKey.Play();
            if(!isFollowing)
            {
                
                PlayerMovement thePlayer = FindObjectOfType<PlayerMovement>();

                followTarget = thePlayer.keyFollowPoint;
                

                isFollowing = true;
                thePlayer.followingKey = this;
                
            }
        }

        if (collision.tag == "llave")
        {
            Destello.Play();
        }

    }




}
