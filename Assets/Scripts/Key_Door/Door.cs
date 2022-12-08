using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private PlayerMovement thePlayer;

    public SpriteRenderer SR;
    public SpriteRenderer doorOpenSprite;
    public bool doorOpen, waitingToOpen;

    //public GameObject collectEffect;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();  
    }

    // Update is called once per frame
    void Update()
    {
      if(waitingToOpen)
        {
            if(Vector3.Distance(thePlayer.followingKey.transform.position, transform.position) <0.1f)
            {
                waitingToOpen = false;

                doorOpen = true;

                SR.sprite = doorOpenSprite.sprite;

                thePlayer.followingKey.gameObject.SetActive(false);

                this.GetComponentInChildren<Collider2D>().enabled = false;
                
                   
                //Physics2D.IgnoreCollision(SR.GetComponent<Collider2D>(), SR.GetComponent<Collider2D>());
                thePlayer.followingKey = null;

                //collectEffect.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(thePlayer.followingKey != null)
            {
                thePlayer.followingKey.followTarget = transform;
                waitingToOpen = true;
                
            }
        }
    }
}
