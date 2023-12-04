using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public TextMeshProUGUI  nameText;
    public TextMeshProUGUI  dialogueText;

    private Queue<string> sentences;

    private DialogueTrigger dialogueTrigger;

    public Animator animator;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il n'y a pas d'instance de dialogue manager dans la scène");
            return;
        }

        instance = this;

        if(GameObject.FindGameObjectWithTag("PNJ") != null)
            dialogueTrigger = GameObject.FindGameObjectWithTag("PNJ").GetComponent<DialogueTrigger>();

        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        dialogueTrigger.nextDialogue = true;
        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        Debug.Log(sentences.Count);
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
            
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        StopAllCoroutines();
        dialogueTrigger.nextDialogue = false;
    }
}
