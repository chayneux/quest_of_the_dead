using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class NiveauSuivant : MonoBehaviour
{

    private bool isInRange;
    public TextMeshProUGUI  interactUI;
    public string nextLevel;
    public AudioSource audioSource;
    public AudioClip sound;
    public GameObject gameOverUI;


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
            StartCoroutine(ShowMenuAfterDelay(2f)); 
        }
    }

    IEnumerator ShowMenuAfterDelay(float delay)
    {
        if (nextLevel == "level2")
        {
            PlayerPrefs.SetInt("Level1Completed", 1);
        }
        else if (nextLevel == "level3")
        {
            PlayerPrefs.SetInt("Level2Completed", 1);
        }
        audioSource.PlayOneShot(sound);
        gameOverUI.SetActive(true); 
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextLevel);
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
