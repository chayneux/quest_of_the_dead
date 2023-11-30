using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    public bool isInRange;

    private string tag;
    public bool nextDialogue;

    private TextMeshProUGUI interactUI;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            tag = "Player";
        }
        else if (GameObject.FindGameObjectWithTag("PlayerFantom") != null)
        {
            tag = "PlayerFantom";
        }    

        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.R))
        {
            interactUI.enabled = false;
            TriggerDialogue();
        }
    }   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(tag))
        {
            isInRange = true;
            interactUI.enabled = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag(tag))
        {
            isInRange = false;
            nextDialogue = false;
            interactUI.enabled = false;
            DialogueManager.instance.EndDialogue();

        }
        
    }

    void TriggerDialogue()
    {
        if (!nextDialogue)
            DialogueManager.instance.StartDialogue(dialogue);
        else
            DialogueManager.instance.DisplayNextSentence();

    }
}
