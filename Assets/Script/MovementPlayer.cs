using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementPlayer : MonoBehaviour
{ 

    private string currentSceneName;

    public float moveSpeed;
    public float jumpForce;
    private bool isFlipped;
    private float yPosition;
    private bool isJumping;
    public bool isGrounded;

    public Camera mainCamera; 

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Rigidbody2D rb; 
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private Vector3 playerPosition;

    public Collider2D attackTrigger;


    private bool world1 = true;

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

        if (spriteRenderer.flipX)
        {
            attackTrigger.offset = new Vector2(Mathf.Abs(attackTrigger.offset.x), attackTrigger.offset.y);
        }
        else
        {
            attackTrigger.offset = new Vector2(-Mathf.Abs(attackTrigger.offset.x), attackTrigger.offset.y);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            AttackEnemy();
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
            animator.SetBool("ChangeScene", true);
            animator.SetBool("Jump", false);
            if (world1)
            {
                mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y - 60, mainCamera.transform.position.z);
                mainCamera.backgroundColor = Color.blue;
                transform.position = new Vector3(transform.position.x, transform.position.y - 60, transform.position.z);
                world1 = false;
            }
            else 
            {
                mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y + 60, mainCamera.transform.position.z);
                mainCamera.backgroundColor = Color.yellow;
                transform.position = new Vector3(transform.position.x, transform.position.y + 60, transform.position.z);
                world1 = true;
            }
            animator.SetBool("Jump", false);
            animator.SetBool("ChangeScene", false);
            animator.SetTrigger("ChangeSceneArrive");
            
        }
    }

    void AttackEnemy()
    {
        animator.SetTrigger("Attack");
        Collider2D[] results = new Collider2D[10];
        ContactFilter2D filter = new ContactFilter2D().NoFilter();

        // Obtenez le nombre de colliders trouvés
        int numResults = Physics2D.OverlapCollider(attackTrigger, filter, results);

        for (int i = 0; i < numResults; i++)
        {
            Collider2D hit = results[i];
            if (hit.CompareTag("Ennemy"))
            {
                Debug.Log("Ennemi touché !");
                Destroy(hit.gameObject); // Détruit l'objet ennemi
            }
        }
    }
}
 