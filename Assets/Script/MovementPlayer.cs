using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MovementPlayer : MonoBehaviour
{ 

    private string currentSceneName;

    public float moveSpeed;
    public float climbSpeed;
    public float jumpForce;
    private float yPosition;
    
    private bool isFlipped;
    private bool isJumping;
    public bool isGrounded;
    [HideInInspector]
    public bool isClimbing;

    public Camera mainCamera; 

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Rigidbody2D rb; 
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private Vector3 playerPosition;

    public Collider2D attackTrigger;

    private float horizontalMovement;
    private float verticalMovement;

    public GameObject fadeEffect;

    private GameObject keyObject;
    public float pullSpeed = 1.0f;
    private bool isPulling = false;

    [HideInInspector]
    public bool world1 = true;

    public GameObject returnButton;
    public GameObject retryButton;
    public GameObject settingsButton;
    public GameObject settingsWindow;

    public AudioClip soundJump;
    public AudioClip soundChangeWorld;
    public AudioClip soundAttack;
    public AudioSource audioSource;

    void Start()
    {
        // start timer
        Time.timeScale = 1;
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
    }

    void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        verticalMovement = Input.GetAxis("Vertical") * climbSpeed * Time.deltaTime;
        

        MovePlayer(horizontalMovement, verticalMovement);

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        animator.SetBool("isClimbing", isClimbing);
    }

    void Update ()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        if (isGrounded)
        {
            animator.SetBool("Jump", false);
        }
        if (!isGrounded)
        {
            animator.SetBool("Jump", true);
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            audioSource.PlayOneShot(soundJump);
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

        if (keyObject != null && Input.GetKeyDown(KeyCode.E))
        {
            isPulling = true;
        }

        if (keyObject != null && isPulling)
        {
            keyObject.transform.position = Vector3.MoveTowards(keyObject.transform.position, transform.position, pullSpeed * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            isPulling = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            AttackEnemy();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }

        changementScene();
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Clef") || other.CompareTag("Clef1"))
        {
            keyObject = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Clef")  || other.CompareTag("Clef1"))
        {
            keyObject = null;
        }
    }

    public void TogglePauseMenu()
    {
        // Activer/désactiver le menu de pause
        returnButton.SetActive(!returnButton.activeSelf);
        settingsButton.SetActive(!settingsButton.activeSelf);
        retryButton.SetActive(!retryButton.activeSelf);


        // Mettre le jeu en pause
        Time.timeScale = returnButton.activeSelf ? 0 : 1;

    }

    public void settingWindwow()
    {
        settingsWindow.SetActive(!settingsWindow.activeSelf);
        returnButton.SetActive(!returnButton.activeSelf);
        settingsButton.SetActive(!settingsButton.activeSelf);
        retryButton.SetActive(!retryButton.activeSelf);
    }

    public void closeSetting()
    {
        settingsWindow.SetActive(!settingsWindow.activeSelf);
        returnButton.SetActive(!returnButton.activeSelf);
        settingsButton.SetActive(!settingsButton.activeSelf);
        retryButton.SetActive(!retryButton.activeSelf);
    }

    public void retryButtonGame()
    {
        Time.timeScale = 1f;
        returnButton.SetActive(!returnButton.activeSelf);
        settingsButton.SetActive(!settingsButton.activeSelf);
        retryButton.SetActive(!retryButton.activeSelf);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

   void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        if (!isClimbing)
        {
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

            if (isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;           
            }
        }
        else 
        {
            Vector3 targetVelocity = new Vector2(0, _verticalMovement);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

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
            audioSource.PlayOneShot(soundChangeWorld);
            animator.SetBool("ChangeScene", true);
            animator.SetBool("Jump", false);
            if (world1)
            {
                mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y - 60, mainCamera.transform.position.z);
                transform.position = new Vector3(transform.position.x, transform.position.y - 60, transform.position.z);
                world1 = false;
            }
            else 
            {
                mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y + 60, mainCamera.transform.position.z);
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
        audioSource.PlayOneShot(soundAttack);
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
                if(hit.gameObject.GetComponent<EnemyPatrol>().protectedWithAura == false)
                {
                    if(hit.gameObject.GetComponent<EnemyPatrol>().linkedEnemy != null)
                    {
                        hit.gameObject.GetComponent<EnemyPatrol>().linkedEnemy.protectedWithAura = false;
                    }
                    Destroy(hit.gameObject); 
                }
            }
        }
    }
}
 