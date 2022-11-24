using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    public bool godMode = false;

    public Behaviour playerMovement;

    private float horizontal;
    private float vertical;
    public float speed = 8f;
    private bool isFacingRight = true;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        God();

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Flip();



    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.x);
        rb.velocity = new Vector2(vertical * speed, rb.velocity.y);
    }

    private void God()
    {
        if (Input.GetKey(KeyCode.G))
        {
            playerMovement.enabled = false;
            godMode = true;

            //GetComponent<GodMode>().enabled = true;
            //GetComponent<PlayerMovement>().enabled = false;
            
        }
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
