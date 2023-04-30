using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Megallama : MonoBehaviour
{
    public bool isFollowing;

    public float followSpeed;

    public Transform followTarget;

    public AudioSource pickKey;

    public bool Activada1 = false;
    public bool Activada2 = false;
    public bool Activada3 = false;
    public bool Activada4 = false;

    private ParticleSystem megaFlame;
    public GameObject megaF;
    // Start is called before the first frame update
    void Start()
    {
        megaFlame = gameObject.GetComponent<ParticleSystem>();
        megaFlame.Stop();
        megaF.gameObject.GetComponent<Collider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing)
        {
            transform.position = Vector2.Lerp(transform.position, followTarget.position, followSpeed * Time.deltaTime);
        }

        if ((Activada1 == true) && (Activada2 == true) && (Activada3 == true) && (Activada4 == true))
        {
            megaFlame.Play();
            megaF.gameObject.GetComponent<Collider2D>().enabled = true;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
           pickKey.Play();
            if(!isFollowing)
            {
                PlayerMovement thePlayer = FindObjectOfType<PlayerMovement>();

                followTarget = thePlayer.keyFollowPoint;

                isFollowing = true;
                thePlayer.followingMegallama = this;
            }
        }

    }

}
