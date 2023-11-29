using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickFlower : MonoBehaviour
{
    private bool isInRange;
    public FirstPlayerHealth playerHealth;
    public TextMeshProUGUI  interactUI;

    
    // Start is called before the first frame update
    void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPlayerHealth>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<TextMeshProUGUI>();

    }
    
    // Update is called once per frame
    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.R))
        {
            playerHealth.TakeDamage(playerHealth.maxHealth);
            interactUI.enabled = false;
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
        }
        
    }
}
