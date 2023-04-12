using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hades_Key : MonoBehaviour
{
    private PlayerMovement thePlayer;
    public Transform keyHere;
    public Key key;

    //public GameObject collectEffect;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (key.followTarget.transform == keyHere.transform)
        {
            StartCoroutine(Wait());
           
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (thePlayer.followingKey != null && key.isFollowing)
            {

                thePlayer.followingKey.followTarget = keyHere.transform;
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        GetComponent<EdgeCollider2D>().enabled = false;
    }
}
