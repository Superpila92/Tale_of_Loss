using System.Collections;
using UnityEngine;

//using armatureComponent = DragonBones.UnityArmatureComponent;

public class PlayerMovement : MonoBehaviour
{
    private bool isJumping;

    private float horizontal;
    //private float vertical;
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

    private Animator anim;

    private Vector3 ChangePosition;

    float adelante = 10f;

    float detras = -10f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AudioSource audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

        ChangePosition = transform.position;

    }

    private void Update()
    {
        if (horizontal == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {

            anim.SetBool("isWalking", true);
        }
        horizontal = Input.GetAxisRaw("Horizontal");



        Flip();
        GodMode();
        Normality();

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            anim.SetTrigger("isJumping");

            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            isJumping = true;
            
        }
        else
        {
            
            anim.SetBool("isJumping_bool", true);

            isJumping = true;
        }
        if (!IsGrounded())
        {
            anim.SetTrigger("isFalling");
            anim.SetBool("isFalling_bool", true);
        }
        if (IsGrounded())
        {
            anim.SetBool("isFalling", false);
            isJumping = false;
            anim.SetBool("isJumping_bool", false);


        }


        //Camera Updates

        if (zoomIn)
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
        return Physics2D.OverlapCircle(groundCheck.position, 1f, groundLayer);
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
        if (Camera.main.orthographicSize < camSizeLimit)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Camera.main.orthographicSize + increment, timeLerp * Time.deltaTime);
        }
        else if (Camera.main.orthographicSize > camSizeLimit)
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Empujable"))
        {
            anim.SetTrigger("isDragging");
            anim.SetBool("isDragging_bool", true);
        }

        if (collision.gameObject.CompareTag ("Adelante"))
        {
            Zuse(adelante);
            Debug.Log("delante");
        } 
        
        if (collision.gameObject.CompareTag ("Detras"))
        {
            Zuse(detras);
            Debug.Log("detras");
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("isDragging_bool", false);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Deslizable"))
        {
            anim.SetTrigger("isSliding");
            anim.SetBool("isSliding_bool", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("isSliding_bool", false);
    }

    void Zuse(float posZ)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, posZ); ;
    }

}