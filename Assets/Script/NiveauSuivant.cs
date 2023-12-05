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
            SceneManager.LoadScene(nextLevel);
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
        }
        
    }
}
