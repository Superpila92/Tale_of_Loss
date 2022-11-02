using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;


    public int limitJumps = 2;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    //Camera Variables

    public float camSize;
    public float camSizeLimit;
    public float increment;

    public float timeLerp;
    public float timelerpValue;
    public bool zoomIn = false;
    public bool zoomOut = false;

    public bool gravityIncrement = false;
    public bool gravityDecrement = false;


    public Transform keyFollowPoint;
    public Key followingKey;
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            if (limitJumps > 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                limitJumps--;
            }
            
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();

        if(IsGrounded())
        {
            if (gravityIncrement)
            {
                Physics2D.gravity = new Vector2(0, -200);
                speed = 0;
                jumpingPower = 0;
                limitJumps = 0;
            }
            if (gravityDecrement)
            {
                Physics2D.gravity = new Vector2(0, -9.81f);

            }
            speed = 10;
            jumpingPower = 18;
            limitJumps = 2;
        }

        //Camera Updates

        if(zoomIn)
        {
            ZoomIn();
        }

        if (zoomOut)
        {
            ZoomOut();
        }

        camSize = Camera.main.orthographicSize;
        timelerpValue = timeLerp * Time.deltaTime;


    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
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

    //Camera Functions

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ZoomIn")
        {
            zoomIn = true;
        }
        else if (collision.gameObject.tag == "ZoomOut")
        {
            zoomOut = true;
        }
        if (collision.gameObject.tag == "GravityTrigger")
        {
            gravityIncrement = true;
        }
        else if (collision.gameObject.tag == "GravityNormal")
        {
            gravityDecrement = true;
        }
    }
    private void ZoomOut()
    {
        if(Camera.main.orthographicSize < camSizeLimit)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Camera.main.orthographicSize + increment, timeLerp * Time.deltaTime);
        }
        else if(Camera.main.orthographicSize > camSizeLimit)
        {
            zoomOut = false;
        }
    }
    private void ZoomIn()
    {
        if (Camera.main.orthographicSize > 10f)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Camera.main.orthographicSize + -increment, timeLerp * Time.deltaTime);
        }
        else if (Camera.main.orthographicSize < 10f)
        {
            zoomIn = false;
        }
    }

}