using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 28f;
    private bool isFacingRight = true;


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


    public Transform keyFollowPoint;
    public Key followingKey;

    public Collider2D goingThroughObjects;

    public SmoothCamera cam;

    public AudioSource jump;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AudioSource audio = GetComponent<AudioSource>();

    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");



        Flip();
        GodMode();
        Normality();

        if(IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                jump.Play();
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

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
        if (Camera.main.orthographicSize > 28f)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Camera.main.orthographicSize + -increment, timeLerp * Time.deltaTime);
        }
        else if (Camera.main.orthographicSize < 28f)
        {
            zoomIn = false;
        }
    }

    private void GodMode()
    {
        if (Input.GetKey(KeyCode.G))
        {
            //zoomOut = true;
            cam.damping = 0.05f;
            cam.offset.y = 0f;
            goingThroughObjects.enabled = false;
            speed = 300f;
            jumpingPower = 200f;
            Physics2D.gravity = new Vector2(0, -8f);

        }
    }
    private void Normality()
    {
        if (Input.GetKey(KeyCode.N))
        {
            //zoomIn = true;
            cam.damping = 0.3f;
            cam.offset.y = 2f;
            speed = 24f;
            jumpingPower = 54f;
            goingThroughObjects.enabled = true;
            Physics2D.gravity = new Vector2(0, -9.81f);

        }
    }

}