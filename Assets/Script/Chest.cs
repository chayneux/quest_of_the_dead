using TMPro;
using UnityEngine;

public class Chest : MonoBehaviour
{
    
    private TextMeshProUGUI interactUI;
    private bool isInRange;

    public Animator animator; 
    public int healthAdd;

    private string tag;

    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            tag = "Player";
            Debug.Log("Player");
        }
        else if (GameObject.FindGameObjectWithTag("PlayerFantom") != null)
        {
            tag = "PlayerFantom";
            Debug.Log("PlayerFantom");
        }
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
        if (tag == "PlayerFantom")
        {
            GameObject.FindGameObjectWithTag("PlayerFantom").GetComponent<PlayerHealth>().AddHealth(healthAdd);
        }
        else 
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPlayerHealth>().AddHealth(healthAdd);
        }
        GetComponent<BoxCollider2D>().enabled = false;
        interactUI.enabled = false;
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
        }
        
    }
}
