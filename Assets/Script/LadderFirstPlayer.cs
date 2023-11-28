using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class LadderFirstPlayer : MonoBehaviour
{
    private bool isInRange;
    private MovementFirstPlayer playerMovement;
    public BoxCollider2D topCollider;
    public TextMeshProUGUI  interactUI;


    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementFirstPlayer>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<TextMeshProUGUI>();

    }

    void Update()
    {
        if(isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.R))
        {
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
            return;
        }

        if(isInRange && Input.GetKeyDown(KeyCode.R))
        {
            playerMovement.isClimbing = true;
            topCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;

        }
        
    }
}
