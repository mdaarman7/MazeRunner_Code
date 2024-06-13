using System.Collections;
using UnityEngine;
public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Rigidbody2D body;
    public Animator anim;
    private bool grounded;
    private float horizontalInput;
    bool isCrouching = false;
    float lastCrouchTime = 0f;
    float crouchCooldown = 0.5f;
    private Health playerHealth;
    public float _hurt;
    private bool isPlayerHurt;
    public GameObject GameOver;
    public GameObject YouWon;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Back;
    public Vector2 playerPos;
    public Vector2 nextlevel;
    public BackGroundColorChange backGroundColor;
    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _hurt = 1;
        GameOver.SetActive(false);
        YouWon.SetActive(false);
        playerPos = transform.position;
        nextlevel = new Vector2(193, -2);
        Level1.SetActive(false);
        Level2.SetActive(false);
        backGroundColor = FindObjectOfType<BackGroundColorChange>();
    }
    void Start()
    {
        if (LevelHandler.level2 == true)
        {
            transform.position = nextlevel;
            backGroundColor.ChangeColor();
        }
    }
    public void Update()
    {
        UserInput();
        playerPos = transform.position;
        if (body.position.x > -10.5f && body.position.x < -8f)  
            Level1.SetActive(true);
        else if (body.position.x > 170f && body.position.x < 193.5f)    
            Level2.SetActive(true);
        else{
            Level1.SetActive(false);
            Level2.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontalInput * speed * Time.deltaTime, body.velocity.y);
        if (Input.GetKey(KeyCode.Space) && grounded)    Jump();
    }
    private void UserInput()
    {
        //User Input 
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput > 0f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < 0f)
            transform.localScale = new Vector3(-1, 1, 1);
        //Animation Parameter For Idle and Run
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
        if (Input.GetKeyDown(KeyCode.S) && !isCrouching && Time.time - lastCrouchTime > crouchCooldown)
        {
            anim.SetTrigger("crouch");  //Crouch Animation
            isCrouching = true;
            lastCrouchTime = Time.time;
        }
        if (Input.GetKeyUp(KeyCode.S) && isCrouching)   
            isCrouching = false;
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed * 1.3f * Time.deltaTime);
        anim.SetTrigger("jump");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Obstacle" && !isPlayerHurt)
        {
            if (playerHealth.currenthealth > 0)
            {
                // Set The Flag To True To Indicate That The Player Is Currently Being Hurt
                isPlayerHurt = true;
                //Player Hurt
                playerHealth.currenthealth -= 1;
                anim.SetTrigger("hurt");    //Hurt Animation
                StartCoroutine(Respawn(0.5f)); // Delay For Respawn
                if (_hurt == 1)
                {
                    playerHealth.health3.fillAmount = 0;
                    _hurt = 0;
                }
                else
                {
                    playerHealth.health2.fillAmount = 0;
                    _hurt = 1;
                }
            }
            else
            {
                //Player Died
                anim.SetTrigger("die");     //Die Animation
                playerHealth.health1.fillAmount = 0;
                GameOver.SetActive(true);
                Back.SetActive(false);
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Home")
        {
            Vector2 nextLevel = new Vector2(193, -2);
            transform.position = nextLevel;
        }
        if (collision.gameObject.tag == "Home1")
        {
            YouWon.SetActive(true);
            Back.SetActive(false);
            Destroy(gameObject);
        }
    }
    //(Respawn Delay) Coroutine To Reset The isPlayerHurt Flag After A Delay
    IEnumerator Respawn(float duration)
    {
        yield return new WaitForSeconds(duration);
        isPlayerHurt = false;
        if (body.position.x < 20.05f)
        {
            Vector2 checkPoint = new Vector2(-9.72f, 3);
            transform.position = checkPoint;
        }
        else if (body.position.x > 20.05f && body.position.x < 192)
        {
            Vector2 checkPoint = new Vector2(20.05f, 3);
            transform.position = checkPoint;
        }
        else if (body.position.x > 193.08f && body.position.x < 235.2f)
        {
            Vector2 checkPoint = new Vector2(193.08f, 3);
            transform.position = checkPoint;
        }
        else if (body.position.x > 235.2 && body.position.x < 323)
        {
            Vector2 checkPoint = new Vector2(235.2f, 3);
            transform.position = checkPoint;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
    public bool canAttack()
    {
        // return horizontalInput == 0;         //Player Can't Fire If It Is Not In Idle State
        return true;
    }
}