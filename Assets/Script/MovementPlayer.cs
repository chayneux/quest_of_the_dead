using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementPlayer : MonoBehaviour
{ 

    private string currentSceneName;

    public float moveSpeed;
    public float jumpForce;

    private bool isJumping;
    public bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Rigidbody2D rb; 
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private Vector3 playerPosition;


    private void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;

        Vector3 previousPlayerPosition = PlayerPositionManager.instance.GetPlayerPosition();
        if (previousPlayerPosition != Vector3.zero)
            transform.position = previousPlayerPosition;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement);

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    void Update ()
    {
        playerPosition = transform.position;
        PlayerPositionManager.instance.SavePlayerPosition(playerPosition);
        if (isGrounded)
        {
            animator.SetBool("Jump", false);
        }
        if (!isGrounded)
        {
            animator.SetBool("Jump", true);
        }


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        changementScene();
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;           
        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = true;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = false;
        }
    }

    void changementScene()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (currentSceneName == "sceneTest1")
            {
                SceneManager.LoadScene("sceneTest2");

                GameObject player = GameObject.Find("Player"); 
                if (player != null)
                {
                    player.transform.position = playerPosition;
                }
            }
            else
            {
                SceneManager.LoadScene("sceneTest1");

                GameObject player = GameObject.Find("Player");
                if (player != null)
                {
                    player.transform.position = playerPosition;
                }
            }
        }
    }
}
 