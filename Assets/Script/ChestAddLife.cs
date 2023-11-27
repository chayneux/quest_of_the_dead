using TMPro;
using UnityEngine;

public class ChestAddLife : MonoBehaviour
{
    
    private TextMeshProUGUI interactUI;
    private bool isInRange;

    public Animator animator; 
    public int healthAdd;

    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.R))
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        animator.SetBool("openChest", true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().AddLife();
        GetComponent<BoxCollider2D>().enabled = false;
        interactUI.enabled = false;
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
        }
        
    }
}
