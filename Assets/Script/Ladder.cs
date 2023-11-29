using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    private bool isInRange;
    private MovementPlayer playerMovement;
    public BoxCollider2D topCollider;
    public TextMeshProUGUI  interactUI;

    private string tag;

    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementPlayer>();
            tag = "Player";
            Debug.Log("Player");
        }
        else if (GameObject.FindGameObjectWithTag("PlayerFantom") != null)
        {
            playerMovement = GameObject.FindGameObjectWithTag("PlayerFantom").GetComponent<MovementPlayer>();
            tag = "PlayerFantom";
            Debug.Log("PlayerFantom");
        }
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
        if(collision.CompareTag(tag))
        {
            interactUI.enabled = true;
            isInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag(tag))
        {
            interactUI.enabled = false;
            isInRange = false;
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;

        }
        
    }
}
