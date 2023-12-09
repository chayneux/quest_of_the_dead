using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor2 : MonoBehaviour
{
    public Animator animator; 
    private string tag;

    public AudioClip sound;
    public AudioSource audioSource;

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
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Clef1"))
        {
            audioSource.PlayOneShot(sound);
            animator.SetBool("isOpen", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Clef1"))
        {
            audioSource.Stop();
            animator.SetBool("isOpen", false);
        }
    }
}
