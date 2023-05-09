using System.Collections;
using UnityEngine;

//using armatureComponent = DragonBones.UnityArmatureComponent;

public class PlayerMovement : MonoBehaviour
{
    public bool isJumping;

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

    public Transform flameFollowPoint;
    public FlameHades followingFlame;

    public Llama_01 followingLlama01;
    public Transform llama01;

    public Llama_02 followingLlama02;
    public Transform llama02;

    public Llama_03 followingLlama03;
    public Transform llama03;


    public Llama_04 followingLlama04;
    public Transform llama04;

    public Megallama followingMegallama;


    public Collider2D goingThroughObjects;

    public SmoothCamera cam;

    public AudioSource jump;

    public AudioSource sparkleSound;

    public Footsteps footsteps;

    public snow_Footsteps snowfootsteps;

    public bool inSnow = true;

    public Animator anim;

    private Vector3 ChangePosition;

    [Header("Zmovement")]
    float adelante = 10f;
    float detras = -10f;
    public int Layer;
    public GameObject DemeterZ;

    [Header("Flip")]
    public bool canFlip = true;
    public bool isPaused = false;
    public bool noTeGires = false;

    [Header("Particles")]
    public ParticleSystem FlipDust;
    public ParticleSystem FlipDust2;
    public ParticleSystem FlipStar;
    public ParticleSystem MagicDem;

    [Header("Tutorial")]
    public GameObject A;
    public GameObject D;
    public GameObject Flecha1;
    public GameObject Flecha2;
    public GameObject Salto;
    public GameObject FlechaSalto;
    public GameObject FlechitaArrastre;
    public GameObject Ltuto;
    public GameObject Romper;
    public GameObject Romper2;
    public GameObject FlechitaUp;
    public GameObject FlechitaTemplo;
    public static bool FlechaActivada = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AudioSource audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

        ChangePosition = transform.position;
        CreateMagic();

        Renderer myRenderer = GetComponent<Renderer>();
        myRenderer.sortingOrder = 2;
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

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused == false)
            {
                canFlip = false;
                isPaused = true;
                noTeGires = true;
            }
            else
            {
                canFlip = true;
                isPaused = false;
                noTeGires = false;
            }

        }

        Flip();

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            CreateDust();
            CreateStar();
            anim.SetTrigger("isJumping");

            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            isJumping = true;
            footsteps.Stopfootsteps();
            snowfootsteps.StopSnowFootsteps();
            jump.pitch = Random.Range(0.75f, 1f);
            jump.Play();
            sparkleSound.pitch = Random.Range(0.75f, 1f);
            sparkleSound.Play();
        }
        else
        {

            anim.SetBool("isJumping_bool", true);

            isJumping = true;
        }
        if (!IsGrounded())
        {
            isJumping = true;
            anim.SetTrigger("isFalling");
            anim.SetBool("isFalling_bool", true);
            anim.SetBool("isWalking", false);
            footsteps.Stopfootsteps();
            snowfootsteps.StopSnowFootsteps();


        }
        if (IsGrounded())
        {
            anim.SetBool("isFalling", false);
            isJumping = false;
            anim.SetBool("isJumping_bool", false);
            //footsteps.footsteps();

            if(inSnow == true)
            {
                snowfootsteps.SnowFootsteps();
            }
            if (inSnow == false)
            {
                footsteps.footsteps();
            }


        }
        if(IsGrounded() && horizontal == 0)
        {
            footsteps.Stopfootsteps();
            snowfootsteps.StopSnowFootsteps();
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
        if (canFlip == true)
        {
            if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
            {
                CreateDust();
                CreateStar();
                Vector3 localScale = transform.localScale;
                isFacingRight = !isFacingRight;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }
        else if ((canFlip == false) && (noTeGires == false))
        {
            //Debug.Log("haentradoaqui2");
            if (!isFacingRight && horizontal < 0f)
            {
                //Debug.Log("haentradoaqui1");
                Vector3 localScale = transform.localScale;
                isFacingRight = !isFacingRight;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
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
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Adelante"))
        {
            ChangeLayerTo2();
            //Zuse(adelante);
            Debug.Log("delante");
        }

        if (collision.gameObject.CompareTag("Detras"))
        {
            ChangeLayerTo1();
            //Zuse(detras);
            Debug.Log("detras");
        }

        if (collision.gameObject.CompareTag("FlechitaSalto"))
        {
            A.SetActive(true);
            D.SetActive(true);
            Flecha1.SetActive(true);
            Flecha2.SetActive(true);
            Salto.SetActive(true);
            FlechaSalto.SetActive(true);
            FlechitaArrastre.SetActive(true);
            Ltuto.SetActive(true);
            Romper.SetActive(true);
            Romper2.SetActive(true);
            FlechitaUp.SetActive(true);
            FlechitaTemplo.SetActive(true);
            FlechaActivada = true;
        }

        if (collision.gameObject.CompareTag("FlechitaSaltoOff"))
        {
            A.SetActive(false);
            D.SetActive(false);
            Flecha1.SetActive(false);
            Flecha2.SetActive(false);
            Salto.SetActive(false);
            FlechaSalto.SetActive(false);
            FlechitaArrastre.SetActive(false);
            Ltuto.SetActive(false);
            Romper.SetActive(false);
            Romper2.SetActive(false);
            FlechitaUp.SetActive(false);
            FlechitaTemplo.SetActive(false);
            FlechaActivada = false;
        }
           

}
    private void OnTriggerExit2D(Collider2D collision)
    {
        //anim.SetBool("isDragging_bool", false);
        inSnow = true;
        snowfootsteps.SnowFootsteps();
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

    void ChangeLayerTo2()
    {
        Renderer myRenderer = GetComponent<Renderer>();
        myRenderer.sortingOrder = 1;
    }

    void ChangeLayerTo1()
    {
        Renderer myRenderer = GetComponent<Renderer>();
        myRenderer.sortingOrder = 2;
    }

    void CreateDust()
    {   FlipDust.Play();    }

    void CreateStar()
    {   FlipStar.Play();    }

    void CreateMagic()
    {   MagicDem.Play();    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            inSnow = false;
            snowfootsteps.StopSnowFootsteps();
            Debug.Log("notsnow");
        }
    }
}