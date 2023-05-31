using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Llama_01 : MonoBehaviour
{
    public bool isFollowing;

    public float followSpeed;

    public Transform followTarget;

    public AudioSource pickKey;
    private float num = 1f;


    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
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
            if(!isFollowing)
            {
                PlayerMovement thePlayer = FindObjectOfType<PlayerMovement>();

                followTarget = thePlayer.llama01;

                isFollowing = true;
                thePlayer.followingLlama01 = this;
            }
            if(num == 1)
            {
                SoundPick();
                num++;
            }
        }

    }
    public void SoundPick()
    {
        pickKey.pitch = Random.Range(0.8f, 1f);
        pickKey.Play();
    }

}
