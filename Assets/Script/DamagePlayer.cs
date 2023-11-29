using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    public int damageOnCollision = 10;
    private string tag;

    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == tag)
        {
            if (tag == "PlayerFantom")
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageOnCollision);
            }
            else 
            {
                collision.gameObject.GetComponent<FirstPlayerHealth>().TakeDamage(damageOnCollision);
            }
        }
    }
}
