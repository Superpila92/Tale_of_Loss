using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Llama_02 : MonoBehaviour
{
    public bool isFollowing;

    public float followSpeed;

    public Transform followTarget;

    //public AudioSource pickKey;

    // Start is called before the first frame update
    void Start()
    {
        Renderer myRenderer = GetComponent<Renderer>();
        myRenderer.sortingOrder = 2;
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
           //pickKey.Play();
            if(!isFollowing)
            {
                PlayerMovement thePlayer = FindObjectOfType<PlayerMovement>();

                followTarget = thePlayer.llama02;

                isFollowing = true;
                thePlayer.followingLlama02 = this;
            }
        }

    }

}
