using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameHades : MonoBehaviour
{
    private bool isFollowingFlame;

    public float Speed;

    public Transform Target;

    public DisapearFloor floor;

    public AudioSource pickFlame;

    // Start is called before the first frame update
    void Start()
    {
        Renderer myRenderer = GetComponent<Renderer>();
        myRenderer.sortingOrder = 0;
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
            pickFlame.Play();
            if (!isFollowingFlame)
            {
                PlayerMovement thePlayer = FindObjectOfType<PlayerMovement>();

                Target = thePlayer.flameFollowPoint;

                isFollowingFlame = true;
                thePlayer.followingFlame = this;

                floor.GetComponentInChildren<Collider2D>().enabled = false;
                Renderer myRenderer = GetComponent<Renderer>();
                myRenderer.sortingOrder = 2;
            }
        }
        else if (collision.tag == "EstatuaHades")
        {
            Renderer myRenderer = GetComponent<Renderer>();
            myRenderer.sortingOrder = 6;
        }
    }
}


