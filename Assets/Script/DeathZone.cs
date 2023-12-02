using UnityEngine;
using System.Collections;


public class DeathZone : MonoBehaviour
{

    private string tag;
    private Transform playerSpawn;
    public GameObject fadeEffect;


    public void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            tag = "Player";
        }
        else if (GameObject.FindGameObjectWithTag("PlayerFantom") != null)
        {
            tag = "PlayerFantom";
        }
            
        if (GameObject.FindGameObjectWithTag("PlayerSpawn") != null)
        {
            playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(tag))
        {
            fadeEffect.SetActive(true);
            StartCoroutine(ExampleCoroutine(collision));
            
            
        }

    }

    IEnumerator ExampleCoroutine(Collider2D collision)
    {
        yield return new WaitForSeconds(0.5f);
        collision.transform.position = playerSpawn.position;
        fadeEffect.SetActive(false);
    }

}

